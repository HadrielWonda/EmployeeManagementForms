print '%Creating function% [rpt_GetTimeIntersection]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[rpt_GetTimeIntersection]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[rpt_GetTimeIntersection]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- requres to be: @BeginTime < @EndTime, @FromTime < @ToTime
CREATE FUNCTION [dbo].[rpt_GetTimeIntersection] (@BeginTime utsMinutes, @EndTime utsMinutes, @FromTime utsMinutes, @ToTime utsMinutes)
RETURNS bigint
WITH EXECUTE AS CALLER, ENCRYPTION
AS
BEGIN
	DECLARE @Result bigint

	IF(@EndTime < @ToTime)
		SET @Result = @EndTime
	ELSE
		SET @Result = @ToTime

	IF(@BeginTime < @FromTime)
		SET @Result = @Result - @FromTime
	ELSE
		SET @Result = @Result - @BeginTime

	RETURN @Result
END
GO
