print '%Creating procedure% spEmployeeList_ContractEndOutsideChangedGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeList_ContractEndOutsideChangedGet' 
)
   DROP PROCEDURE spEmployeeList_ContractEndOutsideChangedGet
GO

create procedure spEmployeeList_ContractEndOutsideChangedGet
WITH ENCRYPTION
as
	set nocount on;
	IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AusPEM]') AND type in (N'U'))
	begin
		select EmployeeID from dbo.AusPEM where ChangeMode = 4
	end
	else begin
		select top 0 EmployeeID from Employee
	end
GO
