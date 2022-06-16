print '%Updating database to version% 0.0.8'
go

ALTER TABLE dbo.Absence ADD
	CountAsOneDay bit NOT NULL CONSTRAINT DF_Absence_CountAsOneDay DEFAULT 0
go

alter view dbo.vwAbsence as
	select a.AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, LanguageID, [Name], IsShow, CountAsOneDay
	from dbo.Absence a
	left outer join dbo.AbsenceName an
	on
		a.AbsenceID = an.AbsenceID
GO

IF OBJECT_ID ('dbo.vwAbsence_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwAbsence_insert
GO

create trigger dbo.vwAbsence_insert on dbo.vwAbsence instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.Absence(AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, IsShow, CountAsOneDay)
	select AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, IsShow, CountAsOneDay from inserted

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
		,CountAsOneDay = i.CountAsOneDay
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[HolidaysSum]') AND type in (N'U'))
DROP TABLE [dbo].[HolidaysSum]
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EstWeekWTime]') AND type in (N'U'))
DROP TABLE [dbo].[EstWeekWTime]
go

ALTER TABLE dbo.CountryPersShowMode ADD CONSTRAINT
	FK_CountryPersShowMode_Country FOREIGN KEY
	(
	CountryID
	) REFERENCES dbo.Country
	(
	CountryID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
go

--Store
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Store]') AND name = N'IX_Store__SystemID')
DROP INDEX [IX_Store__SystemID] ON [dbo].[Store] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_Store__SystemID] ON [dbo].[Store] 
(
	[SystemID] ASC
)
go

--Region
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Region]') AND name = N'IX_Region__RegionSysID')
DROP INDEX [IX_Region__RegionSysID] ON [dbo].[Region] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_Region__RegionSysID] ON [dbo].[Region] 
(
	[RegionSysID] ASC
)
go

--Country
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND name = N'IX_Country__SystemID1')
DROP INDEX [IX_Country__SystemID1] ON [dbo].[Country] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_Country__SystemID1] ON [dbo].[Country] 
(
	[SystemID1] ASC
)
go

--HWGR
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[HWGR]') AND name = N'IX_HWGR__SystemID')
DROP INDEX [IX_HWGR__SystemID] ON [dbo].[HWGR] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_HWGR__SystemID] ON [dbo].[HWGR] 
(
	[SystemID] ASC
)
go

--WGR
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[WGR]') AND name = N'IX_WGR__SystemID')
DROP INDEX [IX_WGR__SystemID] ON [dbo].[WGR] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_WGR__SystemID] ON [dbo].[WGR] 
(
	[SystemID] ASC
)
go

--World
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[World]') AND name = N'IX_World__ExSystemID')
DROP INDEX [IX_World__ExSystemID] ON [dbo].[World] WITH ( ONLINE = OFF )
go
CREATE UNIQUE NONCLUSTERED INDEX [IX_World__ExSystemID] ON [dbo].[World] 
(
	[ExSystemID] ASC
)
go

exec dbo.spDBVersionSet '0.0.8'
go
