print '%Creating procedure% spBusinessVolume_CanEstimateWorkingHours'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_CanEstimateWorkingHours' 
)
   DROP PROCEDURE spBusinessVolume_CanEstimateWorkingHours
GO
/*
1	Flat-file for business volume of last three years before the estimation year must exist
2	Flat-file for targeted business volume for the to be-estimated year must exist
3	At least one employee must be assigned to each world in the to-be-estimated year
4	Country properties for imports and calculation of targeted amounts must exist for the to-be-estimated year.
5	Buffer hours for the worlds must exist.
6	Closed days (Yearly work-time definition must exist for the to-be-estimated year.)
7   ActualBV Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
8   Unavoidable Additional Hours Calculation exists 
9   Minimum people for the world must exist
10  Opening times must exist for the to-be-estimated year
11  Average working days in week
12  TargetBV Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
*/
CREATE PROCEDURE spBusinessVolume_CanEstimateWorkingHours
	@EstimateYear smallint
	,@StoreID bigint = NULL
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	declare 
		@result int
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
	while @Condition <= 12
	begin
		insert into #ConditionResult(Condition, Result)
		values (@Condition,1)
		set @Condition = @Condition + 1
	end
	
	declare @DateBegin1 smalldatetime, @DateEnd1 smalldatetime, @DateBegin2 smalldatetime, @DateEnd2 smalldatetime
	declare @DateBegin int, @DateEnd int

	select  @DateBegin1= min (BeginDate), @DateEnd1= max (EndDate) from dbo.bauMaxYear 
	where Year between @EstimateYear - 3 and @EstimateYear - 1

--1 Flat-file for business volume of last three years before the estimation year must exist
	select @DateBegin2= isnull(min (Date),0), @DateEnd2 = isnull(max (Date),0) 
	from dbo.BusinessVolumeActual bv
	where 
		Date between @DateBegin1 and @DateEnd1
		and @StoreID = 
			  case 
				when @StoreID < 0 then @StoreID 
				else StoreID
			  end

	if not (@DateBegin1 = @DateBegin2 and year(@DateEnd2) >= (@EstimateYear-1))
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 1
		set @result= -1
	end

--2 Flat-file for targeted business volume for the to be-estimated year must exist
	select @DateBegin= isnull(min (Date),0), @DateEnd= isnull(max (Date),0) 
	from BusinessVolumeTarget bt
	where 
		Date between @EstimateYear* 100 + 1 and @EstimateYear* 100 + 12
		and @StoreID = 
			  case 
				when @StoreID < 0 then @StoreID 
				else StoreID
			  end
	 
	if (@DateBegin <> (@EstimateYear* 100 + 1) or @DateEnd <> (@EstimateYear* 100 + 12))
	begin  
		update #ConditionResult
		set
			Result = 0
		where Condition = 2
		set @result= -2 
	end

--3 At least one employee must be assigned to each world in the to-be-estimated year
	if not exists (select * from World where WorldTypeID  = 3)
		or exists (
		select * from World w
			where 
				not exists(
							select * from dbo.Employee_Relations er 
							where w.WorldID = er.WorldID and convert(char(4),@EstimateYear) + '1231' between BeginTime and EndTime
				)
				and WorldTypeID  = 3
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
		where Condition = 3
		set @result= -3
	end

--4 Country properties for imports and calculation of targeted amounts must exist for the to-be-estimated year.
	if (exists (
		select * from dbo.Country c
			where 
				not exists (select * from dbo.AvgAmounts a where c.CountryID = a.CountryID and a.Year = @EstimateYear)
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
		where Condition = 4
		set @result= -4
	end

	declare @resultBH smallint
	set @resultBH = 1
--5	Buffer hours for the worlds must exist.
	if exists (	
		select sw.Store_WorldID from Store_World sw
		inner join World w
		on
		  sw.WorldID = w.WorldID 
		  and w.WorldTypeID  = 3
		left outer join BufferHours bh
		on
			sw.Store_WorldID = bh.Store_WorldID 
			and [Year] = @EstimateYear
		where @StoreID = 
						  case 
							when @StoreID < 0 then @StoreID 
							else sw.StoreID
						  end 
		and	bh.Store_WorldID is null
	)
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 5
		set @result= -5
	end

--6 Closed days
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
		where Condition = 6
		set @result= -6
	end

--8 Unavoidable Additional Hours Calculation exists 
	select  @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
	where Year = @EstimateYear
	if exists 
	(
		select StoreID from Store s
		where 
			s.StoreID not in (
								select StoreID from dbo.StoreAdditionalHours 
								group by StoreID
								having   @DateBegin1 >= min (BeginDate) and max (EndDate) >= @DateEnd1
							)
    		and @StoreID = 
				  case 
					when @StoreID < 0 then @StoreID 
					else s.StoreID
				  end
	)
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 8
		set @result= -8
	end
	
--9 Minimum people for the world must exist
	if exists(
		select sw.Store_WorldID from Store_World sw
		left outer join PersonMinMax pmm
		on
			sw.Store_WorldID = pmm.Store_WorldID 
			and [Year] = @EstimateYear
		where @StoreID = 
						  case 
							when @StoreID < 0 then @StoreID 
							else sw.StoreID
						  end and 
			pmm.Store_WorldID is null
	)
	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 9
		set @result= -9
	end

--10 Opening times must exist for the to-be-estimated year
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
		where Condition = 10
		set @result= -10
	end

-- 11 Average working days in week
	if (exists (
		select * from dbo.Country c
			where 
				not exists (select * from dbo.AvgWorkingDaysInWeek a where c.CountryID = a.CountryID and a.Year = @EstimateYear)
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
		where Condition = 11
		set @result= -11
	end

	select  @DateBegin1= min (BeginDate), @DateEnd1= max (EndDate) from dbo.bauMaxYear 
	where Year between @EstimateYear - 3 and @EstimateYear - 1
--7 Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
--No check for store
	if exists (select * from #ConditionResult where Condition =1 and Result = 0) or
	exists 
	(	
		select * from BusinessVolumeActualConvertError 
		where Date between @DateBegin1 and @DateEnd1
	)

	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 7
		set @result= -7
	end

--12 Every WGR / HWGR that is mentioned in the flat-files must be assigned to a world
--No check for store
	if exists (select * from #ConditionResult where Condition =2 and Result = 0) or
	exists 
	(	
		select * from BusinessVolumeTargetConvetError
		where (Date + 200000) between @EstimateYear* 100 + 1 and @EstimateYear* 100 + 12
	)

	begin
		update #ConditionResult
		set
			Result = 0
		where Condition = 12
		set @result= -12
	end


	select Condition, Result from #ConditionResult 
	drop table #ConditionResult
END
GO
