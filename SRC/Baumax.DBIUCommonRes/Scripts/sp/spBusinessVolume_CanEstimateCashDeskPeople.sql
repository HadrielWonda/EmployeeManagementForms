print '%Creating procedure% spBusinessVolume_CanEstimateCashDeskPeople'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_CanEstimateCashDeskPeople' 
)
   DROP PROCEDURE spBusinessVolume_CanEstimateCashDeskPeople
GO

/*
1	Flat-file for cash register receipts (“Bon”) of last three years before the estimation year must exist
2	At least one employee must be assigned to each cash-desk-world in the to be-estimated year
3	Country properties for imports and calculation of targeted amounts must exist for the to be-estimated year.
4	Closed days (Yearly work-time definition must exist for the to be-estimated year.)
5   Opening times must exist for the to-be-estimated year
6	Minimum and maximum people for the world must exist
*/
CREATE PROCEDURE spBusinessVolume_CanEstimateCashDeskPeople
	@EstimateYear smallint
	,@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare @result int
	set @result = 1;

	if (@StoreID is null)
	begin
		set @StoreID= -1
	end

	create table #ConditionResult
	(
		Condition int primary key
		,Result int 
	)

	declare @Condition int
	set @Condition = 1
	while @Condition <= 6
	begin
		insert into #ConditionResult(Condition, Result)
		values (@Condition,1)
		set @Condition = @Condition + 1
	end


	declare @DateBegin1 smalldatetime, @DateEnd1 smalldatetime, @DateBegin2 smalldatetime, @DateEnd2 smalldatetime
	declare @DateBegin int, @DateEnd int

	select  @DateBegin1= min (BeginDate), @DateEnd1= max (EndDate) from dbo.bauMaxYear
	where Year between @EstimateYear - 3 and @EstimateYear - 1

	select @DateBegin2= isnull(min (Date),0), @DateEnd2 = isnull(max (Date),0) from dbo.CashRegisterReceipt
	where 
		Date between @DateBegin1 and @DateEnd1
		and @StoreID = 
			  case 
				when @StoreID < 0 then @StoreID 
				else StoreID
			  end


--1 Flat-file for cash register receipts (“Bon”) of last three years before the estimation year must exist
	if not (@DateBegin1 = @DateBegin2 and year(@DateEnd2) >= (@EstimateYear-1))
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 1
		set @result= -1
	end

--2 At least one employee must be assigned to each cash-desk-world in the to be-estimated year
	if exists (
		select * from World w
			where not exists(
				select * from dbo.Employee_Relations er 
				where w.WorldID = er.WorldID and convert(char(4),@EstimateYear) + '1231' between BeginTime and EndTime
	)
	and WorldTypeID  = 2
	and WorldID in (select WorldID 
					from Store_World sw
					where @StoreID = 
						  case 
							when @StoreID < 0 then @StoreID 
							else StoreID
						  end
					)

	)
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 2
		set @result= -2
	end

--3 Country properties for imports and calculation of targeted amounts must exist for the to be-estimated year.
	if (exists (
		select * from dbo.Country c
			where not exists 
				(select * from dbo.AvgAmounts a where c.CountryID = a.CountryID and a.Year = @EstimateYear)
				and exists (select * from Region r
								inner join Store s
								on
								  r.RegionID = s.RegionID
							  where 
								c.CountryID = r.CountryID
								and @StoreID = 
									  case 
										when @StoreID < 0 then @StoreID 
										else s.StoreID
									  end
							)
	))
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 3
		set @result= -3
	end

--4 Closed days (Yearly work-time definition must exist for the to be-estimated year.)
	if (exists(
		select CountryID from Country c
			where 
				not exists (select * from dbo.YearlyWorkingDays w where c.CountryID = w.CountryID and year(WorkingDay) = @EstimateYear)
				and exists (select * from Region r
								inner join Store s
								on
								  r.RegionID = s.RegionID
							  where 
								c.CountryID = r.CountryID
    							and @StoreID = 
									  case 
										when @StoreID < 0 then @StoreID 
										else s.StoreID
									  end
							)

	))
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 1
		set @result= -4
	end

--5 Opening times must exist for the to-be-estimated year
	if (exists(
		select StoreID from dbo.Store s
			where 
				not exists (
					select * from dbo.StoreWorkingTime wt 
					inner join dbo.StoreWTWeekday wd
					on
						wt.StoreWorkingTimeID = wd.StoreWorkingTimeID
					where s.StoreID = wt.StoreID and convert(char(4),@EstimateYear) + '1231' between BeginTime and EndTime
				)
    			and @StoreID = 
					  case 
						when @StoreID < 0 then @StoreID 
						else s.StoreID
					  end

	))
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 5
		set @result= -5
	end


--6 Minimum and maximum people for the world must exist
	declare @resultSW smallint
	set @resultSW = 1

	if exists (	
		select sw.Store_WorldID from Store_World sw
		left outer join PersonMinMax pmm
		on
			sw.Store_WorldID = pmm.Store_WorldID 
			and [Year] = @EstimateYear
		where @StoreID = 
						  case 
							when @StoreID < 0 then @StoreID 
							else sw.StoreID
						  end 
		and sw.WorldID = 102
		and pmm.Store_WorldID is null
	)
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 6
		set @result= -6
	end


  	select Condition, Result from #ConditionResult 

	drop table #ConditionResult

END
GO
