print '%Creating procedure% spBV_ActualStoreYearGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBV_ActualStoreYearGet' 
)
   DROP PROCEDURE spBV_ActualStoreYearGet
GO

CREATE PROCEDURE spBV_ActualStoreYearGet
	@BeforeYear smallint,
	@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
/*
	if @StoreID is null
	begin
		select StoreID, [Year], min(Date) DateBegin, max (Date) DateEnd  from dbo.BusinessVolumeActual
		where [Year] < @BeforeYear 
		group by StoreID, [Year]
	end
	else 
	begin
		select StoreID, [Year], min(Date) DateBegin, max (Date) DateEnd  from dbo.BusinessVolumeActual
		where [Year] < @BeforeYear  and StoreID = @StoreID
		group by StoreID, [Year]
	end
*/
	declare 
		@SQL nvarchar(4000)
		,@BeginDate smalldatetime
	select @BeginDate = BeginDate from dbo.bauMaxYear where Year = @BeforeYear

	set @SQL= 
	'select StoreID, [Year], min(Date) DateBegin, max (Date) DateEnd  from dbo.BusinessVolumeActual
		where [Date] < ''' + convert(nvarchar(8),@BeginDate,112)+ ''''
	if @StoreID is not null
		set @SQL= @SQL + ' and StoreID = '+convert(nvarchar(10),@StoreID)+' 
		group by StoreID, [Year]'
	else
		set @SQL= @SQL  + ' group by StoreID, [Year]'
	exec sp_executesql @SQL	
END
GO
