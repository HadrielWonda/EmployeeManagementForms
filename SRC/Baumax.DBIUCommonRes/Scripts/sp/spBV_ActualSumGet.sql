print '%Creating procedure% spBV_ActualSumGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_ActualSumGet' 
)
   DROP PROCEDURE spBV_ActualSumGet
GO

CREATE PROCEDURE spBV_ActualSumGet
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
	'select StoreID, WorldID, sum (VolumeBC) VolumeBC, sum (VolumeCC) VolumeCC 
		from dbo.BusinessVolumeActual
		where Date between ''' + convert(nvarchar(8),@DateBegin,112)+ ''' and ''' + convert(nvarchar(8),@DateEnd,112) +''''	
	if @WorldID is not null
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)+' and WorldID= '+convert(nvarchar(10),@WorldID)+'
		group by StoreID, WorldID'
	else
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)+'	group by StoreID, WorldID'
		
	exec sp_executesql @SQL	
END
GO
