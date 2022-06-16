print '%Updating database to version% 0.0.4'
go

alter table dbo.Store add
	LastEmployeeWTR smalldatetime null
go

alter view dbo.vwStore as
	select s.StoreID, s.RegionID, SystemID, Number, City, Address, Area, s.Import, sn.LanguageID, [Name], isnull(c.CountryID,0) CountryID, LastEmployeeWTR
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
go

alter table dbo.LongTimeAbsence add
	Color int not null constraint DF_LongTimeAbsence_Color default 0
go

alter table dbo.Employee add
	OrderHwgrID bigint null,
	WeekState tinyint not null constraint DF_Employee_WeekState default 0
go

ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_HWGR] FOREIGN KEY([OrderHwgrID])
REFERENCES [dbo].[HWGR] ([HWGR_ID])
go

-- add user for scheduler
DECLARE @GlobalAdminRole bigint
SET @GlobalAdminRole = 50 

INSERT INTO [User]
           ([Id]
		   ,[EmployeeID]
           ,[LoginName]
           ,[Password]
           ,[UserRoleID]
           ,[LanguageID]
           ,[Active]
           ,[Salt]
           ,[ShouldChangePassword])
     VALUES
           (72
		   ,NULL
           ,'scheduler'
           ,'JZXlCiGxTy0RAzl8kia0Ng=='
           ,@GlobalAdminRole
           ,NULL
           ,1
           ,-1905021473
           ,0)
go

alter table dbo.BufferHourAvailable add
	SumActualBVEstimated float(53) NULL
go

BEGIN TRANSACTION
GO
ALTER TABLE dbo.BufferHourAvailable
	DROP CONSTRAINT FK_BufferHourAvailable_Store_World
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_BufferHourAvailable
	(
	BufferHourAvailableID bigint NOT NULL IDENTITY (1, 1),
	Store_WorldID bigint NOT NULL,
	Year smallint NOT NULL,
	WeekBegin smalldatetime NOT NULL,
	WeekEnd smalldatetime NOT NULL,
	WeekNumber tinyint NOT NULL,
	AvailableBufferHour float(53) NOT NULL,
	SumFromPlanning float(53) NULL,
	SumFromRecording float(53) NULL,
	SumActualBVEstimated float(53) NULL
	)  ON [PRIMARY]
GO
SET IDENTITY_INSERT dbo.Tmp_BufferHourAvailable ON
GO
IF EXISTS(SELECT * FROM dbo.BufferHourAvailable)
	 EXEC('INSERT INTO dbo.Tmp_BufferHourAvailable (BufferHourAvailableID, Store_WorldID, Year, WeekBegin, WeekEnd, WeekNumber, AvailableBufferHour, SumFromPlanning, SumFromRecording, SumActualBVEstimated)
		SELECT BufferHourAvailableID, Store_WorldID, Year, WeekBegin, WeekEnd, WeekNumber, AvailableBufferHour, SumFromPlanning, SumFromRecording, SumActualBVEstimated FROM dbo.BufferHourAvailable WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_BufferHourAvailable OFF
GO
DROP TABLE dbo.BufferHourAvailable
GO
EXECUTE sp_rename N'dbo.Tmp_BufferHourAvailable', N'BufferHourAvailable', 'OBJECT' 
GO
ALTER TABLE dbo.BufferHourAvailable ADD CONSTRAINT
	PK_BufferHourAvailable PRIMARY KEY CLUSTERED 
	(
	BufferHourAvailableID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.BufferHourAvailable ADD CONSTRAINT
	FK_BufferHourAvailable_Store_World FOREIGN KEY
	(
	Store_WorldID
	) REFERENCES dbo.Store_World
	(
	Store_WorldID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT


exec dbo.spDBVersionSet '0.0.4'
go