print '%Updating database to version% 0.0.3'
go
--change EstWorldYearValues
ALTER TABLE EstWorldYearValues ALTER COLUMN [TargNetPerformanceBCBuffH] [decimal](14, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [TargNetPerformanceCCBuffH] [decimal](14, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [TargNetPerformanceBCNoBuffH] [decimal](14, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [TargNetPerformanceCCNoBuffH] [decimal](14, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [BCAWH2] [decimal](11, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [CCAWH2] [decimal](11, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [BCNP2] [decimal](12, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [CCNP2] [decimal](12, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [BCAWH3] [decimal](11, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [CCAWH3] [decimal](11, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [BCNP3] [decimal](12, 4) NULL
ALTER TABLE EstWorldYearValues ALTER COLUMN [CCNP3] [decimal](12, 4) NULL
go

--recalculate begin and end dates and count of weeks in years
update dbo.dbProperties
set
  BusinessValuesBegin= '20031229'
go

update HWGR_WGR
set
  BeginTime = '20031229'
where BeginTime = '20040101'
go

update World_HWGR
set
  BeginTime = '20031229'
where BeginTime = '20040101'
go
  
begin tran
	delete from bauMaxYear	
	create table #Year
	(
		[Year] smallint primary key
	)

	declare @Year smallint

	set @Year= 2000
	while @Year < 2079
	begin
		insert into #Year ([Year])
		values (@Year)
		set @Year= @Year + 1
	end

	set datefirst 1;
	insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
	select 
		Year
		--, datepart(weekday,convert(varchar(4), Year) + '0101') WeeekDay
		,case 
			when datepart(weekday,convert(varchar(4), Year) + '0101')  < 5 then dateadd(day,1-datepart(weekday,convert(varchar(4), Year) + '0101') , convert(varchar(4), Year) + '0101')
			else dateadd(day,8-datepart(weekday,convert(varchar(4), Year) + '0101') , convert(varchar(4), Year) + '0101')
		end BeginDate
		,case 
			when datepart(weekday,convert(varchar(4), Year+1) + '0101')  < 5 then dateadd(day,-datepart(weekday,convert(varchar(4), Year + 1) + '0101') , convert(varchar(4), Year+1) + '0101')
			else dateadd(day,7-datepart(weekday,convert(varchar(4), Year+1) + '0101') , convert(varchar(4), Year+1) + '0101')
		end EndDate
		,case 
			when datepart(weekday,convert(varchar(4), Year) + '0101')  < 5 then 0
			else 1
		end WeeksMinus
		,0
	from #Year

	insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
	values(2079,'20790102', '20790606',	1, datepart(week,'20790606')-1)

	update bauMaxYear
	set
		LastWeekNumber= 
			case
				when datepart(year, EndDate) <= [Year] then datepart(week,EndDate) - WeeksMinus
				else datepart(week,convert(varchar(4), [Year]) + '1231') - WeeksMinus
			end
	from bauMaxYear y

    drop table #Year
commit
go

CREATE TABLE [dbo].[EstUnavoidAddFaktorPerYear](
	[Year] [smallint] NOT NULL,
	[StoreID] [bigint] NULL,
	[WorldID] [bigint] NULL,
	[BCunavoidAddFaktorPerYear] [decimal](14,4) NULL,
	[CCunavoidAddFaktorPerYear] [decimal](14,4) NULL
) ON [PRIMARY]
go


CREATE UNIQUE NONCLUSTERED INDEX [UniqueRec] ON [dbo].[AvgWorkingDaysInWeek] 
(
	[CountryID] ASC,
	[Year] ASC
)
go

CREATE TABLE [dbo].[CashRegisterReceiptConvertError](
	[CashRegisterReceiptConvertErrorID] [int] IDENTITY(1,1) NOT NULL,
	[Date] [smalldatetime] NOT NULL,
	[StoreID] [bigint] NOT NULL,
	[Year] [smallint] NULL,
	[Week] [tinyint] NULL,
	[WeekDay] [tinyint] NULL,
	[Month] [tinyint] NULL,
	[Hour] [tinyint] NOT NULL DEFAULT ((0)),
	[Number] [int] NOT NULL DEFAULT ((0)),
	[Converted] [bit] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_CashRegisterReceiptConvertError] PRIMARY KEY NONCLUSTERED 
(
	[CashRegisterReceiptConvertErrorID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
go

begin tran
	insert into dbo.CashRegisterReceiptConvertError
	(Date, StoreID, Year, Week, WeekDay, Month, Hour, Number, Converted)
	select Date, StoreID, Year, Week, WeekDay, Month, Hour, Number, Converted
	from dbo.CashRegisterReceipt 
	where converted  = 0

	delete
	from  dbo.CashRegisterReceipt
	where converted  = 0  
commit tran
go

ALTER TABLE dbo.BufferHours ADD
	ValueWeek float(53) NOT NULL CONSTRAINT DF_BufferHours_ValueWeek DEFAULT 0

go

ALTER TABLE dbo.BufferHourAvailable ADD
	SumFromPlanning float(53) NULL,
	SumFromRecording float(53) NULL
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmployeeAllIn]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmployeeAllIn](
	[EmployeeAllInID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [bigint] NOT NULL,
	[BeginTime] [smalldatetime] NOT NULL,
	[EndTime] [smalldatetime] NOT NULL,
	[AllIn] [bit] NOT NULL CONSTRAINT [DF_EmployeeAllIn_AllIn]  DEFAULT ((0)),
 CONSTRAINT [PK_EmployeeAllIn] PRIMARY KEY CLUSTERED 
(
	[EmployeeAllInID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
go

IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EmployeeAllIn_Employee]') AND parent_object_id = OBJECT_ID(N'[dbo].[EmployeeAllIn]'))
ALTER TABLE [dbo].[EmployeeAllIn]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeAllIn_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
go

update Employee
set
  BalanceHours = convert(int, BalanceHours*60)
go

declare 
	@BeginTime smalldatetime
	,@EndTime smalldatetime

select top 1 @BeginTime= BusinessValuesBegin, @EndTime= '20790606' from dbo.dbProperties

insert into dbo.EmployeeAllIn (EmployeeID, BeginTime, EndTime, AllIn)
select EmployeeID, @BeginTime, @EndTime, AllIn
from dbo.Employee e
where not exists (select * from dbo.EmployeeAllIn a where e.EmployeeID = a.EmployeeID)
go

create table #t
(
	asID int primary key,
	abr nvarchar(6) collate SQL_Latin1_General_CP1_CI_AS
)
insert into #t (asID,abr)
select 110,	'u'
union all
select 130, 'k'
union all
select 140,	'au'
union all
select 200,	'pfl'
union all
select 210,	'bi'
union all
select 215,	'bs'
union all
select 220,	's'
union all
select 240,	'ab' 
union all
select 260,	'ww'
union all
select 270,	'gb'
union all
select 300,	'tot'
union all
select 310,	'beg'
union all
select 330,	'ehe'

update Absence
set	
	SystemID = t.asID
from Absence a
inner join #t t
on
  a.CharID =  t.abr 
where a.CountryID = 1003

update Absence
set	
	SystemID= convert (int, CharID)
where CountryID = 1003 and SystemID is NULL and isnumeric(CharID) = 1

drop table #t
go

ALTER TABLE UIResources ALTER COLUMN [Resource] [nvarchar](500) NULL
go
--AllIn service
DECLARE 
	@EmployeeAllInSvc bigint
	,@GlobalAdminRole bigint
	,@ControllingRole bigint
	,@CountryAdminRole bigint
	,@RegionAdminRole bigint
	,@StoreAdminRole  bigint

	,@FullAccess int
	,@ReadWriteAccess int
	,@ReadAccess int
	,@WriteAccess int
	,@ImportAccess int
	,@ReadWrite int


SET @GlobalAdminRole = 50
SET @ControllingRole = 51
SET @CountryAdminRole = 52
SET @RegionAdminRole = 53
SET @StoreAdminRole  = 54 

SET @ReadAccess = 1
SET @WriteAccess = 2
SET @ImportAccess  = 4
SET @FullAccess  = @ReadAccess + @WriteAccess + @ImportAccess
SET @ReadWriteAccess = @ReadAccess + @WriteAccess


SET @EmployeeAllInSvc = 46


INSERT INTO [ServiceList]
           ([ServiceListID],[ServiceID],[SeviceName])
     VALUES
           (@EmployeeAllInSvc,'{8287B74B-1B8C-4e07-A0D7-93E791559DBA}','Employee AllIn Management')

INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@GlobalAdminRole, @EmployeeAllInSvc, @FullAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@ControllingRole, @EmployeeAllInSvc, @ReadAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@CountryAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@RegionAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)
INSERT INTO [UserRole_ServiceList]
           ([UserRoleID],[ServiceListID],[Operation])
     VALUES
           (@StoreAdminRole, @EmployeeAllInSvc, @ReadWriteAccess)
go

ALTER TABLE dbo.EstUnavoidAddFaktorPerYear ALTER COLUMN StoreID bigint NULL
ALTER TABLE dbo.EstUnavoidAddFaktorPerYear ALTER COLUMN WorldID bigint NULL

ALTER TABLE dbo.EstWorldWorkingHours ALTER COLUMN StoreID bigint NULL
ALTER TABLE dbo.EstWorldWorkingHours ALTER COLUMN WorldID bigint NULL
go

exec dbo.spDBVersionSet '0.0.3'
go