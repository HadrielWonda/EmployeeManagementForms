print '%Creating procedure% spStore_LastEmployeeWTRWarning'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStore_LastEmployeeWTRWarning' 
)
   DROP PROCEDURE spStore_LastEmployeeWTRWarning
GO

create procedure spStore_LastEmployeeWTRWarning
WITH ENCRYPTION
as
	set nocount on;
	declare
	  @CurrDate smalldatetime

	set datefirst 1
	set @CurrDate = convert(datetime,convert(varchar(12),getdate(), 112),112)-- get curren date
	set @CurrDate= dateadd(day,1-datepart(weekday, @CurrDate),@CurrDate)-- get monday in current week

	select 
		s.StoreID
		,s.LastEmployeeWTR LastChange
	from vwStore s
	inner join Country c
	on
	  s.CountryID = c.CountryID
	where 
		c.WarningDays > 0
		and (isnull(DATEDIFF ( day , LastEmployeeWTR , @CurrDate ), 0) >=  c.WarningDays)
GO
