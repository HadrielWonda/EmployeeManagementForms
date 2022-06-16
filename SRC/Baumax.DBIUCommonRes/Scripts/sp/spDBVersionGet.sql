print '%Creating procedure% spDBVersionGet'
go

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDBVersionGet' 
)
   DROP PROCEDURE spDBVersionGet
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		SHDD
-- Create date: 02.03.2007
-- Description:	Get db version
-- =============================================
CREATE PROCEDURE spDBVersionGet
	
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select Version from dbo.dbProperties
END
GO
