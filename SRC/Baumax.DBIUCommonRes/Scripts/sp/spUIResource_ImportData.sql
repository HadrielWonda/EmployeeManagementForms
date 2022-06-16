print '%Creating procedure% spUIResource_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spUIResource_ImportData' 
)
   DROP PROCEDURE spUIResource_ImportData
GO

create procedure spUIResource_ImportData
	@xmlDocument nvarchar(max)
WITH ENCRYPTION
as
begin
	set nocount on;
	declare @docHandle int
	exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument

	insert into dbo.UIResources (ResourceID, LanguageID, Resource)
	select ResourceID, LanguageID, Resource
	from openxml(@docHandle, N'/Root/UIResources') 
	  with UIResources
	exec sp_xml_removedocument @docHandle
end
GO
