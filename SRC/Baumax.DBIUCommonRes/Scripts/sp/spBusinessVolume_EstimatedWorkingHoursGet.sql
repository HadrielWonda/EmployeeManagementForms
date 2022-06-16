print '%Creating procedure% spBusinessVolume_EstimatedWorkingHoursGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_EstimatedWorkingHoursGet' 
)
   DROP PROCEDURE spBusinessVolume_EstimatedWorkingHoursGet
GO

CREATE PROCEDURE spBusinessVolume_EstimatedWorkingHoursGet
	@StoreID bigint
	, @WorldID bigint
	,@BeginDate smalldatetime
	,@EndDate smalldatetime
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select 
		Date
		, BCTH3 WorkingHours  
	from dbo.EstWorldWorkingHours
	where 
		StoreID = @StoreID
		and WorldID = @WorldID
		and Date between @BeginDate and @EndDate
END
GO
