print '%Creating procedure% spStore_WorldDetailGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_WorldDetailGet' 
)
   DROP PROCEDURE spStore_WorldDetailGet
GO

CREATE PROCEDURE spStore_WorldDetailGet
	-- Add the parameters for the stored procedure here
	@Year smallint,
	@StoreID bigint,
	@Store_WorldID bigint
	
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
DECLARE @SQL nvarchar(4000)
SET @SQL = '	
	SELECT     
		sw.Store_WorldID, 
		sw.StoreID, 
		bh.Value BufferHoursValue, 
		b.Value BenchmarkValue
		,ewy.BCAWH3 AvailableWorkTimeHours
		,ewy.BCAWH3 BusinessVolumeHours -- - (Currently available buffer-hours)
		,ewy.CVolumeBC TargetedBusinessVolume
		,ewy.BCNP3 NetBusinessVolume1
		,convert(decimal(12,4),ewy.BCNP3 - isnull(bh.Value,0)) NetBusinessVolume2
	FROM   dbo.Store_World  sw
	left outer join dbo.Benchmark b
	ON 
	  sw.Store_WorldID = b.Store_WorldID 
	  and b.[Year] = '+ cast ( @Year as nvarchar(4) )+'
	left outer join dbo.BufferHours bh
	ON 
	  sw.Store_WorldID = bh.Store_WorldID
	  and bh.[Year] = '+ cast ( @Year as nvarchar(4) )+'
	left outer join dbo.EstWorldYearValues ewy
	on
	  ewy.StoreID = sw.StoreID
	  and ewy.WorldID = sw.WorldID
	  and ewy.[Year] = '+ cast ( @Year as nvarchar(4) )


if @Store_WorldID >= 0 
begin
	set @SQL = @SQL + ' where sw.Store_WorldID = ' + cast ( @Store_WorldID as nvarchar(10) );
end

if @StoreID >= 0 
begin
	if @Store_WorldID >= 0 
		set @SQL = @SQL + ' and sw.StoreID = ' + cast ( @StoreID as varchar(10) );
	else
		set @SQL = @SQL + ' where sw.StoreID = ' + cast ( @StoreID as varchar(10) );
end

exec sp_executesql @SQL	

END
GO
