print '%Creating procedure% spBusinessVolume_EstimationWorkingHoursExists'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_EstimationWorkingHoursExists' 
)
   DROP PROCEDURE spBusinessVolume_EstimationWorkingHoursExists
GO

CREATE PROCEDURE spBusinessVolume_EstimationWorkingHoursExists
	@Year smallint
	,@StoreID bigint = NULL
	,@result int output
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	set @result = 1;

	create table #Store
	(
		StoreID bigint primary key
	)

	if (@StoreID is null)
	begin
		insert into #Store (StoreID)
		select StoreID from dbo.Store
	end
	else
	begin
		insert into #Store (StoreID)
		values (@StoreID)
	end 	 
	
	if exists 
	(
		select * from dbo.EstWorldWorkingHours e
		where 
		exists (select * from #Store s where e.StoreID = s.StoreID)
		and datepart(year,Date) = @Year
	)
	begin
		set @result = 1
	end
	else
	begin
		set @result = -1
	end

END
GO
