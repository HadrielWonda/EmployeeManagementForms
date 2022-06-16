print '%Creating procedure% spLongTimeAbsence_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spLongTimeAbsence_ImportData' 
)
   DROP PROCEDURE spLongTimeAbsence_ImportData
GO

create procedure spLongTimeAbsence_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	begin try
		begin tran
			set @result = 1;
			declare @ID bigint
			declare @ImportDate smalldatetime, @CountryID bigint
			set @ImportDate = convert(datetime,convert(varchar(12),getdate(), 112),112)

			create table #t1
			(
				Code smallint primary key,
				CodeName nvarchar (30)
			)

			insert into #t1 (Code)
			select distinct Code from dbo.#lta4insert where Code is not null

			update #t1
			set
				CodeName = i.CodeName
			from #t1 t
			inner join dbo.#lta4insert i
			on
				t.Code = i.Code
			
			select top 1 @CountryID = CountryID from Country where SystemID1 in (select AustriaCountryID from dbo.dbProperties )

			insert into dbo.LongTimeAbsence (CountryID, Code, CodeName, Import)
			select @CountryID, Code, CodeName, 1 from #t1 
			where not exists (select * from LongTimeAbsence a where a.Code = #t1.Code)

			insert into dbo.Employee_LongTimeAbsence (EmployeeID, LongTimeAbsenceID, BeginTime, EndTime)
			select e.EmployeeID, a.LongTimeAbsenceID, i.BeginTime, i.EndTime
			from #lta4insert i
			inner join LongTimeAbsence a
			on
				i.Code = a.Code
			inner join Employee e
			on
				i.PersID = e.PersID
			where not exists (select * from Employee_LongTimeAbsence ea where ea.EmployeeID = e.EmployeeID and ea.LongTimeAbsenceID = a.LongTimeAbsenceID and ea.BeginTime = i.BeginTime and ea.EndTime = i.EndTime)

			select PersID, Code, BeginTime, EndTime from dbo.#lta4insert i
			where not exists (select * from Employee e where e.PersID = i.PersID)

			--select * into #lta4insert from #lta4insert	
		commit
		drop table #lta4insert
	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		set @result = -1;
	end catch

end
GO
