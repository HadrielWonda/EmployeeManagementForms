print '%Creating procedure% spBusinessVolume_EstimatedCashDeskPeopleGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_EstimatedCashDeskPeopleGet' 
)
   DROP PROCEDURE spBusinessVolume_EstimatedCashDeskPeopleGet
GO

CREATE PROCEDURE spBusinessVolume_EstimatedCashDeskPeopleGet
	@StoreID bigint
	,@BeginDate smalldatetime
	,@EndDate smalldatetime
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select 
		Date
		,Hour
		,PeoplePerHour
		,TargReceiptsPerHour
	from dbo.CashDeskPeoplePerHourEstimate
	where 
		StoreID = @StoreID
		and Date between @BeginDate and @EndDate
END
GO
