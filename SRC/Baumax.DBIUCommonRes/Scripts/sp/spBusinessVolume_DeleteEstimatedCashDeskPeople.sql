print '%Creating procedure% spBusinessVolume_DeleteEstimatedCashDeskPeople'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_DeleteEstimatedCashDeskPeople' 
)
   DROP PROCEDURE spBusinessVolume_DeleteEstimatedCashDeskPeople
GO

CREATE PROCEDURE spBusinessVolume_DeleteEstimatedCashDeskPeople
	@EstimateYear smallint = NULL
	,@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	
	if (@EstimateYear is null)
	begin 
		delete from CashDeskPeoplePerHourEstimate
	end
	else if (@StoreID is null)
	begin
		delete from CashDeskPeoplePerHourEstimate
		where EstimateYear = @EstimateYear
	end
	else
	begin
		delete from CashDeskPeoplePerHourEstimate
		where StoreID= @StoreID and EstimateYear = @EstimateYear
	end	
END
GO
