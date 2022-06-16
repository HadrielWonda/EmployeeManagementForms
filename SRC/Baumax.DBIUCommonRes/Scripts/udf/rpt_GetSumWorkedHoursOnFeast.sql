print '%Creating function% [rpt_GetSumWorkedHoursOnFeast]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetSumWorkedHoursOnFeast]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetSumWorkedHoursOnFeast]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sum of worked hours on a Feasts
CREATE FUNCTION [dbo].[rpt_GetSumWorkedHoursOnFeast] 
	(@ReportName nvarchar(30), 
	@EmployeeID bigint, 
	@YearNum int, 
	@MonthNum int, 
	@StoreID bigint,
	@IncludeSaturdays bit,
	@IncludeSundays bit)
RETURNS bigint
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
  -- assume SET DATEFIRST 1; executed

  DECLARE @Result bigint
  DECLARE @StartDate smalldatetime
  DECLARE @LastDate smalldatetime

  SET @StartDate = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20)
  -- end of month
  SET @LastDate = DATEADD(day, -1, DATEADD(month, 1, @StartDate))

  IF( (@IncludeSaturdays = 0) AND (@IncludeSundays = 0) )
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW, Feasts f, CountryReportingIdentifier cri
				 WHERE e.EmployeeID = @EmployeeID 
				   AND cri.ReportName = @ReportName
				   AND f.CountryID = cri.CountryID
				   AND e.Date = f.FeastDate
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
				   AND (NOT ( DATEPART(weekday, e.Date) IN (6,7) ))
  END
  ELSE
  IF( (@IncludeSaturdays = 0) AND (@IncludeSundays = 1) )
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW, Feasts f, CountryReportingIdentifier cri
				 WHERE e.EmployeeID = @EmployeeID 
				   AND cri.ReportName = @ReportName
				   AND f.CountryID = cri.CountryID
				   AND e.Date = f.FeastDate
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
				   AND (NOT ( DATEPART(weekday, e.Date) = 6 ))
  END
  ELSE
  IF( (@IncludeSaturdays = 1) AND (@IncludeSundays = 0) )
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW, Feasts f, CountryReportingIdentifier cri
				 WHERE e.EmployeeID = @EmployeeID 
				   AND cri.ReportName = @ReportName
				   AND f.CountryID = cri.CountryID
				   AND e.Date = f.FeastDate
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
				   AND (NOT ( DATEPART(weekday, e.Date) = 7 ))
  END
  ELSE
  IF( (@IncludeSaturdays = 1) AND (@IncludeSundays = 1) )
  BEGIN
	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW, Feasts f, CountryReportingIdentifier cri
				 WHERE e.EmployeeID = @EmployeeID 
				   AND cri.ReportName = @ReportName
				   AND f.CountryID = cri.CountryID
				   AND e.Date = f.FeastDate
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
  END

  RETURN ISNULL(@Result, 0);
END;
GO