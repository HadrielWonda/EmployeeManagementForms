print '%Updating database to version% 0.0.7'
go

alter table dbo.Store add
	LastEmployeeWTP smalldatetime null
go

alter view dbo.vwStore as
	select s.StoreID, s.RegionID, SystemID, Number, City, Address, Area, s.Import, sn.LanguageID, [Name], isnull(c.CountryID,0) CountryID, LastEmployeeWTR, LastEmployeeWTP
	from dbo.Store s
	left outer join dbo.StoreName sn
	on
		s.StoreID = sn.StoreID
	left outer join Region r
	on
		s.RegionID = r.RegionID
	left outer join Country c
	on
		r.CountryID = c.CountryID
go

alter table dbo.Absence add
	IsShow tinyint not null default (1)
go

ALTER TABLE [dbo].[Absence]  WITH CHECK ADD  CONSTRAINT [CT_Absence_IsShowRange] CHECK  (([IsShow]>=(1) AND [IsShow]<=(4)))
go

alter view dbo.vwAbsence AS
	select a.AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, LanguageID, [Name], IsShow
	from dbo.Absence a
	left outer join dbo.AbsenceName an
	on
		a.AbsenceID = an.AbsenceID
go

IF OBJECT_ID ('dbo.vwAbsence_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwAbsence_insert
GO

create trigger dbo.vwAbsence_insert on dbo.vwAbsence instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.Absence(AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, IsShow)
	select AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, IsShow from inserted

	--AbsenceName
	select @newID = an.Id from dbo.AbsenceName an 
	inner join inserted i
	on
		an.AbsenceID = i.AbsenceID 
		and an.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.AbsenceName (Id, AbsenceID, LanguageID, [Name])
		select @newID, AbsenceID, LanguageID, [Name] from inserted 
		where not exists(select * from dbo.AbsenceName an where an.AbsenceID = inserted.AbsenceID and an.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.AbsenceName	
		set
			[Name] = i.[Name]
		from AbsenceName an 
		inner join inserted i
		on
			an.AbsenceID = i.AbsenceID 
			and an.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwAbsence_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwAbsence_update
GO

create trigger dbo.vwAbsence_update on dbo.vwAbsence instead of update as
  set nocount on
  update dbo.Absence
	set
		CountryID = i.CountryID
		,AbsenceTypeID = i.AbsenceTypeID
		,Color = i.Color
		,CharID = i.CharID
		,UseInCalck = i.UseInCalck
		,IsFixed = i.IsFixed
		,[Value] = i.[Value]
		,WithoutFixedTime = i.WithoutFixedTime
		,SystemID = i.SystemID
		,Import = i.Import
		,IsShow = i.IsShow 
	from dbo.Absence a 
	inner join inserted i
	on
		a.AbsenceID = i.AbsenceID

  update dbo.AbsenceName 
	 set
		[Name] = i.[Name]
	from AbsenceName an 
	inner join inserted i
	on
		an.AbsenceID = i.AbsenceID
		and an.LanguageID = i.LanguageID
 
GO

ALTER TABLE dbo.EmployeeHolidaysInfo ADD
	TakenHolidays decimal(6, 2) NOT NULL CONSTRAINT DF_EmployeeHolidaysInfo_TakenHolidays DEFAULT 0,
	PlannedHolidays decimal(6, 2) NOT NULL CONSTRAINT DF_EmployeeHolidaysInfo_PlannedHolidays DEFAULT 0,
	SpareHolidaysExc decimal(6, 2) NOT NULL CONSTRAINT DF_EmployeeHolidaysInfo_SpareHolidaysExc DEFAULT 0,
	SpareHolidaysInc decimal(6, 2) NOT NULL CONSTRAINT DF_EmployeeHolidaysInfo_SpareHolidaysInc DEFAULT 0
GO

delete from dbo.BufferHourAvailable 
where 
BufferHourAvailableID 
not in
(
	select max(BufferHourAvailableID) from dbo.BufferHourAvailable
	group by Store_WorldID, WeekBegin 
)
go

alter table BufferHourAvailable
add constraint [constraint_BufferHourAvailable__Store_WorldIDWeekBegin] unique  nonclustered 
(
	Store_WorldID, WeekBegin
)  on [PRIMARY] 
go

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
--end

exec dbo.spDBVersionSet '0.0.7'
go
