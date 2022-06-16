print '%Creating procedure% spStore_LastEmployeeWTRGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_LastEmployeeWTRGet' 
)
   DROP PROCEDURE spStore_LastEmployeeWTRGet
GO

create procedure spStore_LastEmployeeWTRGet
	@StoreID bigint
WITH ENCRYPTION
as
	set nocount on;
	select LastEmployeeWTR from dbo.Store where StoreID = @StoreID

GO
