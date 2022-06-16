print '%Creating procedure% spBusinessVolume_TargetedNetPerformanceGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_TargetedNetPerformanceGet' 
)
   DROP PROCEDURE spBusinessVolume_TargetedNetPerformanceGet
GO

CREATE PROCEDURE spBusinessVolume_TargetedNetPerformanceGet
	@StoreID bigint
	,@WorldID bigint
	,@Year smallint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select 
		BCNP3 
	from dbo.EstWorldYearValues
	where 
		StoreID = @StoreID
		and WorldID = @WorldID
		and [Year] = @Year
END
GO
