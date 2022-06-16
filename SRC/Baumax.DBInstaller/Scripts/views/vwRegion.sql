print '%Creating view% vwRegion'
GO

IF object_id(N'dbo.vwRegion', 'V') IS NOT NULL
	DROP VIEW dbo.vwRegion
GO

CREATE VIEW dbo.vwRegion AS
	select r.RegionID, RegionSysID, CountryID, Import, LanguageID, [Name]
	from dbo.Region r
	left outer join dbo.RegionName rn
	on
		r.RegionID = rn.RegionID
GO

IF OBJECT_ID ('dbo.vwRegion_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwRegion_delete
GO

create trigger dbo.vwRegion_delete on dbo.vwRegion instead of delete as
  set nocount on
  delete from
    dbo.RegionName
  where
    (RegionID in (select RegionID from deleted))
  delete from
    dbo.Region
  where
    (RegionID in (select RegionID from deleted))
GO

IF OBJECT_ID ('dbo.vwRegion_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwRegion_insert
GO

create trigger dbo.vwRegion_insert on dbo.vwRegion instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.Region(RegionID, RegionSysID, CountryID, Import)
	select RegionID, RegionSysID, CountryID, Import from inserted

	select @newID = Id from dbo.RegionName rn 
	inner join inserted i
	on
		rn.RegionID = i.RegionID 
		and rn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.RegionName (Id, RegionID, LanguageID, [Name])
		select @newID ,[RegionID] ,[LanguageID] ,[Name] from inserted 
		where not exists(select * from dbo.RegionName rn where rn.RegionID = inserted.RegionID and rn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.RegionName	
		set
			[Name] = i.[Name]
		from RegionName rn 
		inner join inserted i
		on
			rn.RegionID = i.RegionID 
			and rn.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwRegion_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwRegion_update
GO

create trigger dbo.vwRegion_update on dbo.vwRegion instead of update as
  set nocount on
  update dbo.Region
	set
		CountryID = i.CountryID
		,RegionSysID = i.RegionSysID
		,Import = i.Import
	from dbo.Region c 
	inner join inserted i
	on
		c.RegionID = i.RegionID

	 update dbo.RegionName 
	 set
		[Name] = i.[Name]
	from RegionName rn 
	inner join inserted i
	on
		rn.RegionID = i.RegionID
		and rn.LanguageID = i.LanguageID
 
GO
