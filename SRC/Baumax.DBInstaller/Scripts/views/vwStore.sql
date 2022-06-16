print '%Creating view% vwStore'
GO

IF object_id(N'dbo.vwStore', 'V') IS NOT NULL
	DROP VIEW dbo.vwStore
GO

CREATE VIEW dbo.vwStore AS
/*
	select s.StoreID, RegionID, SystemID, Number, City, Address, Area, Import, LanguageID, [Name]
	from dbo.Store s
	left outer join dbo.StoreName sn
	on
		s.StoreID = sn.StoreID
*/
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
GO

IF OBJECT_ID ('dbo.vwStore_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwStore_delete
GO

create trigger dbo.vwStore_delete on dbo.vwStore instead of delete as
  set nocount on
  delete from
    dbo.StoreName
  where
    (StoreID in (select StoreID from deleted))
  delete from
    dbo.Store
  where
    (StoreID in (select StoreID from deleted))
GO

IF OBJECT_ID ('dbo.vwStore_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwStore_insert
GO

create trigger dbo.vwStore_insert on dbo.vwStore instead of insert as
  set nocount on
	
	declare @newID bigint
	select  @newID =  Value from dbo.PKGen where DomainName = 'Entities'
	set @newID = @newID + 1
	update PKGen 
	set
		[Value] = @newID
	where
		DomainName = 'Entities'

	insert into dbo.Store(StoreID, RegionID, SystemID, Number, City, Address, Area, Import)
	select StoreID, RegionID, SystemID, Number, City, Address, Area, Import from inserted

	insert into dbo.StoreName (Id, StoreID, LanguageID, [Name])
	select @newID ,[StoreID] ,[LanguageID] ,[Name] from inserted 
	where not exists(select * from dbo.StoreName sn where sn.StoreID = inserted.StoreID and sn.LanguageID = inserted.LanguageID)
GO

IF OBJECT_ID ('dbo.vwStore_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwStore_update
GO

create trigger dbo.vwStore_update on dbo.vwStore instead of update as
  set nocount on
  update dbo.Store
	set
      [RegionID] = i.[RegionID]
      ,[SystemID] = i.[SystemID]
      ,[Number] = i.[Number]
      ,[City] = i.[City]
      ,[Address] = i.[Address]
      ,[Area] = i.[Area]
	  ,Import = i.Import
	from dbo.Store c 
	inner join inserted i
	on
		c.StoreID = i.StoreID

 update dbo.StoreName 
 set
	[Name] = i.[Name]
	from StoreName sn 
	inner join inserted i
	on
		sn.StoreID = i.StoreID
		and sn.LanguageID = i.LanguageID
 
GO
