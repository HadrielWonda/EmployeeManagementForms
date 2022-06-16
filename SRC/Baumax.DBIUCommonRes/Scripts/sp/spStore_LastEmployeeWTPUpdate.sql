print '%Creating procedure% spStore_LastEmployeeWTPUpdate'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_LastEmployeeWTPUpdate' 
)
   DROP PROCEDURE spStore_LastEmployeeWTPUpdate
GO

create procedure spStore_LastEmployeeWTPUpdate
	@StoreID bigint
	,@LastEmployeeWTP smalldatetime
WITH ENCRYPTION
as
	set nocount on;
	declare @result int
	begin try
		update Store
		set
		  LastEmployeeWTP = @LastEmployeeWTP
		where
			StoreID = @StoreID
		set @result	= 0
	end try
	begin catch
		set @result= -1;
	end catch
	return @result

GO
