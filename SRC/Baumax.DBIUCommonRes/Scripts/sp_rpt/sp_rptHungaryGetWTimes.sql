print '%Creating procedure% sp_rptHungaryGetWTimes'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_rptHungaryGetWTimes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_rptHungaryGetWTimes]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_rptHungaryGetWTimes]
     @DateFrom smalldatetime
    ,@DateTo smalldatetime
	,@ReportName nvarchar(30)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
    SET DATEFIRST 1; -- week begins from monday
	
    CREATE TABLE #EmpAbsences (
		 EmpID bigint
		,Date smalldatetime
        ,StoreID int
		,CharID nvarchar(6)
    )

    DECLARE @CurDate smalldatetime
    DECLARE @CurAbsID bigint
    DECLARE @CurAbsChar nvarchar(6)
    DECLARE @CurEmpID bigint
    DECLARE @CurStoreID int

    -- add long time absences
    SELECT a.LongTimeAbsenceID AS LongTimeAbsenceID, a.CharID AS CharID
    INTO #TempLongAbsences
    FROM LongTimeAbsence a, CountryReportingIdentifier cri
    WHERE cri.ReportName = @ReportName
      AND a.CountryID = cri.CountryID
    
    DECLARE #TAbsCursor CURSOR LOCAL READ_ONLY FOR
		SELECT LongTimeAbsenceID, CharID FROM #TempLongAbsences

    SET @CurDate = @DateFrom
    WHILE(@CurDate <= @DateTo)
    BEGIN
      OPEN #TAbsCursor

      FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar
      WHILE @@FETCH_STATUS = 0
      BEGIN
        -- select every absence for all employees and all dates
        DECLARE #TEmpAbsCursor CURSOR LOCAL READ_ONLY FOR
           SELECT e.EmployeeID AS EmployeeID, s.SystemID AS StoreID
				 FROM   Employee e, Employee_LongTimeAbsence lta,
                        Store s, Region r, CountryReportingIdentifier cri
				 WHERE  lta.EmployeeID = e.EmployeeID
                   AND  lta.LongTimeAbsenceID = @CurAbsID
                   AND  ( @CurDate BETWEEN lta.BeginTime AND lta.EndTime
                        )
				   AND e.MainStoreID = s.StoreID
				   AND s.RegionID = r.RegionID
				   AND r.CountryID = cri.CountryID
				   AND cri.ReportName = @ReportName
        OPEN #TEmpAbsCursor
        SET @CurEmpID = NULL
        SET @CurStoreID = NULL
        FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurStoreID
        WHILE @@FETCH_STATUS = 0
        BEGIN
          IF(@CurEmpID IS NOT NULL)
          BEGIN
            INSERT INTO #EmpAbsences (EmpID, [Date], StoreID, CharID)
                                 VALUES (@CurEmpID, @CurDate, @CurStoreID, @CurAbsChar)
          END

          SET @CurEmpID = NULL
          FETCH NEXT FROM #TEmpAbsCursor INTO @CurEmpID, @CurStoreID
        END


        CLOSE #TEmpAbsCursor
        DEALLOCATE #TEmpAbsCursor

        FETCH NEXT FROM #TAbsCursor INTO @CurAbsID, @CurAbsChar
      END

      SET @CurDate = DATEADD(day, 1, @CurDate)
      CLOSE #TAbsCurSor
    END

    -- drop temp tables
    DEALLOCATE #TAbsCursor
    DROP TABLE #TempLongAbsences


	-- MAIN select
    -- working time recording
	SELECT e.PersID AS PersonalID 
		  ,s.SystemID AS StoreID
		  ,wtr.[Date] AS [Date]
		  ,NULL AS AbsenceTypeID
          ,wtr.[Begin] AS WTimeFrom
          ,wtr.[End] AS WTimeTo
	FROM Employee e
		,CountryReportingIdentifier cri
		,Region r
		,Store s
		,WorkingTimeRecording wtr
	WHERE e.MainStoreID = s.StoreID
	  AND s.RegionID = r.RegionID
	  AND r.CountryID = cri.CountryID
	  AND cri.ReportName = @ReportName
	  AND wtr.EmployeeID = e.EmployeeID
	  AND (wtr.Date BETWEEN @DateFrom AND @DateTo)

	UNION ALL

    -- common absences
	SELECT e.PersID AS PersonalID 
		  ,s.SystemID AS StoreID
		  ,atr.[Date] AS [Date]
		  ,a.CharID AS AbsenceTypeID
          ,atr.[Begin] AS WTimeFrom
          ,atr.[End] AS WTimeTo
	FROM Employee e
		,CountryReportingIdentifier cri
		,Region r
		,Store s
		,AbsenceTimeRecording atr
        ,Absence a
	WHERE e.MainStoreID = s.StoreID
	  AND s.RegionID = r.RegionID
	  AND r.CountryID = cri.CountryID
	  AND cri.ReportName = @ReportName
	  AND atr.EmployeeID = e.EmployeeID
	  AND (atr.Date BETWEEN @DateFrom AND @DateTo)
      AND atr.AbsenceID = a.AbsenceID

	UNION ALL

    -- long time absences
	SELECT e.PersID AS PersonalID 
		  ,s.SystemID AS StoreID
		  ,a.[Date] AS [Date]
		  ,a.CharID AS AbsenceTypeID
          ,NULL AS WTimeFrom
          ,NULL AS WTimeTo
	FROM Employee e
		,CountryReportingIdentifier cri
		,Region r
		,Store s
        ,#EmpAbsences a
	WHERE e.MainStoreID = s.StoreID
	  AND s.RegionID = r.RegionID
	  AND r.CountryID = cri.CountryID
	  AND cri.ReportName = @ReportName
      AND a.EmpID = e.EmployeeID

    ORDER BY PersonalID, [Date], AbsenceTypeID, WTimeFrom

	DROP TABLE #EmpAbsences
END
GO