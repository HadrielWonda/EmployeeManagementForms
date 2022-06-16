print '%Creating view% vwWorld'
GO

IF object_id(N'dbo.vwWorld', 'V') IS NOT NULL
	DROP VIEW dbo.vwWorld
GO

CREATE VIEW dbo.vwWorld AS
	select w.WorldID, ExSystemID, WorldTypeID, Import, LanguageID, [Name]
	from dbo.World w
	left outer join dbo.WorldName wn
	on
		w.WorldID = wn.WorldID
GO

IF OBJECT_ID ('dbo.vwWorld_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWorld_delete
GO

create trigger dbo.vwWorld_delete on dbo.vwWorld instead of delete as
  set nocount on
  delete from
    dbo.WorldName
  where
    (WorldID in (select WorldID from deleted))
  delete from
    dbo.World
  where
    (WorldID in (select WorldID from deleted))
GO

IF OBJECT_ID ('dbo.vwWorld_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWorld_insert
GO

create trigger dbo.vwWorld_insert on dbo.vwWorld instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.World(WorldID, ExSystemID, WorldTypeID, Import)
	select WorldID, ExSystemID, WorldTypeID, Import from inserted

	select @newID = wn.WorldID from dbo.WorldName wn 
	inner join inserted i
	on
		wn.WorldID = i.WorldID 
		and wn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.WorldName (Id, WorldID, LanguageID, [Name])
		select @newID ,[WorldID] ,[LanguageID] ,[Name] from inserted 
		where not exists(select * from dbo.WorldName wn where wn.WorldID = inserted.WorldID and wn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.WorldName	
		set
			[Name] = i.[Name]
		from WorldName wn 
		inner join inserted i
		on
			wn.WorldID = i.WorldID 
			and wn.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwWorld_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWorld_update
GO

create trigger dbo.vwWorld_update on dbo.vwWorld instead of update as
  set nocount on
  update dbo.World
	set
		ExSystemID = i.ExSystemID
		,WorldTypeID = i.WorldTypeID
		,Import = i.Import
	from dbo.World w 
	inner join inserted i
	on
		w.WorldID = i.WorldID

  update dbo.WorldName 
	 set
		[Name] = i.[Name]
	from WorldName wn 
	inner join inserted i
	on
		wn.WorldID = i.WorldID
		and wn.LanguageID = i.LanguageID
 
GO
