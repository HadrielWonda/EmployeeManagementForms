print '%Creating procedure% spBusinessVolume_DeleteEstimatedWorkingHours'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_DeleteEstimatedWorkingHours' 
)
   DROP PROCEDURE spBusinessVolume_DeleteEstimatedWorkingHours
GO

CREATE PROCEDURE spBusinessVolume_DeleteEstimatedWorkingHours
	@EstimateYear smallint = NULL
	,@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare 
		@DateBegin1 smalldatetime, @DateEnd1 smalldatetime
	
	if (@EstimateYear is null)
	begin 
		begin tran 
			delete from EstWorldWorkingHours
			delete from dbo.EstWorldDifferentData
			delete from dbo.EstWorldYearValues
		commit
	end
	else if (@StoreID is null)
	begin
		select @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
		where
		  [Year] = @EstimateYear 

		begin tran
			delete from EstWorldWorkingHours
			where Date between @DateBegin1 and @DateEnd1

			delete from dbo.EstWorldDifferentData
			where [Year] = @EstimateYear 

			delete from dbo.EstWorldYearValues
			where [Year] = @EstimateYear 
		commit
	end
	else
	begin
		select @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
		where
		  [Year] = @EstimateYear 
		begin tran
			delete from EstWorldWorkingHours
			where StoreID= @StoreID and Date between @DateBegin1 and @DateEnd1
			
			delete from dbo.EstWorldDifferentData
			where [Year] = @EstimateYear and StoreID= @StoreID

			delete from dbo.EstWorldYearValues
			where [Year] = @EstimateYear and StoreID= @StoreID
		commit
	end	
END
GO
