print '%Creating procedure% spDBVersionSet'
go

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spDBVersionSet' 
)
   DROP PROCEDURE spDBVersionSet
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: SHDD		
-- Create date: 02.03.2007
-- Description:	Set db version
-- =============================================
CREATE PROCEDURE spDBVersionSet 
	@Version nvarchar (250)
WITH ENCRYPTION
AS
begin
declare
  @rows int;
	set nocount on;
	
	select @rows= count (*) from dbo.dbProperties
	if (@rows = 0) 
	begin
		insert into dbo.dbProperties (Version)
			values (@Version)
	end
	else begin
		update dbo.dbProperties
		set
			Version= @Version
	end
	
end
GO
