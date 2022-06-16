print '%Creating function% [rpt_GetSumAbsenceIllness]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetSumAbsenceIllness]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetSumAbsenceIllness]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- obsolete now
/*
-- Sum of absences with illness
CREATE FUNCTION [dbo].[rpt_GetSumAbsenceIllness] (@ReportName nvarchar(30), @EmployeeID bigint, @YearNum int, @MonthNum int, @IncludeWeekends bit, @IncludeFeasts bit)
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

  IF( (@IncludeWeekends = 1) AND (@IncludeFeasts = 1) )
  BEGIN
	  SELECT @Result = SUM(atr.[End] - atr.[Begin])
					 FROM  AbsenceTimeRecording atr, Absence a, CountryReportingIdentifier cri
					 WHERE atr.EmployeeID = @EmployeeID 
					   AND cri.ReportName = @ReportName
					   AND a.CountryID = cri.CountryID
					   AND (atr.Date BETWEEN @StartDate AND @LastDate)
					   AND atr.AbsenceID = a.AbsenceID
					   AND a.AbsenceTypeID = 3
  END
  ELSE
  IF( (@IncludeWeekends = 1) AND (@IncludeFeasts = 0) )
  BEGIN
	  SELECT @Result = SUM(atr.[End] - atr.[Begin])
					 FROM  AbsenceTimeRecording atr, Absence a, CountryReportingIdentifier cri
					 WHERE atr.EmployeeID = @EmployeeID 
					   AND cri.ReportName = @ReportName
					   AND a.CountryID = cri.CountryID
					   AND (atr.Date BETWEEN @StartDate AND @LastDate)
					   AND atr.AbsenceID = a.AbsenceID
					   AND a.AbsenceTypeID = 3
                       -- exclude feasts
                       AND NOT EXISTS (SELECT TOP 1 1 
                                         FROM Feasts f 
                                        WHERE f.CountryID = cri.CountryID
                                          AND f.FeastDate = atr.Date
                                      )
  END
  ELSE
  IF( (@IncludeWeekends = 0) AND (@IncludeFeasts = 1) )
  BEGIN
	  SELECT @Result = SUM(atr.[End] - atr.[Begin])
					 FROM  AbsenceTimeRecording atr, Absence a, CountryReportingIdentifier cri
					 WHERE atr.EmployeeID = @EmployeeID 
					   AND cri.ReportName = @ReportName
					   AND a.CountryID = cri.CountryID
					   AND (atr.Date BETWEEN @StartDate AND @LastDate)
					   AND atr.AbsenceID = a.AbsenceID
					   AND a.AbsenceTypeID = 3
                       -- exclude weekends
                       -- assume SET DATEFIRST 1; was executed!
                       AND( NOT (DATEPART(weekday, atr.Date) IN (6, 7)) )
  END
  ELSE
  IF( (@IncludeWeekends = 0) AND (@IncludeFeasts = 0) )
  BEGIN
	  SELECT @Result = SUM(atr.[End] - atr.[Begin])
					 FROM  AbsenceTimeRecording atr, Absence a, CountryReportingIdentifier cri
					 WHERE atr.EmployeeID = @EmployeeID 
					   AND cri.ReportName = @ReportName
					   AND a.CountryID = cri.CountryID
					   AND (atr.Date BETWEEN @StartDate AND @LastDate)
					   AND atr.AbsenceID = a.AbsenceID
					   AND a.AbsenceTypeID = 3
                       -- exclude weekends
                       -- assume SET DATEFIRST 1; was executed!
                       AND( NOT (DATEPART(WEEKDAY, atr.Date) IN (6, 7)) )
                       -- exclude feasts
                       AND NOT EXISTS (SELECT TOP 1 1 
                                         FROM Feasts f 
                                        WHERE f.CountryID = cri.CountryID
                                          AND f.FeastDate = atr.Date
                                      )
  END

  SET @Result = ISNULL(@Result, 0);

  RETURN @Result
END;
*/
GO
