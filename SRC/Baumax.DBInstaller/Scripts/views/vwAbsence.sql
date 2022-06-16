print '%Creating view% vwAbsence'
GO

IF object_id(N'dbo.vwAbsence', 'V') IS NOT NULL
	DROP VIEW dbo.vwAbsence
GO

CREATE VIEW dbo.vwAbsence AS
	select a.AbsenceID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, [Value], WithoutFixedTime, SystemID, Import, LanguageID, [Name], IsShow, CountAsOneDay
	from dbo.Absence a
	left outer join dbo.AbsenceName an
	on
		a.AbsenceID = an.AbsenceID
GO

IF OBJECT_ID ('dbo.vwAbsence_delete','TR') IS NOT NULL
   DROP TRIGGER dbo.vwAbsence_delete
GO

create trigger dbo.vwAbsence_delete on dbo.vwAbsence instead of delete as
  set nocount on
  delete from
    dbo.AbsenceName
  where
    (AbsenceID in (select AbsenceID from deleted))

  delete from
    dbo.Absence
  where
    (AbsenceID in (select AbsenceID from deleted))
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
