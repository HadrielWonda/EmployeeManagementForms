print '%Creating procedure% spEmlpoyeeDetailGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmlpoyeeDetailGet' 
)
   DROP PROCEDURE spEmlpoyeeDetailGet
GO

CREATE PROCEDURE spEmlpoyeeDetailGet
	-- Add the parameters for the stored procedure here
	@MainStoreID bigint,
	@Date smalldatetime
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	select 
		e.EmployeeID
		, PersID
		, PersNumber
		, LastName
		, FirstName
		, isnull(ec.ContractBegin, e.ContractLastBegin) ContractBegin --#122739
		, isnull(ec.ContractEnd, e.ContractLastEnd) ContractEnd --#122739
		, Import
		, MainStoreID
		, ec.ContractWorkingHours
		, OldHolidays
		, NewHolidays
		, BalanceHours
		, CreateDate
		, StoreID
		, WorldID
		, HWGR_ID
		, er.BeginTime
		, er.EndTime
		, EmployeeContractID
		, Employee_RelationsID
		, isnull(ai.AllIn, 0) AllIn 
		, e.AvailableHolidays 
		, e.OrderHwgrID
		, e.WeekState
	into #Employee
	from dbo.Employee e
	left outer join dbo.Employee_Relations er
	on
		e.EmployeeID = er.EmployeeID
		and er.Employee_RelationsID = (select top 1 Employee_RelationsID from dbo.Employee_Relations err where e.EmployeeID = err.EmployeeID and @Date between err.BeginTime and err.EndTime order by BeginTime desc)
	left outer join EmployeeContract ec
	on
		e.EmployeeID = ec.EmployeeID
		and ec.EmployeeContractID  = (select top 1 EmployeeContractID from dbo.EmployeeContract cc where e.EmployeeID = cc.EmployeeID and @Date between cc.ContractBegin and cc.ContractEnd order by ContractBegin desc)
	left outer join EmployeeAllIn ai
	on
		e.EmployeeID = ai.EmployeeID
		and ai.EmployeeAllInID  = (select top 1 EmployeeAllInID from dbo.EmployeeAllIn aii where aii.EmployeeID = e.EmployeeID and @Date between aii.BeginTime and aii.EndTime order by BeginTime desc)
	where	
		MainStoreID = @MainStoreID
		or er.StoreID= @MainStoreID

	select e.EmployeeID ID, 
			PersID, 
   		    PersNumber,
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
			, case when (a.EmployeeID is not null) then 1 else 0 end LongTimeAbsenceExist
			, e.AllIn
			, e.AvailableHolidays 
			, e.OrderHwgrID
			, e.WeekState
	from #Employee e
	left outer join Employee_LongTimeAbsence a
	on
		e.EmployeeID = a.EmployeeID
		and @Date between a.BeginTime and a.EndTime

drop table #Employee

END
GO
