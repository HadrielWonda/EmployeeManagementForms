print '%Creating procedure% spBV_TargetAddFromStore'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_TargetAddFromStore' 
)
   DROP PROCEDURE spBV_TargetAddFromStore
GO

CREATE PROCEDURE spBV_TargetAddFromStore
  @YearBegin smallint
  ,@YearEnd smallint
  ,@StoreID bigint
  ,@NewStoreID bigint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare 
	   @DateBegin int
	  ,@DateEnd int

	select @DateBegin = @YearBegin*100 + 1, @DateEnd= @YearEnd*100 + 12


	if exists (select * from dbo.BusinessVolumeTarget where Date between @DateBegin and @DateEnd and StoreID = @NewStoreID)
	begin
		return -1
	end 
	else
	begin
		insert into dbo.BusinessVolumeTarget (Date, StoreID, WGR_ID, Month, VolumeBC, VolumeCC, Converted, WorldID)
		select Date, @NewStoreID, WGR_ID, Month, VolumeBC, VolumeCC, Converted, WorldID 
		from dbo.BusinessVolumeTarget 
		where 
			Date between @DateBegin and @DateEnd and 
			StoreID = @StoreID

		if @@ROWCOUNT = 0
			return -2
		else
			return 0 
	end

END
GO
