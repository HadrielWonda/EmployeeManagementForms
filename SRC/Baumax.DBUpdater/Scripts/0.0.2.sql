print '%Updating database to version% 0.0.2'
go

--spEmlpoyeeDetailGet
print '%Creating procedure% spEmlpoyeeDetailGet'
go
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmlpoyeeDetailGet' 
)
   DROP PROCEDURE spEmlpoyeeDetailGet
GO

CREATE PROCEDURE spEmlpoyeeDetailGet
	@MainStoreID bigint,
	@Date smalldatetime
AS
BEGIN
	SET NOCOUNT ON;
	select 
		e.EmployeeID
		, PersID
		, LastName
		, FirstName
		, ContractBegin	
		, ContractEnd
		, Import
		, MainStoreID
		, ContractWorkingHours
		, OldHolidays
		, NewHolidays
		, BalanceHours
		, CreateDate
		, StoreID
		, WorldID
		, HWGR_ID
		, BeginTime
		, EndTime
		, EmployeeContractID
		, Employee_RelationsID 
	into #Employee
	from dbo.Employee e
	left outer join dbo.Employee_Relations er
	on
		e.EmployeeID = er.EmployeeID
		and er.Employee_RelationsID = (select top 1 Employee_RelationsID from dbo.Employee_Relations err where e.EmployeeID = err.EmployeeID and @Date between err.BeginTime and err.EndTime order by BeginTime desc)
	left outer join EmployeeContract ec
	on
		e.EmployeeID = ec.EmployeeID
		and ec.EmployeeContractID  = (select top 1 EmployeeContractID from dbo.EmployeeContract cc where e.EmployeeID = cc.EmployeeID order by ContractBegin desc)
	where	
		MainStoreID = @MainStoreID
		or er.StoreID= @MainStoreID

	select e.EmployeeID ID, 
			PersID, 
			LastName, 
			FirstName, 
			ContractBegin, 
			ContractEnd, 
			Import, 
			MainStoreID, 
			ContractWorkingHours, 
			OldHolidays, 
			NewHolidays, 
			BalanceHours, 
			CreateDate, 
			EmployeeContractID, 
			Employee_RelationsID as EmployeeRelationsID, 
			StoreID, 
			WorldID, 
			HWGR_ID,
			e.BeginTime,
			e.EndTime
		, case when (a.EmployeeID is not null) then 1 else 0 end LongTimeAbsence
	from #Employee e
	left outer join Employee_LongTimeAbsence a
	on
		e.EmployeeID = a.EmployeeID
		and @Date between a.BeginTime and a.EndTime

drop table #Employee

END
GO
--end spEmlpoyeeDetailGet

--spEmlpoyeeDetailGetByEmpID
print '%Creating procedure% spEmlpoyeeDetailGetByEmpID'
go
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmlpoyeeDetailGetByEmpID' 
)
   DROP PROCEDURE spEmlpoyeeDetailGetByEmpID
GO

CREATE PROCEDURE spEmlpoyeeDetailGetByEmpID
	@EmployeeID bigint,
	@Date smalldatetime
	
AS
BEGIN
	SET NOCOUNT ON;
	select 
		e.EmployeeID
		, PersID
		, LastName
		, FirstName
		, ContractBegin	
		, ContractEnd
		, Import
		, MainStoreID
		, ContractWorkingHours
		, OldHolidays
		, NewHolidays
		, BalanceHours
		, CreateDate
		, StoreID
		, WorldID
		, HWGR_ID
		, BeginTime
		, EndTime
		, EmployeeContractID
		, Employee_RelationsID 
	into #Employee
	from dbo.Employee e
	left outer join dbo.Employee_Relations er
	on
		e.EmployeeID = er.EmployeeID
		and er.Employee_RelationsID = (select top 1 Employee_RelationsID from dbo.Employee_Relations err where e.EmployeeID = err.EmployeeID and @Date between err.BeginTime and err.EndTime order by BeginTime desc)
	left outer join EmployeeContract ec
	on
		e.EmployeeID = ec.EmployeeID
		and ec.EmployeeContractID  = (select top 1 EmployeeContractID from dbo.EmployeeContract cc where e.EmployeeID = cc.EmployeeID order by ContractBegin desc)
	where	
		e.EmployeeID = @EmployeeID

	select e.EmployeeID ID, 
			PersID, 
			LastName, 
			FirstName, 
			ContractBegin, 
			ContractEnd, 
			Import, 
			MainStoreID, 
			ContractWorkingHours, 
			OldHolidays, 
			NewHolidays, 
			BalanceHours, 
			CreateDate, 
			EmployeeContractID, 
			Employee_RelationsID as EmployeeRelationsID, 
			StoreID, 
			WorldID, 
			HWGR_ID,
			e.BeginTime,
			e.EndTime
		, case when (a.EmployeeID is not null) then 1 else 0 end LongTimeAbsence
	from #Employee e
	left outer join Employee_LongTimeAbsence a
	on
		e.EmployeeID = a.EmployeeID
		and @Date between a.BeginTime and a.EndTime

drop table #Employee

END
GO
--end spEmlpoyeeDetailGetByEmpID

--spBusinessVolume_ImportData
print '%Creating procedure% spBusinessVolume_ImportData'
go
-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_ImportData' 
)
   DROP PROCEDURE spBusinessVolume_ImportData
GO

CREATE PROCEDURE spBusinessVolume_ImportData
	@xmlDocument nvarchar(max)
	,@formatFile nvarchar (255)
	,@result int output
AS
BEGIN
	set nocount on;
	set @result = 1;
	begin try
		begin tran
			declare @docHandle int
			declare @datafield nvarchar(255), @SQL nvarchar(4000)
			exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument
			declare data_Cursor cursor for
			select [name] 
			from openxml(@docHandle, N'/Root/File') 
			  with ([name] nvarchar(255))

			open data_Cursor;

			fetch from data_Cursor
			into @datafield
			while (@@fetch_status = 0)
			begin
				set @SQL= 'BULK INSERT dbo.BussinessVolume
				   FROM ''' + @datafield + '''
				   WITH 
					  (
						TABLOCK,
						FORMATFILE = '''+ @formatFile +'''
					  )'
				exec sp_executesql @SQL	
				fetch from data_Cursor
				into @datafield
			end;
			close data_Cursor;
			deallocate data_Cursor;

			exec sp_xml_removedocument @docHandle
		commit 
	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		set @result = -1;
	end catch

END
GO
--end spBusinessVolume_ImportData

--spUIResource_ImportData
print '%Creating procedure% spUIResource_ImportData'
go

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spUIResource_ImportData' 
)
   DROP PROCEDURE spUIResource_ImportData
GO

create procedure spUIResource_ImportData
	@xmlDocument nvarchar(max)
as
begin
	set nocount on;
	declare @docHandle int
	exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument

	insert into dbo.UIResources (ResourceID, LanguageID, Resource)
	select ResourceID, LanguageID, Resource
	from openxml(@docHandle, N'/Root/UIResources') 
	  with UIResources
	exec sp_xml_removedocument @docHandle
end
GO
--end spUIResource_ImportData

--BussinessVolume
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BussinessVolume_WGR]') AND parent_object_id = OBJECT_ID(N'[dbo].[BussinessVolume]'))
ALTER TABLE [dbo].[BussinessVolume] DROP CONSTRAINT [FK_BussinessVolume_WGR]
go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BussinessVolume]') AND type in (N'U'))
DROP TABLE [dbo].[BussinessVolume]
go

print '%Creating table% [BussinessVolume]'
go
CREATE TABLE [dbo].[BussinessVolume](
	[BussinessVolumeID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[StoreID] [bigint] NOT NULL,
	[WGR_ID] [bigint] NOT NULL,
	[VolumeBC] [smallmoney] NOT NULL CONSTRAINT [DF_BussinessVolume_VolumeBC]  DEFAULT ((0)),
	[VolumeCC] [money] NOT NULL CONSTRAINT [DF_BussinessVolume_VolumeCC]  DEFAULT ((0)),
 CONSTRAINT [PK_BussinessVolume] PRIMARY KEY CLUSTERED 
(
	[BussinessVolumeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
go

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BussinessVolume_WGR]') AND parent_object_id = OBJECT_ID(N'[dbo].[BussinessVolume]'))
ALTER TABLE [dbo].[BussinessVolume]  WITH CHECK ADD  CONSTRAINT [FK_BussinessVolume_WGR] FOREIGN KEY([WGR_ID])
REFERENCES [dbo].[WGR] ([WGR_ID])
go
--end BussinessVolume

--LongTimeAbsence
alter table LongTimeAbsence add [CharID] [nvarchar](6) NOT NULL DEFAULT ((''))
go
--end LongTimeAbsence

--Absence
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[Absence]') AND name = N'Index_Absence__CountryCharID')
DROP INDEX [Index_Absence__CountryCharID] ON [dbo].[Absence] WITH ( ONLINE = OFF )
go
alter table Absence alter column [CharID] [nvarchar](6) NOT NULL
go
CREATE UNIQUE NONCLUSTERED INDEX [Index_Absence__CountryCharID] ON [dbo].[Absence] 
(
	[CountryID] ASC,
	[CharID] ASC
) ON [PRIMARY]
go
--end Absence

--WorkingModelName set default language
update WorkingModelName
set
	LanguageID= 1
where 
	LanguageID = 0
--end workingModelName set default language	
go

IF OBJECT_ID ('dbo.vwWorkingModel_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWorkingModel_insert
GO

create trigger dbo.vwWorkingModel_insert on dbo.vwWorkingModel instead of insert as
  set nocount on
	
	declare @newID bigint
	set @newID = -1

	insert into dbo.WorkingModel(WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges)
	select WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges from inserted

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

GO

IF OBJECT_ID ('dbo.vwWorkingModel_update','TR') IS NOT NULL
   DROP TRIGGER dbo.vwWorkingModel_update
GO

create trigger dbo.vwWorkingModel_update on dbo.vwWorkingModel instead of update as
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

GO


exec dbo.spDBVersionSet '0.0.2'
go