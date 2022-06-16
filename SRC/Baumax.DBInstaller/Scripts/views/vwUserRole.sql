print '%Creating view% vwUserRole'
GO

IF object_id(N'dbo.vwUserRole', 'V') IS NOT NULL
	DROP VIEW dbo.vwUserRole
GO

CREATE VIEW dbo.vwUserRole AS
	select ur.UserRoleID, LanguageID, [Name]
	from dbo.UserRole ur
	left outer join dbo.UserRoleName urn
	on
		ur.UserRoleID = urn.UserRoleID
GO

IF OBJECT_ID ('dbo.vwUserRole_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwUserRole_delete
GO

create trigger dbo.vwUserRole_delete on dbo.vwUserRole instead of delete as
  set nocount on
  delete from
    dbo.UserRoleName
  where
    (UserRoleID in (select UserRoleID from deleted))
  delete from
    dbo.UserRole
  where
    (UserRoleID in (select UserRoleID from deleted))
GO

IF OBJECT_ID ('dbo.vwUserRole_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwUserRole_insert
GO

create trigger dbo.vwUserRole_insert on dbo.vwUserRole instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.UserRole(UserRoleID)
	select UserRoleID from inserted

	select @newID = urn.Id from dbo.UserRoleName urn 
	inner join inserted i
	on
		urn.UserRoleID = i.UserRoleID 
		and urn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.UserRoleName (Id, UserRoleID, LanguageID, [Name])
		select @newID, UserRoleID, LanguageID, [Name] from inserted 
		where not exists(select * from dbo.UserRoleName urn where urn.UserRoleID = inserted.UserRoleID and urn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.UserRoleName	
		set
			[Name] = i.[Name]
		from UserRoleName urn 
		inner join inserted i
		on
			urn.UserRoleID = i.UserRoleID 
			and urn.LanguageID = i.LanguageID
	end

GO

IF OBJECT_ID ('dbo.vwUserRole_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwUserRole_update
GO

create trigger dbo.vwUserRole_update on dbo.vwUserRole instead of update as
  set nocount on
  update dbo.UserRole
	set
      UserRoleID = i.UserRoleID
	from dbo.UserRole ur 
	inner join inserted i
	on
		ur.UserRoleID = i.UserRoleID

  update dbo.UserRoleName 
	 set
		[Name] = i.[Name]
	from UserRoleName urn 
	inner join inserted i
	on
		urn.UserRoleID = i.UserRoleID
		and urn.LanguageID = i.LanguageID
 
GO
