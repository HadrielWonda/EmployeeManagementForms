print '%Creating function% [rpt_GetDayType]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetDayType]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetDayType]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- obsolete now
/*
-- returns:
-- 0 = workday
-- 1 = feast
-- 2 = saturday
-- 3 = sunday
CREATE FUNCTION [dbo].[rpt_GetDayType] (@ReportName nvarchar(30), @YearNum int, @MonthNum int, @DayNum int)
RETURNS int
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
	 DECLARE @Result int
	 DECLARE @Date smalldatetime
	 DECLARE @LastDay int
     DECLARE @WeekDay int

	 -- end of month
	 SET @LastDay = DATEPART(day, DATEADD(day, -1, DATEADD(month, 1, CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-1', 20))))

	 IF(@LastDay >= @DayNum)
	 BEGIN
		SET @Date = CONVERT(smalldatetime, CAST(@YearNum AS char(4))+'-'+CAST(@MonthNum AS char(2))+'-'+CAST(@DayNum AS char(2)), 20)
        -- assume SET DATEFIRST 1; executed
        SET @WeekDay = DATEPART(weekday, @Date)
        IF( (@WeekDay = 6) OR (@WeekDay = 7) )
        BEGIN
			SET @Result = @WeekDay - 4
        END
        ELSE
        BEGIN
			SELECT TOP 1 @Result = 1
				FROM Feasts f, CountryReportingIdentifier cri
				WHERE cri.ReportName = @ReportName
				  AND f.CountryID = cri.CountryID
				  AND f.FeastDate = @Date
        END
	 END

     RETURN ISNULL(@Result, 0);
END;
*/
GO