print '%Creating view% vwCountry'
GO

IF object_id(N'dbo.vwCountry', 'V') IS NOT NULL
	DROP VIEW dbo.vwCountry
GO

CREATE VIEW dbo.vwCountry AS
	select c.CountryID, c.SystemID1, c.SystemID2, c.LanguageID CountryLanguage, c.Import, c.WarningDays, c.MaxDays, cn.LanguageID, cn.[Name], isnull(psh.PersShowMode,3) PersShowMode
	from dbo.Country c
	left outer join dbo.CountryName cn
	on
		c.CountryID = cn.CountryID
	left outer join dbo.CountryPersShowMode psh
	on
		c.CountryID = psh.CountryID
GO

IF OBJECT_ID ('dbo.vwCountry_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwCountry_delete
GO

create trigger dbo.vwCountry_delete on dbo.vwCountry instead of delete as
  set nocount on
  delete from
    dbo.CountryName
  where
    (CountryID in (select CountryID from deleted))
  delete from
    dbo.Country
  where
    (CountryID in (select CountryID from deleted))
GO

IF OBJECT_ID ('dbo.vwCountry_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwCountry_insert
GO

create trigger dbo.vwCountry_insert on dbo.vwCountry instead of insert as
  set nocount on
	
	declare @newID bigint
	select  @newID =  Value from dbo.PKGen where DomainName = 'Entities'
	set @newID = @newID + 1
	update PKGen 
	set
		[Value] = @newID
	where
		DomainName = 'Entities'

	insert into dbo.Country(CountryID, SystemID1, SystemID2, LanguageID, Import, WarningDays, MaxDays)
	select CountryID, SystemID1, SystemID2, CountryLanguage, Import, WarningDays, MaxDays from inserted

	insert into dbo.CountryName (Id, CountryID, LanguageID, [Name])
	select @newID, CountryID, LanguageID, [Name] from inserted 
	where not exists(select * from dbo.CountryName cn where cn.CountryID = inserted.CountryID and cn.LanguageID = inserted.LanguageID)
 
GO

IF OBJECT_ID ('dbo.vwCountry_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwCountry_update
GO

create trigger dbo.vwCountry_update on dbo.vwCountry instead of update as
  set nocount on
  update dbo.Country
	set
	  SystemID1= i.SystemID1
	  ,SystemID2= i.SystemID2
	  ,LanguageID= i.CountryLanguage
	  ,Import= i.Import 
	  ,WarningDays = i.WarningDays
	  ,MaxDays = i.MaxDays
	from dbo.Country c 
	inner join inserted i
	on
		c.CountryID = i.CountryID

 update dbo.CountryName 
 set
	[Name] = i.[Name]
	from CountryName cn 
	inner join inserted i
	on
		cn.CountryID = i.CountryID
		and cn.LanguageID = i.LanguageID
 
GO
