print '%Creating procedure% spStoreStructureGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStoreStructureGet' 
)
   DROP PROCEDURE spStoreStructureGet
GO

CREATE PROCEDURE spStoreStructureGet
	-- Add the parameters for the stored procedure here
	@StoreID bigint,
	@Date smalldatetime
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	select    
		sw.Store_WorldID
		,world_h.World_HWGR_ID
		,hwgr_w.HWGR_WGR_ID
		,sw.StoreID 
		,sw.WorldID
		,world_h.HWGR_ID
		,world_h.BeginTime HWGR_BeginTime
		,world_h.EndTime HWGR_EndTime
		,hwgr_w.WGR_ID
		,hwgr_w.BeginTime WGR_BeginTime
		,hwgr_w.EndTime WGR_EndTime
	from dbo.Store_World sw
	left outer join dbo.World_HWGR world_h
	on 
		sw.StoreID = world_h.StoreID
		and sw.WorldID = world_h.WorldID
		and @Date between world_h.BeginTime and world_h.EndTime
	left outer join dbo.HWGR_WGR hwgr_w
	on 
		world_h.StoreID = hwgr_w.StoreID
		and world_h.HWGR_ID = hwgr_w.HWGR_ID
		and @Date between hwgr_w.BeginTime and hwgr_w.EndTime
	where 
		sw.StoreID = @StoreID
END
GO
