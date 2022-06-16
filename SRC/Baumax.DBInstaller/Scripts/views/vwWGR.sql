print '%Creating view% vwWGR'
GO
IF object_id(N'dbo.vwWGR', 'V') IS NOT NULL
	DROP VIEW dbo.vwWGR
GO

CREATE VIEW dbo.vwWGR AS
	select w.WGR_ID, SystemID, Import, LanguageID, [Name]
	from dbo.WGR w
	left outer join dbo.WGR_Name wn
	on
		w.WGR_ID = wn.WRG_ID
GO

IF OBJECT_ID ('dbo.vwWGR_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWGR_delete
GO

create trigger dbo.vwWGR_delete on dbo.vwWGR instead of delete as
  set nocount on
  delete from
    dbo.WGR_Name
  where
    (WRG_ID in (select WGR_ID from deleted))
  delete from
    dbo.WGR
  where
    (WGR_ID in (select WGR_ID from deleted))
GO

IF OBJECT_ID ('dbo.vwWGR_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWGR_insert
GO

create trigger dbo.vwWGR_insert on dbo.vwWGR instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.WGR(WGR_ID, SystemID, Import)
	select WGR_ID, SystemID, Import from inserted

	select @newID = wn.Id from dbo.WGR_Name wn 
	inner join inserted i
	on
		wn.WRG_ID = i.WGR_ID 
		and wn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.WGR_Name (Id, WRG_ID, LanguageID, [Name])
		select @newID ,WGR_ID ,[LanguageID] ,[Name] from inserted 
		where not exists(select * from dbo.WGR_Name wn where wn.WRG_ID = inserted.WGR_ID and wn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.WGR_Name	
		set
			[Name] = i.[Name]
		from WGR_Name wn 
		inner join inserted i
		on
			wn.WRG_ID = i.WGR_ID 
			and wn.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwWGR_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWGR_update
GO

create trigger dbo.vwWGR_update on dbo.vwWGR instead of update as
  set nocount on
  update dbo.WGR
	set
      [SystemID] = i.[SystemID]
	  ,[Import] = i.[Import]
	from dbo.WGR w 
	inner join inserted i
	on
		w.WGR_ID = i.WGR_ID

  update dbo.WGR_Name 
	 set
		[Name] = i.[Name]
	from WGR_Name wn 
	inner join inserted i
	on
		wn.WRG_ID = i.WGR_ID
		and wn.LanguageID = i.LanguageID
 
GO
