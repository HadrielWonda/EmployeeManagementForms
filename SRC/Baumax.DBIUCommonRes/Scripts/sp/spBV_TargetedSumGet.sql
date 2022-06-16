print '%Creating procedure% spBV_TargetedSumGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_TargetedSumGet' 
)
   DROP PROCEDURE spBV_TargetedSumGet
GO

CREATE PROCEDURE spBV_TargetedSumGet
	@DateBegin smalldatetime
	,@DateEnd smalldatetime
	,@StoreID bigint 
	,@WorldID bigint = null
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare @SQL nvarchar(4000)

	set @SQL= 
	'select StoreID, WorldID, sum (CVolumeBC) VolumeBC , sum (CVolumeCC) VolumeCC
		from dbo.EstWorldWorkingHours
		where Date between ''' + convert(nvarchar(8),@DateBegin,112)+ ''' and ''' + convert(nvarchar(8),@DateEnd,112) +''''	
	if @WorldID is not null
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)+' and WorldID= '+convert(nvarchar(10),@WorldID)+'
		group by StoreID, WorldID'
	else
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)+'	group by StoreID, WorldID'
		
	exec sp_executesql @SQL	
END
GO
