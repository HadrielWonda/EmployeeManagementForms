print '%Creating function% [rpt_GetAvgDaysInWeek]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetAvgDaysInWeek]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetAvgDaysInWeek]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[rpt_GetAvgDaysInWeek] (@ReportName nvarchar(30), @YearNum int)
RETURNS float
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
        DECLARE @Result float

    IF( (@ReportName = 'CroatianMain') OR (@ReportName = 'SlovenianMain') )
    BEGIN
                SET @Result = 5.0
    END
    ELSE
    BEGIN
                SELECT TOP 1
          @Result = a.DaysCount
          FROM AvgWorkingDaysInWeek a, CountryReportingIdentifier cri
         WHERE cri.ReportName = @ReportName
           AND a.CountryID = cri.CountryID
           AND a.Year = @YearNum
    END

    RETURN ISNULL(@Result, 5.0)
END;
GO

--SET DATEFIRST 1;
--SELECT [dbo].[rpt_GetAvgDaysInWeek]('SlovakMain', 2007)