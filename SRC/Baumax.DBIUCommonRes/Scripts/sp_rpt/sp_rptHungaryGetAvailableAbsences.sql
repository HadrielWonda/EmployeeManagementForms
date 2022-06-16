print '%Creating procedure% sp_rptHungaryGetAvailableAbsences'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_rptHungaryGetAvailableAbsences]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[sp_rptHungaryGetAvailableAbsences]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_rptHungaryGetAvailableAbsences]
	@ReportName nvarchar(30)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
    SET DATEFIRST 1; -- week begins from monday

	-- general absences
   	SELECT 
		 a.SystemID AS AbsenceTypeID
		,a.CharID AS AbsenceCharID
		,an.Name AS AbsenceName
	FROM
		 Absence a
		,AbsenceName an
        ,CountryReportingIdentifier cri
	WHERE an.AbsenceID = a.AbsenceID
	  AND cri.CountryID = a.CountryID
	  AND cri.ReportName = @ReportName

	UNION ALL

	-- long time absences
	SELECT
		 CAST(a.Code AS INT) AS AbsenceTypeID
		,a.CharID AS AbsenceCharID
		,a.CodeName AS AbsenceName
	FROM
		 LongTimeAbsence a
        ,CountryReportingIdentifier cri
	WHERE cri.CountryID = a.CountryID
	  AND cri.ReportName = @ReportName
END
GO