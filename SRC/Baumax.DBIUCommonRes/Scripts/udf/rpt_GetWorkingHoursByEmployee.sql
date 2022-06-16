print '%Creating function% [rpt_GetWorkingHoursByEmployee]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetWorkingHoursByEmployee]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetWorkingHoursByEmployee]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- obsolete now
/*
CREATE FUNCTION [dbo].[rpt_GetWorkingHoursByEmployee] (@EmployeeID bigint, @YearNum int, @MonthNum int, @DayNum int, @StoreID bigint)
RETURNS int
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
     DECLARE @Hours int
	 DECLARE @Date smalldatetime
     DECLARE @LastDay int
	
     -- last day number of month
	 SET @LastDay = DATEPART(day, DATEADD(day, -1, DATEADD(month, 1, CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20))))
     IF(@LastDay >= @DayNum)
     BEGIN
       SET @Date = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-'+CAST(@DayNum AS char(2)), 20)
       SELECT @Hours = SUM(e.WorkingHours)
				 FROM  EmployeeDayStateRecording e, Store_World SW
				 WHERE e.EmployeeID = @EmployeeID 
			       AND e.Date = @Date
				   AND e.Store_WorldID = SW.Store_WorldID
                   AND SW.StoreID = @StoreID
     END

     RETURN ISNULL(@Hours, 0)
END;*/
GO