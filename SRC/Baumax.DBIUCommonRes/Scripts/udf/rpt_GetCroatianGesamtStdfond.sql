print '%Creating function% [rpt_GetCroatianGesamtStdfond]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetCroatianGesamtStdfond]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetCroatianGesamtStdfond]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- obsolete now
/*
-- This is (contract time of an employee / numbers of workingdays in a week (in this country  numbers of workingdays in a week = 5 (it always 5))) * numbers of days in that month, that are not saturday or sunday 
CREATE FUNCTION [dbo].[rpt_GetCroatianGesamtStdfond] (@ReportName nvarchar(30), @EmployeeID bigint, @YearNum int, @MonthNum int)
RETURNS float
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
	DECLARE @Result float

    IF(@ReportName = 'CroatianMain')
    BEGIN
		DECLARE @CurDate smalldatetime
		DECLARE @LastDate smalldatetime
        DECLARE @BeginWeekDate smalldatetime
        DECLARE @EndWeekDate smalldatetime
        DECLARE @CurContractTime utiMinutes
        DECLARE @SumContractTime float

		SET @CurDate = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20)
        -- end of month
		SET @LastDate = DATEADD(day, -1, DATEADD(month, 1, @CurDate))
        SET @SumContractTime = 0

		WHILE(@CurDate <= @LastDate)
		BEGIN
			SET @BeginWeekDate = NULL
			SET @EndWeekDate = NULL
			SET @CurContractTime = NULL

			SELECT TOP 1
				   @CurContractTime = e.ContractHours,
				   @BeginWeekDate = e.WeekBegin,
				   @EndWeekDate = e.WeekEnd
			FROM   EmployeeWeekTimeRecording e
			WHERE  e.EmployeeID = @EmployeeID
			  AND  (@CurDate BETWEEN e.WeekBegin AND e.WeekEnd)

			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
            BEGIN
				SELECT TOP 1
						@CurContractTime = e.ContractHours,
						@BeginWeekDate = e.WeekBegin,
						@EndWeekDate = e.WeekEnd
				FROM   EmployeeWeekTimePlanning e
				WHERE  e.EmployeeID = @EmployeeID
				AND  (@CurDate BETWEEN e.WeekBegin AND e.WeekEnd)
            END

			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
            BEGIN
				SELECT TOP 1
						@CurContractTime = e.ContractWorkingHours * 60,
						@BeginWeekDate = @CurDate,
						@EndWeekDate = @CurDate
				FROM   EmployeeContract e
				WHERE  e.EmployeeID = @EmployeeID
				AND  (@CurDate BETWEEN e.ContractBegin AND e.ContractEnd)
            END

			-- if no data for week => try to find next one
			-- is there some more efficient than stupid searching by increment of date?
			IF( (@BeginWeekDate IS NULL) OR (@EndWeekDate IS NULL) OR (@CurContractTime IS NULL) )
			BEGIN
				  SET @CurDate = DATEADD(day, 1, @CurDate)
			END
			ELSE
			BEGIN
				WHILE( (@CurDate >= @BeginWeekDate) 
				   AND (@CurDate <= @EndWeekDate) 
				   AND (@CurDate <= @LastDate) 
					 )
				BEGIN
				  -- assuming "SET DATEFIRST 1;" was executed!
				  IF( NOT (DATEPART(weekday, @CurDate) IN (6,7)) )
				  BEGIN
					SET @SumContractTime = @SumContractTime + 
                                        (CAST(@CurContractTime AS float) / 5.0)
				  END
				  SET @CurDate = DATEADD(day, 1, @CurDate)
				END
			END
		END

        SET @Result = @SumContractTime
    END

     RETURN @Result
END;
*/
GO
