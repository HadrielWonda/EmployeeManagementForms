print '%Creating function% [rpt_GetSumWorkedHoursOnSaturday]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetSumWorkedHoursOnSaturday]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetSumWorkedHoursOnSaturday]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Sum of worked hours on a Sunday
CREATE FUNCTION [dbo].[rpt_GetSumWorkedHoursOnSaturday] (@ReportName nvarchar(30), @EmployeeID bigint, @YearNum int, @MonthNum int, @StoreID bigint)
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

	SELECT @Result = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW
				 WHERE e.EmployeeID = @EmployeeID 
				   -- assume SET DATEFIRST 1; executed
				   AND DATEPART(weekday, e.Date) = 6
				   AND (e.Date BETWEEN @StartDate AND @LastDate)
				   AND e.Store_WorldID = SW.Store_WorldID
				   AND SW.StoreID = @StoreID
	SET @Result = ISNULL(@Result, 0);

  RETURN @Result
END;
GO