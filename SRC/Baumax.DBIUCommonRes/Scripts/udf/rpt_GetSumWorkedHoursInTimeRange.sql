print '%Creating function% [rpt_GetSumWorkedHoursInTimeRange]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetSumWorkedHoursInTimeRange]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetSumWorkedHoursInTimeRange]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sum of worked hours on a Feasts
CREATE FUNCTION [dbo].[rpt_GetSumWorkedHoursInTimeRange] (@ReportName nvarchar(30), @EmployeeID bigint, @YearNum int, @MonthNum int, @FromTime utsMinutes, @ToTime utsMinutes)
RETURNS bigint
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
  DECLARE @Result bigint
  DECLARE @StartDate smalldatetime
  DECLARE @LastDate smalldatetime

  SET @StartDate = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20)
  -- end of month
  SET @LastDate = DATEADD(day, -1, DATEADD(month, 1, @StartDate))

	IF(@FromTime < @ToTime)
	BEGIN
		select @Result = 
			SUM([dbo].[rpt_GetTimeIntersection](wtr.[Begin], wtr.[End], @FromTime, @ToTime))
		from Employee e 
			,WorkingTimeRecording wtr
		where e.employeeid = @EmployeeID
		and wtr.employeeid = e.employeeid

		and (wtr.[End] BETWEEN @FromTime and @ToTime
			or wtr.[Begin] BETWEEN @FromTime and @ToTime
			or @FromTime BETWEEN wtr.[Begin] and wtr.[End]
			or @ToTime BETWEEN wtr.[Begin] and wtr.[End]
			)
	END
	ELSE
	BEGIN
		SELECT @Result = SUM(t.TimeSum) FROM
		(
			select 
				[dbo].[rpt_GetTimeIntersection](wtr.[Begin], wtr.[End], @FromTime, 24*60) as TimeSum
			from Employee e 
				,WorkingTimeRecording wtr
			where e.employeeid = @EmployeeID
			and wtr.employeeid = e.employeeid

			and (wtr.[End] BETWEEN @FromTime and 24*60
				or wtr.[Begin] BETWEEN @FromTime and 24*60
				or @FromTime BETWEEN wtr.[Begin] and wtr.[End]
				or 24*60 BETWEEN wtr.[Begin] and wtr.[End]
				)
			
			UNION ALL

			select 
				[dbo].[rpt_GetTimeIntersection](wtr.[Begin], wtr.[End], 0*60, @ToTime) as TimeSum
			from Employee e 
				,WorkingTimeRecording wtr
			where e.employeeid = @EmployeeID
			and wtr.employeeid = e.employeeid

			and (wtr.[End] BETWEEN 0*60 and @ToTime
				or wtr.[Begin] BETWEEN 0*60 and @ToTime
				or 0*60 BETWEEN wtr.[Begin] and wtr.[End]
				or @ToTime BETWEEN wtr.[Begin] and wtr.[End]
				)
		) AS t
	END

  SET @Result = ISNULL(@Result, 0);

  RETURN @Result
END;
GO

--SELECT [dbo].[rpt_GetSumWorkedHoursInTimeRange]('CzechMain', 23724, 2007, 12, 22*60, 6*60)
