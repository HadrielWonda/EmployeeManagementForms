print '%Creating procedure% spStore_LastEmployeeWTPGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_LastEmployeeWTPGet' 
)
   DROP PROCEDURE spStore_LastEmployeeWTPGet
GO

create procedure spStore_LastEmployeeWTPGet
	@StoreID bigint
WITH ENCRYPTION
as
	set nocount on;
	select LastEmployeeWTP from dbo.Store where StoreID = @StoreID

GO
