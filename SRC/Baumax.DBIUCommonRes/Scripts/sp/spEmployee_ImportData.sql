print '%Creating procedure% spEmployee_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployee_ImportData' 
)
   DROP PROCEDURE spEmployee_ImportData
GO

create procedure spEmployee_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	begin try

		begin tran
			set datefirst 1;			
			set @result = 1;

			declare @ID bigint
			declare @ImportDate smalldatetime, @BeginTime smalldatetime, @WeekDay int
			set @ImportDate = convert(datetime,convert(varchar(12),getdate(), 112),112)
			set @WeekDay= datepart (weekday, @ImportDate)

			update #empl4insert
			set
				StoreID = s.StoreID
				,WorldID = w.WorldID
				,HWGR_ID = h.HWGR_ID
				,[exists] = case when (e.EmployeeID is null) then 0 else 1 end
				,EmployeeID = e.EmployeeID
			from #empl4insert i
			left outer join dbo.Store s
			on
				i.Store_SystemID = s.SystemID
			left outer join dbo.HWGR h
			on
				i.HWGR_SystemID = h.SystemID
			left outer join dbo.World w
			on
				i.World_SystemID = w.ExSystemID
			left outer join dbo.Employee e
			on
				i.PersID = e.PersID

			update #empl4insert
			set
				ContractBegin = 
				case
					when (i.ContractBegin > e.ContractLastEnd) then dateadd(day,1,e.ContractLastEnd) --temporary for no contract holes
					else i.ContractBegin
				end,
				ContractChange= 
				case
					when (i.ContractBegin > e.ContractLastEnd) then 3 --new CR for the employee importer #126700
					when (i.ContractBegin <> e.ContractLastBegin) then -1 
					when (i.ContractWorkingHours <> e.ContractLastWorkingHours and @ImportDate between i.ContractBegin and i.ContractEnd) then 1
					when (i.ContractEnd <> e.ContractLastEnd and i.ContractEnd < @ImportDate) then -2
					when (i.ContractEnd <> e.ContractLastEnd) then 2
					else 0
				end
			,AllInChange= case 
				when (i.AllIn <> e.AllIn) then 1
				else 0
			end
			,BalanceHoursChange= case
				when (@WeekDay < 2 or @WeekDay > 5) then 0 --CR #125078
				when (i.BalanceHours <> e.BalanceHours) then 1
				else 0 
			end
			from #empl4insert i 
			inner join dbo.Employee e
			on
				i.PersID = e.PersID
				and e.Import = 1
			where 
			  i.[exists] = 1

--#121090 Comment5
			declare @CountryID bigint
			set @CountryID = dbo.getAustriaCountryID ()
			update #empl4insert
			set
				AllInChange= 0
				,BalanceHoursChange	= 0 --#125078 (only for Austria )
			from #empl4insert i 
			where 
				not exists (select * from vwStore s where s.CountryID = @CountryID and i.StoreID = s.StoreID)
--end #121090 Comment5

			--Add data to Employee	
			update Employee 
			set
				 LastName = i.LastName
				, FirstName = i.FirstName
				, MainStoreID = i.StoreID
				, AvailableHolidays = i.AvailableHolidays
				, BalanceHours = case --CR #125078
					when (@WeekDay < 2 or @WeekDay > 5) then e.BalanceHours
					else i.BalanceHours
				  end
				, PersNumber = i.PersNumber
				, Department = i.Department
				, AllIn = i.AllIn
				, OrderHwgrID = case --CR #126103
					when (OrderHwgrID is null) then i.HWGR_ID
					else OrderHwgrID
				  end
			from Employee e
			inner join #empl4insert i 
			on
				e.PersID = i.PersID

			select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'

			insert into dbo.Employee (EmployeeID, PersID, LastName, FirstName, Import, MainStoreID, CreateDate, AvailableHolidays, BalanceHours, PersNumber, ContractLastBegin, ContractLastEnd, ContractLastWorkingHours, Department, AllIn, OrderHwgrID)
			select 
				@ID+ ROW_NUMBER() over (order by PersID) as EmployeeID
				,PersID, LastName, FirstName, 1 Import, StoreID, @ImportDate, AvailableHolidays, BalanceHours, PersNumber, i.ContractBegin, i.ContractEnd, i.ContractWorkingHours, i.Department, i.AllIn, i.HWGR_ID
			from #empl4insert i
			where 
				not exists (select * from Employee e where i.PersID = e.PersID)

			set @ID = @ID + @@rowcount
			--Add data to EmployeeContract	
			insert into dbo.EmployeeContract (EmployeeID, ContractBegin, ContractEnd, ContractWorkingHours)
			select e.EmployeeID, ContractBegin, ContractEnd, i.ContractWorkingHours
			from  dbo.#empl4insert i 
			inner join dbo.Employee e
			on
				i.PersID = e.PersID
			where i.[exists] = 0 
				or i.ContractChange = 3--new CR for the employee importer #126700

			--Add data to Employee_Relations	
			insert into dbo.Employee_Relations (StoreID, WorldID, HWGR_ID, EmployeeID, BeginTime, EndTime)
			select i.StoreID, i.WorldID, i.HWGR_ID, e.EmployeeID, i.ContractBegin, i.ContractEnd
			from  dbo.#empl4insert i 
			inner join dbo.Employee e
			on
				i.PersID = e.PersID
				and i.StoreID is not null
			where
				i.[exists] = 0 or i.ContractChange = 3--new CR for the employee importer #126700
				or not exists (select * from Employee_Relations er where er.EmployeeID = e.EmployeeID)
			update PKGen 
			set
			  [Value] = @ID
			where DomainName = 'Entities'
				and [Value] <> @ID


			update EmployeeContract
			set 
			  ContractEnd = dateadd(day,-1,@ImportDate)
			from EmployeeContract ec
			inner join #empl4insert i
			on
				i.EmployeeID = ec.EmployeeID
			inner join 
			(
				select EmployeeID, max (ContractEnd) ContractEnd 
				from EmployeeContract ecc
				where EmployeeID in (select EmployeeID from #empl4insert where ContractChange = 1)
				group by EmployeeID
			) t
			on
				t.EmployeeID = ec.EmployeeID
				and t.ContractEnd = ec.ContractEnd
			where i.ContractChange = 1 --and ec.ContractEnd > i.ContractEnd


			update EmployeeContract
			set 
			  ContractEnd = i.ContractEnd
			from EmployeeContract ec
			inner join #empl4insert i
			on
				i.EmployeeID = ec.EmployeeID
			inner join 
			(
				select EmployeeID, max (ContractEnd) ContractEnd 
				from EmployeeContract ecc
				where EmployeeID in (select EmployeeID from #empl4insert where ContractChange = 2)
				group by EmployeeID
			) t
			on
				t.EmployeeID = ec.EmployeeID
				and t.ContractEnd = ec.ContractEnd
			where i.ContractChange = 2

			insert into dbo.EmployeeContract (EmployeeID, ContractBegin, ContractEnd, ContractWorkingHours)
			select i.EmployeeID, @ImportDate, i.ContractEnd, i.ContractWorkingHours
			from  #empl4insert i 
			where i.ContractChange = 1 

			delete from EmployeeContract where ContractEnd < ContractBegin

			delete from Employee_Relations 
			from Employee_Relations er
			inner join #empl4insert i
			on
			  er.EmployeeID = i.EmployeeID
			where 
			  i.ContractChange > 0 and er.BeginTime > i.ContractEnd

			update Employee_Relations
			set
			  EndTime = i.ContractEnd
			from Employee_Relations er
			inner join 
			(
			  select EmployeeID, max (EndTime) EndTime from dbo.Employee_Relations
			  where EmployeeID in (select EmployeeID from #empl4insert where ContractChange > 0)
			  group by EmployeeID
			) t
			on
			  er.EmployeeID = t.EmployeeID
			  and er.EndTime= t.EndTime
			inner join #empl4insert i
			on
			  er.EmployeeID = i.EmployeeID
			where 
			  i.ContractChange > 0 


			update Employee
			set
				ContractLastBegin = ContractBegin
				,ContractLastEnd = ContractEnd
				,ContractLastWorkingHours =ContractWorkingHours
			from Employee e
			inner join #empl4insert i
			on
			  i.EmployeeID = e.EmployeeID
			where 
			  i.ContractChange > 0

--AllIn
			select top 1 @BeginTime= BusinessValuesBegin from dbo.dbProperties

			insert into dbo.EmployeeAllIn 
			(EmployeeID, BeginTime, EndTime, AllIn)
			select e.EmployeeID, @BeginTime, '20790606', i.AllIn 
			from  dbo.#empl4insert i 
			inner join dbo.Employee e
			on
				i.PersID = e.PersID
			where i.[exists] = 0

			create table #eAllIn
			(
				EmployeeID bigint primary key,
				BeginTime smalldatetime not null,
				ChangeMode tinyint
			)

			insert into #eAllIn (EmployeeID, BeginTime, ChangeMode)

			select 
				EmployeeID, max (BeginTime) BeginTime,
				case 
					when @ImportDate > max (BeginTime) then 1
					when @ImportDate = max (BeginTime) then 2
					else 0
				end 
			from EmployeeAllIn a
			where EmployeeID in (select EmployeeID from #empl4insert  i where AllInChange = 1)
			group by EmployeeID

			update dbo.EmployeeAllIn
			set
				EndTime = dateadd (day,-1,@ImportDate)
			from dbo.EmployeeAllIn a
			inner join #eAllIn t
			on
			  a.EmployeeID = t.EmployeeID
			  and a.BeginTime = t.BeginTime
			where t.ChangeMode = 1

			insert into dbo.EmployeeAllIn 
			(EmployeeID, BeginTime, EndTime, AllIn)
			select t.EmployeeID, @ImportDate, '20790606', i.AllIn 
			from #eAllIn t
			inner join #empl4insert i 
			on
			  t.EmployeeID = i.EmployeeID
			where t.ChangeMode = 1


			update dbo.EmployeeAllIn
			set
				AllIn = ~AllIn
			from dbo.EmployeeAllIn a
			inner join #eAllIn t
			on
			  a.EmployeeID = t.EmployeeID
			  and a.BeginTime = t.BeginTime
			where t.ChangeMode = 2

			drop table #eAllIn


		commit

--		truncate table empl4insert
--		insert into dbo.empl4insert
--		(Store_SystemID, HWGR_SystemID, World_SystemID, PersNumber, FirstName, LastName, PersID, ContractBegin, ContractEnd, StoreID, WorldID, HWGR_ID, ContractWorkingHours, AvailableHolidays, BalanceHours, [exists], ContractChange, EmployeeID, Department, AllIn, AllInChange, BalanceHoursChange)
--		select Store_SystemID, HWGR_SystemID, World_SystemID, PersNumber, FirstName, LastName, PersID, ContractBegin, ContractEnd, StoreID, WorldID, HWGR_ID, ContractWorkingHours, AvailableHolidays, BalanceHours, [exists], ContractChange, EmployeeID, Department, AllIn, AllInChange, BalanceHoursChange 
--		from #empl4insert	

		select 
			PersID
			,case
				when StoreID is null then 0
				else ContractChange
			 end Result
		from #empl4insert 
		where StoreID is null or ContractChange < 0

		select 
			EmployeeID
			,case
				when ContractChange > 0  then convert(smallint,1)
				else convert(smallint,0)
			 end ContractChange
			,BalanceHoursChange
			,AllInChange
		from #empl4insert
		where ContractChange > 0 or BalanceHoursChange  = 1 or AllInChange = 1		

		drop table #empl4insert
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
