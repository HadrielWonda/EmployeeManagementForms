print '%Creating procedure% spBV_TargetStoreYearGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_TargetStoreYearGet' 
)
   DROP PROCEDURE spBV_TargetStoreYearGet
GO

CREATE PROCEDURE spBV_TargetStoreYearGet
	@BeforeYear smallint,
	@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	if @StoreID is null
	begin
		select StoreID, Date/100 [Year], min(Month)  MonthBegin, max (Month)  MonthEnd 
		from dbo.BusinessVolumeTarget
		where Date/100 < @BeforeYear 
		group by StoreID, Date/100
		--order by 1, 2
	end
	else 
	begin
		select StoreID, Date/100 [Year], min(Month)  MonthBegin, max (Month)  MonthEnd 
		from dbo.BusinessVolumeTarget
		where Date/100 < @BeforeYear and StoreID = @StoreID
		group by StoreID, Date/100
		--order by 1, 2
	end
END
GO
