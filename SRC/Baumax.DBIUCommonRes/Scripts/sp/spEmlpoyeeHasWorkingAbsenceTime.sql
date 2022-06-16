print '%Creating procedure% spEmlpoyeeHasWorkingAbsenceTime'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmlpoyeeHasWorkingAbsenceTime' 
)
   DROP PROCEDURE spEmlpoyeeHasWorkingAbsenceTime
GO

CREATE PROCEDURE spEmlpoyeeHasWorkingAbsenceTime
	@EmployeeID bigint
	,@Begin smalldatetime
	,@End smalldatetime
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare @result bit
	set @result = 0
	if exists (select * from dbo.AbsenceTimePlanning where EmployeeID = @EmployeeID and Date between @Begin and @End)
		set @result= 1
	else if exists (select * from dbo.AbsenceTimeRecording where EmployeeID = @EmployeeID and Date between @Begin and @End)
		set @result= 1
	else if exists (select * from dbo.WorkingTimePlanning where EmployeeID = @EmployeeID and Date between @Begin and @End)
		set @result= 1
	else if exists (select * from dbo.WorkingTimeRecording where EmployeeID = @EmployeeID and Date between @Begin and @End)
		set @result= 1
	
	select @result result
END
GO
