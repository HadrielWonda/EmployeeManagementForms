print '%Creating procedure% spEmployeeToMergeList'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeToMergeList' 
)
   DROP PROCEDURE spEmployeeToMergeList
GO

create procedure spEmployeeToMergeList
WITH ENCRYPTION
as
begin
	set nocount on;
	select e.EmployeeID, e.MainStoreID from dbo.Employee e
	where 
		e.MainStoreID is not null 
		and exists ( select * from Employee i where
						e.LastName = i.LastName 
						and e.FirstName = i.FirstName
						and (i.Import = 1)) 
		and exists ( select * from Employee ee where
						e.LastName = ee.LastName 
						and e.FirstName = ee.FirstName
						and (ee.Import = 0))
end
GO
