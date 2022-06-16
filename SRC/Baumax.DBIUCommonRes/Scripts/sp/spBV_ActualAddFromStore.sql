print '%Creating procedure% spBV_ActualAddFromStore'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_ActualAddFromStore' 
)
   DROP PROCEDURE spBV_ActualAddFromStore
GO

CREATE PROCEDURE spBV_ActualAddFromStore
  @YearBegin smallint
  ,@YearEnd smallint
  ,@StoreID bigint
  ,@NewStoreID bigint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare 
		@DateBegin smalldatetime
		,@DateEnd smalldatetime

		select @DateBegin = min(BeginDate), @DateEnd = max(EndDate) from dbo.bauMaxYear
		where [Year] between @YearBegin and @YearEnd

		if exists (select * from BusinessVolumeActual where Date between @DateBegin and @DateEnd and StoreID = @NewStoreID)
		begin
			return -1
		end 
		else
		begin
			insert into dbo.BusinessVolumeActual (Date, StoreID, WGR_ID, Year, Week, WeekDay, Month, VolumeBC, VolumeCC, Converted, WorldID)
			select Date, @NewStoreID, WGR_ID, Year, Week, WeekDay, Month, VolumeBC, VolumeCC, Converted, WorldID
			from dbo.BusinessVolumeActual where Date between @DateBegin and @DateEnd and StoreID = @StoreID 
				if @@ROWCOUNT = 0
					return -2
				else
					return 0 
		end

END
GO
