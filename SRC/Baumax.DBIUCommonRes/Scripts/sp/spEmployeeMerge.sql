print '%Creating procedure% spEmployeeMerge'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeMerge' 
)
   DROP PROCEDURE spEmployeeMerge
GO

create procedure spEmployeeMerge
	@employeeIDInternal bigint,
	@employeeIDExternal bigint,
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	set @result = 1;
	begin try
		if not exists(select * from Employee where EmployeeID = @employeeIDInternal)
			set @result= -2
		else if not exists(select * from Employee where EmployeeID = @employeeIDExternal)
			set @result= -3
		else if not exists (select * from Employee e1
							inner join Employee e2
							on
                                -- acpro #119084
								lower(e1.LastName) = lower(e2.LastName)
								and lower(e1.FirstName) = lower(e2.FirstName)
							where
							  e1.EmployeeID = @employeeIDExternal
							  and e2.EmployeeID = @employeeIDInternal
							)
			set @result= -4

		if 	@result > 0
		begin				
			begin tran
                -- changes according acpro #119084, item (3)
				update e1
				set 
					PersID = e2.PersID
					-- change according acpro #121270:
					,PersNumber = e2.PersNumber
					,MainStoreID = e2.MainStoreID
					--,OldHolidays = e2.OldHolidays
					--,NewHolidays = e2.NewHolidays
					--,BalanceHours = e2.BalanceHours
					,CreateDate = e2.CreateDate
					--,AvailableHolidays = e2.AvailableHolidays
					,Import = e2.Import
                    ,FirstName = e2.FirstName
                    ,LastName = e2.LastName
				from Employee e1, Employee e2
				where e1.EmployeeID = @employeeIDExternal and e2.EmployeeID = @employeeIDInternal

				--delete from dbo.EmployeeContract where EmployeeID = @employeeIDInternal
                delete from dbo.EmployeeContract where EmployeeID = @employeeIDExternal
                update e
                set
                    EmployeeID = @employeeIDExternal
                from dbo.EmployeeContract e
                where e.EmployeeID = @employeeIDInternal

                update e
                set
                    EmployeeID = @employeeIDExternal
                from dbo.EmployeeHolidaysInfo e
                where e.EmployeeID = @employeeIDInternal

				delete from dbo.Employee_Relations where EmployeeID = @employeeIDInternal
				delete from dbo.EmployeeAllIn where EmployeeID = @employeeIDInternal
				delete from dbo.Employee where EmployeeID = @employeeIDInternal
			commit
		end
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
