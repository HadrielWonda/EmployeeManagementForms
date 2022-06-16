print '%Creating procedure% spBV_CRRStoreYearGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_CRRStoreYearGet' 
)
   DROP PROCEDURE spBV_CRRStoreYearGet
GO

CREATE PROCEDURE spBV_CRRStoreYearGet
	@BeforeYear smallint,
	@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	if @StoreID is null
	begin
		select StoreID, [Year], min(Date) DateBegin, max (Date) DateEnd from dbo.CashRegisterReceipt
		where [Year] < @BeforeYear 
		group by StoreID, [Year]
		--order by StoreID, [Year]	
	end
	else 
	begin
		select StoreID, [Year], min(Date) DateBegin, max (Date) DateEnd from dbo.CashRegisterReceipt
		where [Year] < @BeforeYear and StoreID = @StoreID
		group by StoreID, [Year]
		--order by StoreID, [Year]
	end
END
GO
