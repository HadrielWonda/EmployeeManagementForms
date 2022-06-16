print '%Creating procedure% spStore_LastEmployeeWTRUpdate'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_LastEmployeeWTRUpdate' 
)
   DROP PROCEDURE spStore_LastEmployeeWTRUpdate
GO

create procedure spStore_LastEmployeeWTRUpdate
	@StoreID bigint
	,@LastEmployeeWTR smalldatetime
WITH ENCRYPTION
as
	set nocount on;
	declare @result int
	begin try
		update Store
		set
		  LastEmployeeWTR = @LastEmployeeWTR
		where
			StoreID = @StoreID
		set @result	= 0
	end try
	begin catch
		set @result= -1;
	end catch
	return @result

GO
