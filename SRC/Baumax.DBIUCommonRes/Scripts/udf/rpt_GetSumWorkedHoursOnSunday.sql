print '%Creating function% [rpt_GetSumWorkedHoursOnSunday]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetSumWorkedHoursOnSunday]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetSumWorkedHoursOnSunday]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sum of worked hours on a Sunday
CREATE FUNCTION [dbo].[rpt_GetSumWorkedHoursOnSunday] 
	(@ReportName nvarchar(30), 
	@EmployeeID bigint, 
	@YearNum int, 
	@MonthNum int, 
	@StoreID bigint,
	@IncludeFeasts bit)
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

  IF(@IncludeFeasts = 1)
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW
				 WHERE e.EmployeeID = @EmployeeID 
				   -- assume SET DATEFIRST 1; executed
				   AND DATEPART(weekday, e.Date) = 7
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
  END
  ELSE
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW
				 WHERE e.EmployeeID = @EmployeeID 
				   -- assume SET DATEFIRST 1; executed
				   AND DATEPART(weekday, e.Date) = 7
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
				   AND NOT EXISTS (SELECT TOP 1 1
									 FROM Feasts f, CountryReportingIdentifier cri
									WHERE cri.ReportName = @ReportName
									  AND f.CountryID = cri.CountryID
									  AND f.FeastDate = e.Date)
  END

  RETURN ISNULL(@Result, 0);
END;
GO