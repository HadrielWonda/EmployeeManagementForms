--statistics and indexes for spBusinessVolume_ConvertData (table BusinessVolumeActual) 
CREATE STATISTICS [Stat_BVA_Converted_Date] ON [dbo].[BusinessVolumeActual]([Converted], [Date])
go

CREATE STATISTICS [Stat_BVA_StoreID_Date] ON [dbo].[BusinessVolumeActual]([StoreID], [Date])
go

CREATE STATISTICS [Stat_BVA_Date_Converted_StoreID] ON [dbo].[BusinessVolumeActual]([Date], [Converted], [StoreID])
go

CREATE STATISTICS [Stat_BVA_Date_WGR_ID_StoreID_Converted] ON [dbo].[BusinessVolumeActual]([Date], [WGR_ID], [StoreID], [Converted])
go

CREATE NONCLUSTERED INDEX [Index_HWGR_WGR__WGR_ID__HWGR_ID__StoreID] ON [dbo].[HWGR_WGR] 
(
	[WGR_ID] ASC,
	[HWGR_ID] ASC,
	[StoreID] ASC
)
INCLUDE ( [BeginTime],
[EndTime]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
go

CREATE STATISTICS [Stat_HWGR_WGR__HWGR_ID_WGR_ID] ON [dbo].[HWGR_WGR]([HWGR_ID], [WGR_ID])
go

CREATE STATISTICS [Stat_HWGR_WGR__StoreID_HWGR_ID_WGR_ID] ON [dbo].[HWGR_WGR]([StoreID], [HWGR_ID], [WGR_ID])
go

CREATE NONCLUSTERED INDEX [Index_World_HWGR__StoreID_HWGR_ID_BeginTime_EndTime__WorldID] ON [dbo].[World_HWGR] 
(
	[StoreID] ASC,
	[HWGR_ID] ASC,
	[BeginTime] ASC,
	[EndTime] ASC
)
INCLUDE ( [WorldID]) WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
go

CREATE STATISTICS [Stat_World_HWGR__BeginTime_EndTime_StoreID] ON [dbo].[World_HWGR]([BeginTime], [EndTime], [StoreID])
go

CREATE STATISTICS [Stat_World_HWGR__HWGR_ID_StoreID_BeginTime_EndTime] ON [dbo].[World_HWGR]([HWGR_ID], [StoreID], [BeginTime], [EndTime])
go
