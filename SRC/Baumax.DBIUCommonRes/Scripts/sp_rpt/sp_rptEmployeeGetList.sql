print '%Creating procedure% sp_rptEmployeeGetList'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_rptEmployeeGetList]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_rptEmployeeGetList]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_rptEmployeeGetList]
	 @StoreID bigint
    ,@YearNum int
    ,@MonthNum int
	,@ReportName nvarchar(30)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
    SET DATEFIRST 1; -- week begins from monday

	DECLARE @ConstAbsTypeIllness tinyint
	SET @ConstAbsTypeIllness = 3
	DECLARE @ConstAbsTypeHoliday tinyint
	SET @ConstAbsTypeHoliday = 2

	-- DayType:
	-- 0 = workday
	-- 1 = feast
	-- 2 = saturday
	-- 3 = sunday
	-- 4 = no contract
	-- 5 = long time absence
	DECLARE @ConstDayTypeWorkday int
	SET @ConstDayTypeWorkday = 0
	DECLARE @ConstDayTypeFeast int
	SET @ConstDayTypeFeast = 1
	DECLARE @ConstDayTypeSaturday int
	SET @ConstDayTypeSaturday = 2
	DECLARE @ConstDayTypeSunday int
	SET @ConstDayTypeSunday = 3
	DECLARE @ConstDayTypeNoContract int
	SET @ConstDayTypeNoContract = 4
	DECLARE @ConstDayTypeLTA int
	SET @ConstDayTypeLTA = 5

	-- include days without recording in Gesamt Stud...?
	DECLARE @IncludeDaysWORecInGesStd bit
	SET @IncludeDaysWORecInGesStd = 1
	IF(    (@ReportName = 'BulgarianMain') 
      )
	BEGIN
		SET @IncludeDaysWORecInGesStd = 0
	END

	-- include feasts into count of days in Gesamt Stud...?
	DECLARE @IncludeFeastsInGesStd bit
	SET @IncludeFeastsInGesStd = 1
	IF(    (@ReportName = 'SlovakMain') 
        OR (@ReportName = 'CzechMain')
      )
	BEGIN
		SET @IncludeFeastsInGesStd = 0
	END

	DECLARE @DateFrom smalldatetime
	DECLARE @DateTo smalldatetime
    DECLARE @LastDay int
    DECLARE @CurDay int
	
	SET @DateFrom = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20)
	-- get the last day of the month
	SET @DateTo = DATEADD(day, -1, DATEADD(month, 1, @DateFrom))
    SET @LastDay = DATEPART(day, @DateTo)

	DECLARE @AvgDaysInWeek float
    SET @AvgDaysInWeek = [dbo].[rpt_GetAvgDaysInWeek](@ReportName, @YearNum)

	-- load only needed employees
	SELECT e.* 
	INTO #StoreEmployees
	FROM Employee e
	WHERE e.MainStoreID = @StoreID
	AND EXISTS (SELECT TOP 1 1 
				FROM EmployeeContract ec 
				WHERE ec.EmployeeID = e.EmployeeID
				AND ec.ContractEnd >= @DateFrom
				AND ec.ContractBegin <= @DateTo)

    -- contract times
    CREATE TABLE #EmpContractTime (
		EmpID bigint
		,Day int
		,CTime float

		,PRIMARY KEY (EmpID, Day)
    )

	DECLARE @CurDate smalldatetime
    DECLARE @BeginWeekDate smalldatetime
    DECLARE @EndWeekDate smalldatetime
    DECLARE @CurContractTime utiMinutes
	DECLARE @CurEmployeeID bigint
    DECLARE @CurWTime float

    DECLARE #TEmployeesCursor CURSOR LOCAL READ_ONLY FOR
		SELECT e.EmployeeID
          FROM #StoreEmployees e

	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurDate = @DateFrom
		WHILE(@CurDate <= @DateTo)
		BEGIN
			SET @BeginWeekDate = NULL
			SET @EndWeekDate = NULL
			SET @CurContractTime = NULL

			SELECT TOP 1
				   @CurContractTime = e.ContractHours,
				   @BeginWeekDate = e.WeekBegin,
				   @EndWeekDate = e.WeekEnd
			FROM   EmployeeWeekTimeRecording e
			WHERE  e.EmployeeID = @CurEmployeeID
			  AND  (@CurDate BETWEEN e.WeekBegin AND e.WeekEnd)

			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
			BEGIN
				SELECT TOP 1
						@CurContractTime = e.ContractHours,
						@BeginWeekDate = e.WeekBegin,
						@EndWeekDate = e.WeekEnd
				FROM   EmployeeWeekTimePlanning e
				WHERE  e.EmployeeID = @CurEmployeeID
				AND  (@CurDate BETWEEN e.WeekBegin AND e.WeekEnd)
			END

			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
			BEGIN
				SELECT TOP 1
						@CurContractTime = e.ContractWorkingHours * 60,
						@BeginWeekDate = @CurDate,
						@EndWeekDate = @CurDate
				FROM   EmployeeContract e
				WHERE  e.EmployeeID = @CurEmployeeID
				AND  (@CurDate BETWEEN e.ContractBegin AND e.ContractEnd)
			END

			-- if no data for week => try to find next one
			-- is there some more efficient than stupid searching by increment of date?
			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
			BEGIN
				  INSERT INTO #EmpContractTime (EmpID, Day, CTime)
						VALUES (@CurEmployeeID, DATEPART(day, @CurDate), 0.0)
				  SET @CurDate = DATEADD(day, 1, @CurDate)
			END
			ELSE
			BEGIN
				WHILE( (@CurDate >= @BeginWeekDate) 
				   AND (@CurDate <= @EndWeekDate) 
				   AND (@CurDate <= @DateTo) 
					 )
				BEGIN
				  INSERT INTO #EmpContractTime (EmpID, Day, CTime)
						VALUES (@CurEmployeeID, DATEPART(day, @CurDate), @CurContractTime/@AvgDaysInWeek)
				  SET @CurDate = DATEADD(day, 1, @CurDate)
				END
			END
		END
	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

    -- absence types
    SELECT a.AbsenceID AS AbsenceID, a.CharID AS CharID, a.UseInCalck as UseInCalc
    INTO #TempAbsences
    FROM Absence a, CountryReportingIdentifier cri
    WHERE cri.ReportName = @ReportName
      AND a.CountryID = cri.CountryID
    
    DECLARE #TAbsCursor CURSOR LOCAL READ_ONLY FOR
		SELECT AbsenceID, CharID, UseInCalc FROM #TempAbsences

    CREATE TABLE #EmpAbsencesStr (
		EmpID bigint
		,Day int
		,AbsStr nvarchar(1000)     -- these should be enough for several dozens of absences in a one day
        ,WTime float               -- amount of working time for summing (if absence is treated as working time)
		,AbsTime float			   -- real time of absence
	    
		,PRIMARY KEY (EmpID, Day)
    )

	CREATE TABLE #EmpAbsence_Map (
		EmpID bigint
		,Day int
		,AbsChar nvarchar(6)
		,WTime bigint
		,AbsTime bigint
		,IsIllness bit
		,IsHoliday bit
	    
		,PRIMARY KEY (EmpID, Day, AbsChar)
	)

    DECLARE @CurAbsID bigint
    DECLARE @CurAbsChar nvarchar(6)
	DECLARE @CurUseInCalc bit
    DECLARE @CurAbsStr nvarchar(1000)
    DECLARE @CurEmpID bigint
    DECLARE @CurAbsSum bigint
	DECLARE @CurAbsType tinyint
	DECLARE @CurIsIllness bit
	DECLARE @CurIsHoliday bit
    SET @CurDay = 1
    WHILE(@CurDay <= @LastDay)
    BEGIN
      OPEN #TAbsCursor
      SET @CurAbsStr = NULL
      FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar, @CurUseInCalc
      WHILE @@FETCH_STATUS = 0
      BEGIN
        -- select every absence for all employees and all dates
        DECLARE #TEmpAbsCursor CURSOR LOCAL READ_ONLY FOR
           SELECT e.EmployeeID AS EmployeeID, SUM(atr.[End] - atr.[Begin]) AS AbsSum, a.AbsenceTypeID AS AbsType
				 FROM   #StoreEmployees e, AbsenceTimeRecording atr, Absence a
				 WHERE  atr.EmployeeID = e.EmployeeID
                   AND  atr.AbsenceID = @CurAbsID
                   AND  atr.Date = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-'+CAST(@CurDay AS char(2)), 20)
                   AND  atr.AbsenceID = a.AbsenceID
           GROUP BY e.EmployeeID, a.AbsenceTypeID
        OPEN #TEmpAbsCursor
        SET @CurEmpID = NULL
        SET @CurAbsSum = NULL
		SET @CurAbsType = NULL
        FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurAbsSum, @CurAbsType
        WHILE @@FETCH_STATUS = 0
        BEGIN
          IF( (@CurEmpID IS NOT NULL) AND (@CurAbsSum IS NOT NULL) AND (@CurAbsType IS NOT NULL) )
          BEGIN
			IF(@CurAbsType = @ConstAbsTypeIllness)
			BEGIN
				SET @CurIsIllness = 1
			END
			ELSE
			BEGIN
				SET @CurIsIllness = 0
			END
			IF(@CurAbsType = @ConstAbsTypeHoliday)
			BEGIN
				SET @CurIsHoliday = 1
			END
			ELSE
			BEGIN
				SET @CurIsHoliday = 0
			END
			IF( (@ReportName = 'CzechMain') 
				AND (@CurAbsSum > 8*60) )
			BEGIN
				SET @CurAbsSum = 8*60
			END
	        IF(@CurUseInCalc = 1)
            BEGIN
				SET @CurWTime = @CurAbsSum
            END
            ELSE
            BEGIN
				SET @CurWTime = 0
            END
            IF(EXISTS (SELECT TOP 1 1
                             FROM #EmpAbsencesStr e
                            WHERE e.EmpID = @CurEmpID
                              AND e.Day = @CurDay) )
            BEGIN
              UPDATE #EmpAbsencesStr SET 
							AbsStr = AbsStr + CHAR(13) + CHAR(10) + 
										CONVERT(nvarchar, @CurAbsSum) + ' ' + @CurAbsChar, 
							WTime = WTime + @CurWTime, 
							AbsTime = AbsTime + @CurAbsSum
                     WHERE EmpID = @CurEmpID
                       AND Day = @CurDay
            END
            ELSE
            BEGIN
              INSERT INTO #EmpAbsencesStr (EmpID, Day, AbsStr, WTime, AbsTime)
                                   VALUES (@CurEmpID, @CurDay, 
											CONVERT(nvarchar, @CurAbsSum) + ' ' + @CurAbsChar, 
											@CurWTime, @CurAbsSum)
            END
			INSERT INTO #EmpAbsence_Map (EmpID, Day, AbsChar, WTime, AbsTime, IsIllness, IsHoliday)
								VALUES (@CurEmpID, @CurDay, @CurAbsChar, @CurWTime, @CurAbsSum,
										@CurIsIllness, @CurIsHoliday)
          END

          SET @CurEmpID = NULL
          SET @CurAbsSum = NULL
          FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurAbsSum, @CurAbsType
        END


        CLOSE #TEmpAbsCursor
        DEALLOCATE #TEmpAbsCursor

        FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar, @CurUseInCalc
      END

      SET @CurDay = @CurDay + 1
      CLOSE #TAbsCurSor
    END

    -- drop temp tables
    DEALLOCATE #TAbsCursor
    DROP TABLE #TempAbsences


    -- add long time absences
    CREATE TABLE #EmpLTA_Map (
		EmpID bigint
		,Day int
		,AbsChar nvarchar(6)
	    
		,PRIMARY KEY (EmpID, Day, AbsChar)
    )

    SELECT a.LongTimeAbsenceID AS LongTimeAbsenceID, a.CharID AS CharID
    INTO #TempLongAbsences
    FROM LongTimeAbsence a, CountryReportingIdentifier cri
    WHERE cri.ReportName = @ReportName
      AND a.CountryID = cri.CountryID
    
    DECLARE #TAbsCursor CURSOR LOCAL READ_ONLY FOR
		SELECT LongTimeAbsenceID, CharID FROM #TempLongAbsences


    SET @CurDay = 1
    WHILE(@CurDay <= @LastDay)
    BEGIN
      OPEN #TAbsCursor
      SET @CurAbsStr = NULL
      FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar
      WHILE @@FETCH_STATUS = 0
      BEGIN
        -- select every absence for all employees and all dates
        DECLARE #TEmpAbsCursor CURSOR LOCAL READ_ONLY FOR
           SELECT e.EmployeeID AS EmployeeID, 1 AS AbsSum
				 FROM   #StoreEmployees e, Employee_LongTimeAbsence lta
				 WHERE  lta.EmployeeID = e.EmployeeID
                   AND  lta.LongTimeAbsenceID = @CurAbsID
                   AND  ( CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'
												+CAST(@MonthNum AS char(2))+'-'
												+CAST(@CurDay AS char(2)), 20)
                          BETWEEN lta.BeginTime AND lta.EndTime
                        )
           GROUP BY e.EmployeeID
        OPEN #TEmpAbsCursor
        SET @CurEmpID = NULL
        SET @CurAbsSum = NULL
        FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurAbsSum
        WHILE @@FETCH_STATUS = 0
        BEGIN
          IF( (@CurEmpID IS NOT NULL) AND (@CurAbsSum IS NOT NULL) )
          BEGIN
			SET @CurWTime = (SELECT CTime FROM #EmpContractTime 
                              WHERE EmpID = @CurEmpID 
                              AND Day = @CurDay)
            IF(EXISTS (SELECT TOP 1 1
                             FROM #EmpAbsencesStr e
                            WHERE e.EmpID = @CurEmpID
                              AND e.Day = @CurDay) )
            BEGIN
              UPDATE #EmpAbsencesStr SET AbsStr = AbsStr + CHAR(13) + CHAR(10) + @CurAbsChar
                                         ,WTime = WTime + @CurWTime
										 ,AbsTime = AbsTime + @CurWTime
                     WHERE EmpID = @CurEmpID
                       AND Day = @CurDay
            END
            ELSE
            BEGIN
              INSERT INTO #EmpAbsencesStr (EmpID, Day, AbsStr, WTime, AbsTime)
                                   VALUES (@CurEmpID, @CurDay, @CurAbsChar, @CurWTime, @CurWTime)
            END
			INSERT INTO #EmpLTA_Map (EmpID, Day, AbsChar)
					VALUES (@CurEmpID, @CurDay, @CurAbsChar)
          END

          SET @CurEmpID = NULL
          SET @CurAbsSum = NULL
          FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurAbsSum
        END


        CLOSE #TEmpAbsCursor
        DEALLOCATE #TEmpAbsCursor

        FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar
      END

      SET @CurDay = @CurDay + 1
      CLOSE #TAbsCurSor
    END

    -- drop temp tables
    DEALLOCATE #TAbsCursor
    DROP TABLE #TempLongAbsences

	-- working times
    CREATE TABLE #EmpWrkTime (
		EmpID bigint
		,Day int
		,WTime int
		,PureWrkDay bit					-- pure working day 
										-- (day that contains working recordings 
										-- and doesn't contain any absences)

		,PRIMARY KEY (EmpID, Day)
    )

	DECLARE @CurPureWrkDay bit
	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurDate = @DateFrom
		WHILE(@CurDate <= @DateTo)
		BEGIN
			SET @CurWTime = NULL
			SELECT @CurWTime = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW
				 WHERE e.EmployeeID = @CurEmployeeID 
			       AND e.Date = @CurDate
				   AND e.Store_WorldID = SW.Store_WorldID
                   AND SW.StoreID = @StoreID
			IF( (NOT EXISTS (SELECT TOP 1 1 
							FROM #EmpAbsencesStr eas
							WHERE eas.Day = DATEPART(day, @CurDate)
							AND   eas.EmpID = @CurEmployeeID)
				)
				AND (@CurWTime > 0)
			  )
				SET @CurPureWrkDay = 1
			ELSE
				SET @CurPureWrkDay = 0
			INSERT INTO #EmpWrkTime (EmpID, Day, WTime, PureWrkDay)
					VALUES(@CurEmployeeID, DATEPART(day, @CurDate), ISNULL(@CurWTime,0), @CurPureWrkDay)

			SET @CurDate = DATEADD(day, 1, @CurDate)
		END
	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

	-- Gesamtstundenfond
    CREATE TABLE #EmpGesStd (
		EmpID bigint
        ,GesStd float
	    
		,PRIMARY KEY (EmpID)
    )

	DECLARE @IncludeDay BIT
	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurDate = @DateFrom
		WHILE(@CurDate <= @DateTo)
		BEGIN
			SET @IncludeDay = 0
			IF( NOT (DATEPART(weekday, @CurDate) IN (6,7)) )
			BEGIN
				IF(@IncludeFeastsInGesStd = 1)
				BEGIN
					SET @IncludeDay = 1
				END
				ELSE
				BEGIN
					IF(NOT EXISTS (SELECT TOP 1 1
									 FROM Feasts f, CountryReportingIdentifier cri
									WHERE cri.ReportName = @ReportName
									  AND f.CountryID = cri.CountryID
									  AND f.FeastDate = @CurDate) )
					BEGIN
						SET @IncludeDay = 1
					END
				END
			END
			IF( (@IncludeDay = 1) AND (@IncludeDaysWORecInGesStd = 0) )
			BEGIN
				IF( (SELECT COUNT(*) 
						FROM #EmpWrkTime ewt
						WHERE ewt.EmpID = @CurEmployeeID
						AND ewt.Day = DATEPART(DAY, @CurDate)
						AND ewt.WTime > 0
					) = 0)
				BEGIN
					SET @IncludeDay = 0
				END
			END
			IF(@IncludeDay = 1)
			BEGIN
				IF(@ReportName = 'CzechMain')
				BEGIN
					SET @CurWTime = 8.0 * 60
				END
				ELSE
				BEGIN
					SET @CurWTime = (SELECT CTime FROM #EmpContractTime 
									  WHERE EmpID = @CurEmployeeID 
									    AND Day = DATEPART(day, @CurDate))
				END
				IF(EXISTS (SELECT TOP 1 1
								 FROM #EmpGesStd
								WHERE EmpID = @CurEmployeeID) )
				BEGIN
					UPDATE #EmpGesStd SET GesStd = GesStd + @CurWTime
					 WHERE EmpID = @CurEmployeeID
				END
				ELSE
				BEGIN
					INSERT INTO #EmpGesStd (EmpID, GesStd)
						VALUES (@CurEmployeeID, @CurWTime)
				END
			END
			SET @CurDate = DATEADD(day, 1, @CurDate)
		END
	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

	-- day types
    CREATE TABLE #EmpDayType (
		EmpID bigint
		,Day int
			-- DayType:
			-- 0 = workday
			-- 1 = feast
			-- 2 = saturday
			-- 3 = sunday
			-- 4 = no contract
			-- 5 = long time absence
		,DayType int

		,PRIMARY KEY (EmpID, Day)
    )

	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurDate = @DateFrom
		WHILE(@CurDate <= @DateTo)
		BEGIN
			-- no contract
			IF(NOT EXISTS (SELECT TOP 1 1
							 FROM EmployeeContract ec
							WHERE ec.EmployeeID = @CurEmployeeID
							  AND (@CurDate BETWEEN ec.ContractBegin AND ec.ContractEnd) ))
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeNoContract)
			END
			ELSE
			-- long time absence
			IF(EXISTS (SELECT TOP 1 1
						 FROM Employee_LongTimeAbsence lta
						WHERE lta.EmployeeID = @CurEmployeeID
						  AND (@CurDate BETWEEN lta.BeginTime AND lta.EndTime) ))
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeLTA)
			END
			ELSE
			-- feast
			IF(EXISTS (SELECT TOP 1 1
							 FROM Feasts f, CountryReportingIdentifier cri
							WHERE cri.ReportName = @ReportName
							  AND f.CountryID = cri.CountryID
							  AND f.FeastDate = @CurDate) )
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeFeast)
			END
			ELSE
			-- saturday
			IF(DATEPART(WEEKDAY, @CurDate) = 6)
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeSaturday)
			END
			ELSE
			-- sunday
			IF(DATEPART(WEEKDAY, @CurDate) = 7)
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeSunday)
			END
			ELSE
			-- common working day
			BEGIN
				INSERT INTO #EmpDayType (EmpID, Day, DayType)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @ConstDayTypeWorkday)
			END

			SET @CurDate = DATEADD(day, 1, @CurDate)
		END
	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

	-- employee delegations
    CREATE TABLE #EmpDelegations (
		EmpID bigint
		,Day int
		,StoreID bigint			-- storeID where employee assigned for day

		,PRIMARY KEY (EmpID, Day)
    )

	DECLARE @CurStoreID bigint
	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurDate = @DateFrom
		WHILE(@CurDate <= @DateTo)
		BEGIN
			SET @CurStoreID = NULL
			SELECT @CurStoreID = er.StoreID
					FROM Employee_Relations er
					WHERE er.EmployeeID = @CurEmployeeID
					AND (@CurDate BETWEEN er.BeginTime AND er.EndTime)
			-- if no delegations, take main store's id
			SET @CurStoreID = ISNULL(@CurStoreID, @StoreID)
			INSERT INTO #EmpDelegations (EmpID, Day, StoreID)
					VALUES (@CurEmployeeID, DATEPART(DAY, @CurDate), @CurStoreID)

			SET @CurDate = DATEADD(day, 1, @CurDate)
		END
	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

	-- saldo for the last day of the month
    CREATE TABLE #EmpSaldos (
		EmpID bigint
		,Saldo bigint			-- employee's saldo for the last day

		,PRIMARY KEY (EmpID)
    )

	DECLARE @CurSaldo BIGINT
	OPEN #TEmployeesCursor
    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @CurSaldo = NULL
		SET @CurDate = @DateTo
		IF(DATEPART(WEEKDAY, @CurDate) <> 7)
		BEGIN
			SET @CurDate = DATEADD(DAY, -7, @CurDate)
		END
		SELECT @CurSaldo = ewtr.Saldo, @CurDate = DATEADD(DAY, 1, ewtr.WeekEnd)
				FROM EmployeeWeekTimeRecording ewtr
				WHERE ewtr.EmployeeID = @CurEmployeeID
				AND (@CurDate BETWEEN ewtr.WeekBegin AND ewtr.WeekEnd)
		IF(@CurSaldo IS NOT NULL)
		BEGIN
			WHILE(@CurDate <= @DateTo)
			BEGIN
				SET @CurSaldo = @CurSaldo +
						(ISNULL((SELECT SUM(ewt.WTime) 
								FROM #EmpWrkTime ewt 
								WHERE ewt.EmpID = @CurEmployeeID
								AND ewt.Day = DATEPART(DAY, @CurDate)), 0)
						+ISNULL((SELECT SUM(eas.WTime) 
								FROM #EmpAbsencesStr eas 
								WHERE eas.EmpID = @CurEmployeeID
								AND eas.Day = DATEPART(DAY, @CurDate)), 0))
				SET @CurDate = DATEADD(day, 1, @CurDate)
			END
			INSERT INTO #EmpSaldos (EmpID, Saldo)
					VALUES (@CurEmployeeID, @CurSaldo)
		END

	    FETCH NEXT FROM #TEmployeesCursor INTO @CurEmployeeID
	END
    CLOSE #TEmployeesCursor

    DEALLOCATE #TEmployeesCursor

    -- MAIN select
    SELECT 
	e.EmployeeID AS EmployeeID
    -- nachname
    ,e.LastName AS LastName
    -- vorname
    ,e.FirstName AS FirstName
    -- PersID
    ,e.PersID AS PersID
    -- PersNum
    ,e.PersNumber AS PersNum
    -- Abteilung
    -- needed for croatian and just one(?) more report. should we filter this in other reports?
    ,e.Department AS Department

    -- working time for days
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 01) AS d01
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 02) AS d02
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 03) AS d03
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 04) AS d04
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 05) AS d05
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 06) AS d06
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 07) AS d07
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 08) AS d08
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 09) AS d09
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 10) AS d10
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 11) AS d11
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 12) AS d12
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 13) AS d13
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 14) AS d14
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 15) AS d15
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 16) AS d16
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 17) AS d17
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 18) AS d18
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 19) AS d19
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 20) AS d20
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 21) AS d21
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 22) AS d22
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 23) AS d23
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 24) AS d24
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 25) AS d25
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 26) AS d26
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 27) AS d27
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 28) AS d28
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 29) AS d29
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 30) AS d30
    ,(SELECT ewt.WTime FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.Day = 31) AS d31

    -- sum for days
    ,ISNULL((SELECT SUM(ewt.WTime) FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID), 0)
        +ISNULL((SELECT SUM(eas.WTime) FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID), 0)
			AS GesamtArbeitsstunden

	-- without absences (RO + SK)
    ,ISNULL((SELECT SUM(ewt.WTime) FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID), 0)
			AS NormaleStunden

	-- absences sum only (RO) (real time!, not just counted as working)
	,ISNULL((SELECT SUM(eas.AbsTime) FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID), 0)
			AS NichtGearbeiteteStunden

    -- day types (color indication)
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 01) AS dtyp01
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 02) AS dtyp02
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 03) AS dtyp03
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 04) AS dtyp04
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 05) AS dtyp05
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 06) AS dtyp06
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 07) AS dtyp07
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 08) AS dtyp08
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 09) AS dtyp09
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 10) AS dtyp10
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 11) AS dtyp11
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 12) AS dtyp12
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 13) AS dtyp13
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 14) AS dtyp14
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 15) AS dtyp15
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 16) AS dtyp16
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 17) AS dtyp17
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 18) AS dtyp18
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 19) AS dtyp19
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 20) AS dtyp20
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 21) AS dtyp21
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 22) AS dtyp22
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 23) AS dtyp23
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 24) AS dtyp24
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 25) AS dtyp25
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 26) AS dtyp26
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 27) AS dtyp27
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 28) AS dtyp28
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 29) AS dtyp29
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 30) AS dtyp30
    ,(SELECT edt.DayType FROM #EmpDayType edt WHERE edt.EmpID = e.EmployeeID AND edt.Day = 31) AS dtyp31

    -- absences
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 01) AS abs01
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 02) AS abs02
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 03) AS abs03
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 04) AS abs04
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 05) AS abs05
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 06) AS abs06
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 07) AS abs07
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 08) AS abs08
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 09) AS abs09
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 10) AS abs10
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 11) AS abs11
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 12) AS abs12
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 13) AS abs13
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 14) AS abs14
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 15) AS abs15
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 16) AS abs16
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 17) AS abs17
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 18) AS abs18
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 19) AS abs19
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 20) AS abs20
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 21) AS abs21
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 22) AS abs22
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 23) AS abs23
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 24) AS abs24
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 25) AS abs25
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 26) AS abs26
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 27) AS abs27
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 28) AS abs28
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 29) AS abs29
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 30) AS abs30
    ,(SELECT eas.AbsStr FROM #EmpAbsencesStr eas WHERE eas.EmpID = e.EmployeeID AND eas.Day = 31) AS abs31


	-- common
	,ISNULL((SELECT egs.GesStd FROM #EmpGesStd egs WHERE egs.EmpID = e.EmployeeID), 0) AS GesamtStdfond

	-- CROATIAN
    ,dbo.rpt_GetSumWorkedHoursOnSunday(@ReportName, e.EmployeeID, @YearNum, @MonthNum, @StoreID, 1) 
                      AS SumWorkedOnSunday

    ,dbo.rpt_GetSumWorkedHoursOnSunday(@ReportName, e.EmployeeID, @YearNum, @MonthNum, @StoreID, 0) 
                      AS SumWorkedOnSundayWoFeasts

    ,dbo.rpt_GetSumWorkedHoursOnFeast(@ReportName, e.EmployeeID, @YearNum, @MonthNum, @StoreID, 1, 1) 
                      AS SumWorkedOnFeast
    
			-- the same but without sundays
    ,dbo.rpt_GetSumWorkedHoursOnFeast(@ReportName, e.EmployeeID, @YearNum, @MonthNum, @StoreID, 1, 0) 
                      AS SumWorkedOnFeastWoSundays

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('GO') ), 0)
                      AS SumAbsAbbrGO

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('B') ), 0)
                      AS SumAbsAbbrB

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('IGO') ), 0)
                      AS SumAbsAbbrIGO

    -- slovakian
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND eam.IsHoliday = 1
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday
					AND edt.DayType <> @ConstDayTypeFeast ), 0)
                      AS SumAbsHolidaysWoWeWoF   -- without weekends, without feasts

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND eam.IsIllness = 1
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday ), 0)
                      AS SumAbsIllnessWoWe       -- without weekends

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND eam.IsIllness = 1
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday
					AND edt.DayType <> @ConstDayTypeFeast ), 0)
                      AS SumAbsIllnessWoWeWoF    -- without weekends, without feasts

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('PN')
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday
					AND edt.DayType <> @ConstDayTypeFeast ), 0)
                      AS SumAbsAbbrPNWoWeWoF    -- without weekends, without feasts

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('OCR')
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday ), 0)
                      AS SumAbsAbbrOCRWoWe       -- without weekends

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('OCR')
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday
					AND edt.DayType <> @ConstDayTypeFeast ), 0)
                      AS SumAbsAbbrOCRWoWeWoF    -- without weekends, without feasts

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('PV') ), 0)
                      AS SumAbsAbbrPV

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('NV') ), 0)
                      AS SumAbsAbbrNV

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('A') ), 0)
                      AS SumAbsAbbrA

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam, #EmpDayType edt
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('A')
					AND edt.EmpID = e.EmployeeID
					AND edt.Day = eam.Day
					AND edt.DayType <> @ConstDayTypeSaturday
					AND edt.DayType <> @ConstDayTypeSunday
					AND edt.DayType <> @ConstDayTypeFeast ), 0)
                      AS SumAbsAbbrAWoWeWoF      -- without weekends, without feasts

	-- Czech
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND eam.IsHoliday = 1 ), 0)
                      AS SumAbsHolidays

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND eam.IsIllness = 1 ), 0)
                      AS SumAbsIllness

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('O') ), 0)
                      AS SumAbsAbbrO

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('S') ), 0)
                      AS SumAbsAbbrS

	,dbo.rpt_GetSumWorkedHoursOnSaturday(@ReportName, e.EmployeeID, @YearNum, @MonthNum, @StoreID) 
                      AS SumWorkedOnSaturday

	,dbo.rpt_GetSumWorkedHoursInTimeRange(@ReportName, e.EmployeeID, @YearNum, @MonthNum, 22*60, 6*60)
                      AS SumWorkedFrom22To6

	-- Slovenian
	,(SELECT COUNT(*) FROM #EmpWrkTime ewt WHERE ewt.EmpID = e.EmployeeID AND ewt.PureWrkDay = 1)
                      AS CntPureWrkDays

	,dbo.rpt_GetSumWorkedHoursInTimeRange(@ReportName, e.EmployeeID, @YearNum, @MonthNum, 12*60, 24*60)
                      AS SumWorkedFrom12To24

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('D') ), 0)
                      AS SumAbsAbbrD

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('ID') ), 0)
                      AS SumAbsAbbrID

	-- Romanian
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('CO') ), 0)
                      AS SumAbsAbbrCO

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('CM') ), 0)
                      AS SumAbsAbbrCM

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('AM') ), 0)
                      AS SumAbsAbbrAM

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('M') ), 0)
                      AS SumAbsAbbrM

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('CS') ), 0)
                      AS SumAbsAbbrCS

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('I') ), 0)
                      AS SumAbsAbbrI

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('NEM') ), 0)
                      AS SumAbsAbbrNEM

	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('CFS') ), 0)
                      AS SumAbsAbbrCFS

	-- count of days when employee was delegated into another store
	,(SELECT COUNT(*) FROM #EmpDelegations ed WHERE ed.EmpID = e.EmployeeID AND ed.StoreID <> @StoreID)
                      AS CntDelegatedDays

	-- Bulgarian
    --,dbo.rpt_GetSumAbsenceAbbr(@ReportName, e.EmployeeID, @YearNum, @MonthNum, 'SU', 1, 1)
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('SU') ), 0)
                      AS SumAbsAbbrSU

    --,dbo.rpt_GetSumAbsenceAbbr(@ReportName, e.EmployeeID, @YearNum, @MonthNum, 'UA', 1, 1)
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('UA') ), 0)
                      AS SumAbsAbbrUA

    --,dbo.rpt_GetSumAbsenceAbbr(@ReportName, e.EmployeeID, @YearNum, @MonthNum, 'UU', 1, 1)
	,ISNULL((SELECT SUM(eam.AbsTime) FROM #EmpAbsence_Map eam
					WHERE eam.EmpID = e.EmployeeID 
					AND LOWER(eam.AbsChar) = LOWER('UU') ), 0)
                      AS SumAbsAbbrUU

	,(SELECT COUNT(*) FROM #EmpLTA_Map elm WHERE elm.EmpID = e.EmployeeID AND elm.AbsChar = 'M')
                      AS DaysLTAbsAbbrM

	,(SELECT es.Saldo FROM #EmpSaldos es WHERE es.EmpID = e.EmployeeID)
                      AS SaldoForLastDayOfMonth

				 FROM   #StoreEmployees e
				 ORDER BY e.LastName, e.FirstName

--SELECT * FROM #EmpAbsencesStr
--SELECT * FROM #EmpContractTime
--SELECT * FROM #EmpGesStd
--SELECT * FROM #EmpDayType
--SELECT * FROM #EmpWrkTime WHERE WTime <> 0
--SELECT * FROM #EmpDelegations
--SELECT * FROM #EmpSaldos
--SELECT * FROM #EmpAbsence_Map
--SELECT * FROM #EmpLTA_Map
--SELECT * FROM #StoreEmployees e ORDER BY e.LastName, e.FirstName

    -- drop temp tables
	DROP TABLE #EmpAbsencesStr
    DROP TABLE #EmpContractTime
	DROP TABLE #EmpGesStd
	DROP TABLE #EmpDayType
	DROP TABLE #EmpWrkTime
	DROP TABLE #EmpDelegations
	DROP TABLE #EmpSaldos
	DROP TABLE #EmpAbsence_Map
	DROP TABLE #EmpLTA_Map
	DROP TABLE #StoreEmployees

END
GO

--exec sp_rptEmployeeGetList 	 @StoreID = 1187, @YearNum = 2007, @MonthNum = 12, @ReportName = 'SlovakMain'
--exec sp_rptEmployeeGetList 	 @StoreID = 1287, @YearNum = 2008, @MonthNum = 1, @ReportName = 'CroatianMain'
--exec sp_rptEmployeeGetList 	 @StoreID = 1162, @YearNum = 2008, @MonthNum = 1, @ReportName = 'CzechMain'
--exec sp_rptEmployeeGetList 	 @StoreID = 1223, @YearNum = 2008, @MonthNum = 1, @ReportName = 'SlovenianMain'
--exec sp_rptEmployeeGetList 	 @StoreID = 1154, @YearNum = 2007, @MonthNum = 12, @ReportName = 'RomanianMain'
-- just for testing. there are no employees in bulgarian stores
--exec sp_rptEmployeeGetList 	 @StoreID = 1154, @YearNum = 2007, @MonthNum = 12, @ReportName = 'BulgarianMain'
