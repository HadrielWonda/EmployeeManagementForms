print '%Creating procedure% sp_EmployeeHoursDayGet'
GO

IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'sp_EmployeeHoursDayGet' 
)
DROP PROCEDURE sp_EmployeeHoursDayGet
GO


create procedure sp_EmployeeHoursDayGet
	@year smallint ,
	@store bigint ,
	@begin datetime ,
	@end datetime
as
begin
	declare @days decimal(3,2)
	set @days = (
		select MAX(DaysCount)
		from AvgWorkingDaysInWeek diw
		where diw.Year = @year and diw.CountryID in
		(
			select CountryID 
			from Region re 
				left outer join Store st 
				on 
					re.RegionID = st.RegionID
			where st.StoreID = @store
		))

	if (@days is null)
		set @days = 5

	select ec.EmployeeID, (ec.ContractWorkingHours/1440 / @days) as 'Coefficient', ec.ContractBegin, ec.ContractEnd
	from  EmployeeContract ec 
	right outer join Employee_Relations er
	on 
		er.EmployeeID = ec.EmployeeID 
		and er.StoreID = @store
	where 
		ec.ContractBegin <= @end 
		and ec.ContractEnd >= @begin
end
GO