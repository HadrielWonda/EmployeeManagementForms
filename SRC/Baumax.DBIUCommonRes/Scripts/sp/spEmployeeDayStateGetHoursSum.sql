print '%Creating procedure% spEmployeeDayStateGetHoursSum'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeDayStateGetHoursSum' 
)
   DROP PROCEDURE spEmployeeDayStateGetHoursSum
GO

create procedure spEmployeeDayStateGetHoursSum
	@DateBegin smalldatetime
	,@DateEnd smalldatetime
	,@StoreID bigint
	,@TableType tinyint  
WITH ENCRYPTION
as
begin
	set nocount on;
	declare 
		@SQL nvarchar (1000)
		,@TableName nvarchar (100)

	if @TableType = 1 
		set @TableName = 'EmployeeDayStateRecording'
	else
		set @TableName = 'EmployeeDayStatePlanning'

	set @SQL ='select 
		sum (AllreadyPlannedHours) AllreadyPlannedHours
		,sum (WorkingHours) WorkingHours
	from '+@TableName+' eds
	where Date between '''+convert(nvarchar(8),@DateBegin,112)+ ''' and '''+convert(nvarchar(8),@DateEnd,112)+ '''
	and exists (select * from Store_World sw where sw.StoreID = '+convert(nvarchar(20),@StoreID)+' and eds.Store_WorldID = sw.Store_WorldID)'

	exec sp_executesql @SQL
end
GO
