print '%Updating database to version% 0.0.5'
go

CREATE TABLE [dbo].[DatabaseLog](
	[DatabaseLogID] [int] primary key identity(1,1) NOT NULL,
	[PostTime] [datetime] NOT NULL,
	[DatabaseUser] [sysname]  NOT NULL,
	[Event] [sysname]  NOT NULL,
	[Schema] [sysname]  NULL,
	[Object] [sysname]  NULL,
	[TSQL] [nvarchar](max)  NOT NULL,
	[XmlEvent] [xml] NOT NULL
) ON [PRIMARY]
go

ALTER TABLE dbo.WorkingModel ADD
	WorkingModelType tinyint NOT NULL CONSTRAINT DF_WorkingModel_WorkingModelType DEFAULT 0
go

ALTER TABLE dbo.WorkingModel ADD CONSTRAINT
	CK_WorkingModel_WMTValue CHECK (WorkingModelType between 0 and 1)
go	

alter view dbo.vwWorkingModel AS
	select wm.WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue ,BeginTime, EndTime, AddCharges, wmn.LanguageID, [Name], [Message], UseInRecording, WorkingModelType
	from dbo.WorkingModel wm
	left outer join dbo.WorkingModelName wmn
	on
		wm.WorkingModelID = wmn.WorkingModelID
	left outer join dbo.WorkingModelMessage m
	on
		m.WorkingModelID = wm.WorkingModelID
		and m.LanguageID = wmn.LanguageID
go

alter trigger dbo.vwWorkingModel_insert on dbo.vwWorkingModel instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.WorkingModel(WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges, UseInRecording, WorkingModelType)
	select WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges, UseInRecording, WorkingModelType from inserted

	--WorkingModelName
	select @newID = wmn.Id from dbo.WorkingModelName wmn 
	inner join inserted i
	on
		wmn.WorkingModelID = i.WorkingModelID 
		and wmn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.WorkingModelName (Id, WorkingModelID, LanguageID, [Name])
		select @newID, WorkingModelID, LanguageID, [Name] from inserted 
		where not exists(select * from dbo.WorkingModelName wmn where wmn.WorkingModelID = inserted.WorkingModelID and wmn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.WorkingModelName	
		set
			[Name] = i.[Name]
		from WorkingModelName wmn 
		inner join inserted i
		on
			wmn.WorkingModelID = i.WorkingModelID 
			and wmn.LanguageID = i.LanguageID
	end

	--WorkingModelMessage
	if not exists (select * from dbo.WorkingModelMessage wmn 
				inner join inserted i
				on
					wmn.WorkingModelID = i.WorkingModelID 
					and wmn.LanguageID = i.LanguageID
	)
	begin
		insert into dbo.WorkingModelMessage (WorkingModelID, LanguageID, [Message])
		select WorkingModelID, LanguageID, [Message] from inserted 
	end
	else begin
		update dbo.WorkingModelMessage	
		set
			[Message] = i.[Message]
		from WorkingModelMessage m 
		inner join inserted i
		on
			m.WorkingModelID = i.WorkingModelID 
			and m.LanguageID = i.LanguageID
	end
go

alter trigger dbo.vwWorkingModel_update on dbo.vwWorkingModel instead of update as
  set nocount on
  declare @newID bigint
  set @newID = -1

  update dbo.WorkingModel
	set
      [CountryID] = i.[CountryID]
      ,[Data] = i.[Data]
      ,[ConditionType] = i.[ConditionType]
      ,[MultiplyValue] = i.[MultiplyValue]
      ,[AddValue] = i.[AddValue]
	  ,BeginTime = i.BeginTime
      ,EndTime = i.EndTime
	  ,AddCharges = i.AddCharges
	  ,UseInRecording = i.UseInRecording
	  ,WorkingModelType = i.WorkingModelType
	from dbo.WorkingModel wm 
	inner join inserted i
	on
		wm.WorkingModelID = i.WorkingModelID

	--WorkingModelName
	select @newID = wmn.Id from dbo.WorkingModelName wmn 
	inner join inserted i
	on
		wmn.WorkingModelID = i.WorkingModelID 
		and wmn.LanguageID = i.LanguageID

	if @newID = -1
	begin 
		exec getNewID @newID output
		insert into dbo.WorkingModelName (Id, WorkingModelID, LanguageID, [Name])
		select @newID, WorkingModelID, LanguageID, [Name] from inserted 
		where not exists(select * from dbo.WorkingModelName wmn where wmn.WorkingModelID = inserted.WorkingModelID and wmn.LanguageID = inserted.LanguageID)
	end
	else begin
		update dbo.WorkingModelName	
		set
			[Name] = i.[Name]
		from WorkingModelName wmn 
		inner join inserted i
		on
			wmn.WorkingModelID = i.WorkingModelID 
			and wmn.LanguageID = i.LanguageID
	end
 
	--WorkingModelMessage
	if not exists (select * from dbo.WorkingModelMessage wmn 
				inner join inserted i
				on
					wmn.WorkingModelID = i.WorkingModelID 
					and wmn.LanguageID = i.LanguageID
	)
	begin
		insert into dbo.WorkingModelMessage (WorkingModelID, LanguageID, [Message])
		select WorkingModelID, LanguageID, [Message] from inserted 
	end
	else begin
		update dbo.WorkingModelMessage	
		set
			[Message] = i.[Message]
		from WorkingModelMessage m 
		inner join inserted i
		on
			m.WorkingModelID = i.WorkingModelID 
			and m.LanguageID = i.LanguageID
	end
go

exec dbo.spDBVersionSet '0.0.5'
go