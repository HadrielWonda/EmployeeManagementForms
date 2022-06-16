print '%Creating view% vwHWGR'
GO
IF object_id(N'dbo.vwHWGR', 'V') IS NOT NULL
	DROP VIEW dbo.vwHWGR
GO

CREATE VIEW dbo.vwHWGR AS
	select h.HWGR_ID, SystemID, Import, LanguageID, [Name]
	from dbo.HWGR h
	left outer join dbo.HWGR_Name hn
	on
		h.HWGR_ID = hn.HWGR_ID
GO

IF OBJECT_ID ('dbo.vwHWGR_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwHWGR_delete
GO

create trigger dbo.vwHWGR_delete on dbo.vwHWGR instead of delete as
  set nocount on
  delete from
    dbo.HWGR_Name
  where
    (HWGR_ID in (select HWGR_ID from deleted))
  delete from
    dbo.HWGR
  where
    (HWGR_ID in (select HWGR_ID from deleted))
GO

IF OBJECT_ID ('dbo.vwHWGR_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwHWGR_insert
GO

create trigger dbo.vwHWGR_insert on dbo.vwHWGR instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.HWGR(HWGR_ID, SystemID, Import)
	select HWGR_ID, SystemID, Import from inserted

	select @newID = Id from dbo.HWGR_Name hn 
	inner join inserted i
	on
		hn.HWGR_ID = i.HWGR_ID 
		and hn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.HWGR_Name (Id, HWGR_ID, LanguageID, Name)
		select @newID ,[HWGR_ID] ,[LanguageID] ,[Name] from inserted 
		where not exists(select * from dbo.HWGR_Name hn where hn.HWGR_ID = inserted.HWGR_ID and hn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.HWGR_Name	
		set
			[Name] = i.[Name]
		from HWGR_Name hn 
		inner join inserted i
		on
			hn.HWGR_ID = i.HWGR_ID 
			and hn.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwHWGR_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwHWGR_update
GO

create trigger dbo.vwHWGR_update on dbo.vwHWGR instead of update as
  set nocount on
  update dbo.HWGR
	set
	  [HWGR_ID] = i.[HWGR_ID]
      ,[SystemID] = i.[SystemID]
	  ,Import = i.Import
	from dbo.HWGR h 
	inner join inserted i
	on
		h.HWGR_ID = i.HWGR_ID

  update dbo.HWGR_Name 
	 set
		[Name] = i.[Name]
	from HWGR_Name hn 
	inner join inserted i
	on
		hn.HWGR_ID = i.HWGR_ID
		and hn.LanguageID = i.LanguageID
 
GO
