print '%Creating procedure% spBV_CRRGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_CRRGet' 
)
   DROP PROCEDURE spBV_CRRGet
GO

CREATE PROCEDURE spBV_CRRGet
	@DateBegin smalldatetime
	,@DateEnd smalldatetime
	,@StoreID bigint 
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare @SQL nvarchar(4000)

	set @SQL= 
	'select Date, Hour, Number
		from dbo.CashRegisterReceipt
		where Date between ''' + convert(nvarchar(8),@DateBegin,112)+ ''' and ''' + convert(nvarchar(8),@DateEnd,112) +''''	
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)
		
	exec sp_executesql @SQL	
END
GO
