print '%Creating function% [getAustriaCountryID]'
go
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[getAustriaCountryID]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[getAustriaCountryID]
GO

CREATE FUNCTION getAustriaCountryID 
(
)
RETURNS bigint
WITH ENCRYPTION
AS
BEGIN
	declare @CountryID bigint 
	select top 1 @CountryID= CountryID from Country where SystemID1 in (select AustriaCountryID from dbo.dbProperties )
	RETURN @CountryID
END
GO

