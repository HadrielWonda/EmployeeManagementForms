print '%Creating procedure% spBV_ActualDataExists'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_ActualDataExists' 
)
   DROP PROCEDURE spBV_ActualDataExists
GO

create procedure spBV_ActualDataExists
	@DateBegin smalldatetime
	,@StoreID bigint
	,@WorldID bigint = null
WITH ENCRYPTION
as
begin
	set nocount on;

	declare 
		@SQL nvarchar (1000)


	set @SQL = 'if exists (select * from dbo.BusinessVolumeActual where Date >= '''+convert(nvarchar(8),@DateBegin,112)+ ''' and StoreID = ' + convert(nvarchar(20),@StoreID) 
	if @WorldID is not null
	begin
		set @SQL = @SQL + ' and WorldID =  '+ convert(nvarchar(20),@WorldID) 
	end
	set @SQL = @SQL +')
		select 1 result
	else 
		select 0 result'

	exec sp_executesql @SQL

end
GO
