print '%Creating view% vwStoreStructure'
go

if object_id(N'dbo.vwStoreStructure', 'V') is not null
	drop view dbo.vwStoreStructure
go

create view dbo.vwStoreStructure as
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
	sw.Store_WorldID = world_h.Store_WorldID 
left outer join dbo.HWGR_WGR hwgr_w
on 
	world_h.World_HWGR_ID = hwgr_w.World_HWGR_ID
go