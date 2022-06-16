print '%Creating procedure% spWorkingModelUsingIDList'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spWorkingModelUsingIDList' 
)
   DROP PROCEDURE spWorkingModelUsingIDList
GO

CREATE PROCEDURE spWorkingModelUsingIDList
	-- Add the parameters for the stored procedure here
	@CountryID bigint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select 
		WorkingModelID ID
	from dbo.WorkingModel w
	where
	(
		exists (select * from dbo.EmployeePlanningWorkingModel pw where pw.WorkingModelID = w.WorkingModelID)
		or	
		exists (select * from dbo.EmployeeRecordingWorkingModel rw where rw.WorkingModelID = w.WorkingModelID)
	) 
	and w.CountryID = @CountryID 	
END
GO
