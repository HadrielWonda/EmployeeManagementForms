print '%Creating procedure% sp_rptStoreGetList'
go

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'sp_rptStoreGetList' 
)
   DROP PROCEDURE sp_rptStoreGetList
GO

CREATE PROCEDURE [dbo].[sp_rptStoreGetList]
	@ReportName nvarchar(30)
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
	  s.StoreID AS StoreID, sn.Name AS Name, c.SystemID2 AS CountryCode
	FROM
	   Store s, StoreName sn, CountryReportingIdentifier cri, Region r, Country c
	WHERE
		sn.StoreID = s.StoreID
	AND sn.LanguageID = 1
	AND cri.ReportName = @ReportName
    AND cri.CountryID = c.CountryID
	AND cri.CountryID = r.CountryID
	AND s.RegionID = r.RegionID
END
GO