print '%Creating procedure% spBusinessVolume_EstimateWorkingHours'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_EstimateWorkingHours' 
)
   DROP PROCEDURE spBusinessVolume_EstimateWorkingHours
GO
--dbo.BusinessVolumeTarget
CREATE PROCEDURE spBusinessVolume_EstimateWorkingHours
	@EstimateYear smallint
	,@StoreID bigint = NULL
	,@result int output
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	set @result = 1;
	set datefirst 1;
	declare @debug bit 
	set @debug = 0

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

	declare @DateBegin1 smalldatetime, @DateEnd1 smalldatetime, @DateBegin2 smalldatetime, @DateEnd2 smalldatetime, @Year smallint, @Month tinyint,@Week tinyint, @WeekDay tinyint
	declare @SQL nvarchar(4000), @MaxWeek smallint, @WeekCount smallint

-- Get begin and end date for calculations
	select @MaxWeek= LastWeekNumber from dbo.bauMaxYear
	where
	  [Year] = @EstimateYear 

	select @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
	where
	  Year = @EstimateYear - 1

	select @DateBegin2= min (BeginDate) from dbo.bauMaxYear
	where Year between @EstimateYear - 2 and @EstimateYear - 1


	select @DateEnd2 = max (Date) from dbo.BusinessVolumeActual 
	where Date between @DateBegin1 and @DateEnd1


	select @WeekCount= sum (LastWeekNumber)*(-1) from dbo.bauMaxYear
	where [Year] between datepart(year,@DateEnd2) -1 and datepart(year,@DateEnd2)


	select @DateBegin1= dateadd(week,@WeekCount,@DateEnd2)

--create query for calculation the average business volume per day
	set @SQL= 
			'insert into #BusinessVolumeActual (StoreID, WorldID, WGR_ID ,Week, WeekDay,VolumeBC,VolumeCC)  
			 select	StoreID, WorldID, WGR_ID , Week, WeekDay 
				,avg(VolumeBC) VolumeBC, avg(VolumeCC) VolumeCC
				
			from BusinessVolumeActual
			where '
	if (@StoreID is not null)
	begin
		set @SQL= @SQL + 'StoreID = ' + convert(nvarchar(8),@StoreID) + ' and '
	end

	set @SQL= @SQL + 'Date between '''+convert(nvarchar(8),@DateBegin1,112)+ ''' and ''' + convert(nvarchar(8),@DateEnd2,112) +''''		
	set @SQL= @SQL + ' and [Week] <= '+convert(nvarchar(2),@MaxWeek)
	set @SQL= @SQL + ' group by StoreID, WorldID, WGR_ID ,Week, WeekDay'

	begin try

		create table #BusinessVolumeActual
		(
			[Date] [smalldatetime] NULL,
			[StoreID] [bigint] NOT NULL,--store ID
			[WorldID] [bigint] NOT NULL,--world ID
			[WGR_ID] [bigint] NOT NULL,--wgr ID
			[Month] [tinyint] NULL,--month 
			[Week] [tinyint] NULL,--week number
			[WeekDay] [tinyint] NULL,--weekday (1-monday ... 7-sunday)
			[VolumeBC] [money] NULL,-- business volume in bauMax currency
			[VolumeCC] [money] NULL,-- business volume in country currency
			[CVolumeBC] [money] NULL,--calculated targeted business volume per day in bauMax currency
			[CVolumeCC] [money] NULL --calculated targeted business volume per day in country currenc
		)
		--BC bauMax currency
		--CC country currency	 
		create table #ewTargetedBVperDayNoWGR(
			[Date] [smalldatetime] NULL,
			[StoreID] [bigint] NOT NULL,--store ID
			[WorldID] [bigint] NOT NULL,--world ID
			[Month] [tinyint] NULL,--month
			[Week] [tinyint] NULL,--week number
			[WeekDay] [tinyint] NULL,--weekday (1-monday ... 7-sunday)
			[VolumeBC] [money] NULL,-- business volume in bauMax currency
			[VolumeCC] [money] NULL,-- business volume in country currency
			[CVolumeBC] [money] NULL,--calculated targeted business volume per day in bauMax currency
			[CVolumeCC] [money] NULL,--calculated targeted business volume per day in country currency
			[TargHoursBCBuffHph] [money] NULL,--TH1 --ph - per hour
			[TargHoursCCBuffHph] [money] NULL,--TH1
			[TargHoursBCNoBuffHph] [money] NULL,--“Targeted hours (analyzes)” = (Targeted business volume of this world per day) / (Targeted net-performance per hour  (without buffer))
			[TargHoursCCNoBuffHph] [money] NULL,--“Targeted hours (analyzes)” = (Targeted business volume of this world per day) / (Targeted net-performance per hour  (without buffer))
			[OpenHoursBCVarMin] [money] NULL,--opening-hours variations (for minimum presence)
			[OpenHoursCCVarMin] [money] NULL,--opening-hours variations (for minimum presence)
			[OpenHoursBCVarMax] [money] NULL,--Additional Hours due maximum presence per day
			[OpenHoursCCVarMax] [money] NULL,--Additional Hours due maximum presence per day
			[BCTH2] [money] NULL,  --Targeted hours (estimation) per day (without unavoidable additional factor hours)
			[CCTH2] [money] NULL,   --Targeted hours (estimation) per day (without unavoidable additional factor hours)
			[BCTH3] [money] NULL,   --Targeted hours (estimation) per day (without unavoidable additional factor hours)
			[CCTH3] [money] NULL,   --Targeted hours (estimation) per day (without unavoidable additional factor hours)
			[HoursMin] [smallmoney] NULL,--Minimum hours 
			[HoursMax] [smallmoney] NULL --Maximum hours 
		)
--calculate the average business volume per day		
		exec sp_executesql @SQL	

		declare @BeginDate smalldatetime
		select @BeginDate= BeginDate from dbo.bauMaxYear
		where Year = @EstimateYear

--calculate date for BusinessVolume
		update #BusinessVolumeActual
		set
			Date = dateadd(day,(Week-1)*7 + (WeekDay-1), @BeginDate) 
			,[Month]= case
				when datepart(year,dateadd(day,(Week-1)*7 + (WeekDay-1), @BeginDate)) < @EstimateYear then 1
				when datepart(year,dateadd(day,(Week-1)*7 + (WeekDay-1), @BeginDate)) > @EstimateYear then 12
				else datepart(month,dateadd(day,(Week-1)*7 + (WeekDay-1), @BeginDate)) 
			end 
		from #BusinessVolumeActual b

--#124951 p1
		update #BusinessVolumeActual
		set
			WorldID = world_h.WorldID
		from #BusinessVolumeActual bva	
		inner join dbo.HWGR_WGR hwgr_w
		on 
			bva.StoreID = hwgr_w.StoreID
			and bva.WGR_ID = hwgr_w.WGR_ID
			and Date between hwgr_w.BeginTime and hwgr_w.EndTime
		inner join dbo.World_HWGR world_h
		on 
			bva.StoreID = world_h.StoreID
			and hwgr_w.HWGR_ID = world_h.HWGR_ID
			and Date between world_h.BeginTime and world_h.EndTime
--end #124951 p1
/*
		CREATE NONCLUSTERED INDEX [Ix_Store_World_WGR_Month] ON #BusinessVolumeActual
		(
			[StoreID] ASC,
			[WorldID] ASC,
			[WGR_ID] ASC,
			[Month] ASC
		)
		CREATE NONCLUSTERED INDEX [Ix_Store_WGR_Month] ON #BusinessVolumeActual
		(
			[StoreID] ASC,
			[WGR_ID] ASC,
			[Month] ASC
		)
*/
--sum BV for StoreID, WorldID, WGR_ID ,Month		
		select 
			StoreID, WorldID, WGR_ID ,Month
			, sum (isnull(VolumeBC,0)) VolumeBC
			, sum (isnull(VolumeCC,0)) VolumeCC
		into #BusinessVolumeActual_MonthAvg
		from #BusinessVolumeActual
		group by StoreID, WorldID, WGR_ID ,Month

--calculate the targeted business volume per day	
		update #BusinessVolumeActual
		set
--			[CVolumeBC]= ((100/ma.VolumeBC)*b.VolumeBC)*bvt.VolumeBC
--			,[CVolumeCC]= ((100/ma.VolumeCC)*b.VolumeCC)*bvt.VolumeCC
			[CVolumeBC]= 
			case
				when ma.VolumeBC <> 0 then ((100*b.VolumeBC)/ma.VolumeBC)*(isnull(bvt.VolumeBC,0)/100) --fixed round error
				else 0
			end
			,[CVolumeCC]= 
			case
				when ma.VolumeCC <> 0 then ((100*b.VolumeCC)/ma.VolumeCC)*(isnull(bvt.VolumeCC,0)/100) --fixed round error
				else 0
			end
--			[CVolumeBC]= 
--			case
--				when ma.VolumeBC <> 0 then ((b.VolumeBC)/ma.VolumeBC)*isnull(bvt.VolumeBC,0) --fixed round error
--				else 0
--			end
--			,[CVolumeCC]= 
--			case
--				when ma.VolumeCC <> 0 then ((b.VolumeCC)/ma.VolumeCC)*isnull(bvt.VolumeCC,0) --fixed round error
--				else 0
--			end
		from #BusinessVolumeActual b
		left outer join #BusinessVolumeActual_MonthAvg ma
		on
			b.StoreID = ma.StoreID
			and b.WorldID = ma.WorldID
			and b.WGR_ID = ma.WGR_ID
			and b.[Month] = ma.[Month]
		left outer join  BusinessVolumeTarget bvt
		on
			b.StoreID = bvt.StoreID
			and b.WGR_ID = bvt.WGR_ID
			and b.[Month] = bvt.[Month]
			and bvt.[Date]/100 = @EstimateYear -- use etimate year
		--where ma.VolumeBC <> 0 and ma.VolumeCC <> 0			

--get calculate data for world
		insert into #ewTargetedBVperDayNoWGR(Date, StoreID, WorldID, [Month], Week, WeekDay, VolumeBC, VolumeCC, CVolumeBC, CVolumeCC)
		select [Date],[StoreID],[WorldID],[Month],[Week],[WeekDay]
				,sum(isnull([VolumeBC],0)) [VolumeBC]
				,sum(isnull([VolumeCC],0)) [VolumeCC]
				,sum(isnull([CVolumeBC],0))[CVolumeBC] 
				,sum(isnull([CVolumeCC],0))[CVolumeCC] 
		from #BusinessVolumeActual
		group by [Date],[StoreID],[WorldID],[Month],[Week],[WeekDay]	

--#122523
		insert into #ewTargetedBVperDayNoWGR(Date, StoreID, WorldID, [Month], Week, WeekDay, VolumeBC, VolumeCC, CVolumeBC, CVolumeCC)
		select [Date],[StoreID],101,[Month],[Week],[WeekDay]
				,sum(isnull([VolumeBC],0)) [VolumeBC]
				,sum(isnull([VolumeCC],0)) [VolumeCC]
				,sum(isnull([CVolumeBC],0))[CVolumeBC] 
				,sum(isnull([CVolumeCC],0))[CVolumeCC] 
		from #ewTargetedBVperDayNoWGR
		where WorldID <> 102
		group by [Date],[StoreID],[Month],[Week],[WeekDay]	

		update #ewTargetedBVperDayNoWGR	
		set 
			VolumeBC =0
			,VolumeCC= 0
			,CVolumeBC = 0
			,CVolumeCC = 0
				--CR p3 for #124951
			,[OpenHoursBCVarMin]= 0
			,[OpenHoursCCVarMin]= 0
			,[OpenHoursBCVarMax]= 0
			,[OpenHoursCCVarMax]= 0
		from #ewTargetedBVperDayNoWGR c
		inner join Store s
		on
		  c.StoreID = s.StoreID
		inner join dbo.Region r 
		on
		  s.RegionID = r.RegionID
		inner join dbo.YearlyWorkingDays cd
		on
		  r.CountryID = cd.CountryID
		  and c.Date = cd.WorkingDay
		where 
			datepart(year,c.Date) = @EstimateYear		

--#122523 end 

		--drop no use data
		drop table #BusinessVolumeActual_MonthAvg
		--select * into EstBusinessVolumeActual from #BusinessVolumeActual
		drop table #BusinessVolumeActual
		
		if (@debug = 1) print 'sum data - ok'

		--calculate Employee data
		select @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
		where
		  [Year] = @EstimateYear 
		
		create table #EsimateYearDate
		(
			[Date] smalldatetime primary key
			,[Week] tinyint null
		)

		declare @Date smalldatetime
		set @Date= @DateBegin1

		while @Date <= @DateEnd1
		begin
			insert into #EsimateYearDate ([Date])
			values (@Date)
			set @Date= dateadd (day,1,@Date)
		end

		update #EsimateYearDate
		set
			Week= case 
				when datepart(year,Date) > y.[Year] then y.LastWeekNumber
				when datepart(year,Date) < y.[Year] then 1
				else datepart (week, Date) - WeeksMinus
			end 
		from #EsimateYearDate d
		inner join dbo.bauMaxYear y
		on
		  d.Date between  BeginDate and EndDate
		where y.Year = @EstimateYear


		select d.Date ,er.StoreID ,WorldID ,count (*) EmployeeCount
		into #EsimateYearDate_World
		from #EsimateYearDate d
		inner join dbo.Employee_Relations er
		on
		  d.Date between BeginTime and EndTime
		inner join dbo.EmployeeContract ec
		on
		  er.EmployeeID  = ec.EmployeeID
		  and d.Date between ec.ContractBegin and ec.ContractEnd
		where 
			exists (select * from #Store s where er.StoreID = s.StoreID)
		group by d.Date ,er.StoreID ,WorldID

-- create #122523
/*--comment #123848
		insert into #EsimateYearDate_World (Date, StoreID, WorldID, EmployeeCount)
		select Date, StoreID, 101, sum(EmployeeCount)
		from #EsimateYearDate_World
		where WorldID <> 102
		group by Date, StoreID
*/
-- end #122523


		/*
		available working hours per world 
		(without bufferhours, without unavoidable additional factor hours
		, without opening-hours variations)” (AWH1):
		*/
		create table #ContractHoursPerEmployee
		(
			EmployeeID bigint not null
			,[Week] tinyint not null
			,StoreID bigint not null
			,WorldID bigint not null
			,ContractWorkingHours decimal (5,2)
		)

		insert into #ContractHoursPerEmployee (EmployeeID, Week, StoreID, WorldID, ContractWorkingHours)
		select
			er.EmployeeID
			,Week
			,er.StoreID
			,WorldID
			,avg (ContractWorkingHours) ContractWorkingHours
		from dbo.Employee_Relations er
		inner join #EsimateYearDate d
		on
		  d.Date between BeginTime and EndTime
		inner join dbo.EmployeeContract ec
		on
		  er.EmployeeID  = ec.EmployeeID
		  and d.Date between ec.ContractBegin and ec.ContractEnd
		where
			exists (select * from #Store s where er.StoreID = s.StoreID)
-- #124951 p2 
			and not exists (select * from dbo.Employee_LongTimeAbsence lta where er.EmployeeID = lta.EmployeeID and d.Date between lta.BeginTime and lta.EndTime)
		group by 
			er.EmployeeID
			,Week
			,er.StoreID
			,WorldID

--create #122523
/*--comment #123848
		insert into #ContractHoursPerEmployee (EmployeeID, Week, StoreID, WorldID, ContractWorkingHours)
		select
			EmployeeID
			,Week
			,StoreID
			,101
			,sum (ContractWorkingHours) ContractWorkingHours
		from #ContractHoursPerEmployee
		where WorldID <> 102
		group by 
			EmployeeID
			,Week
			,StoreID
*/
--end #122523


--calc World data
		create table #WorldData
		(
			StoreID bigint
			,WorldID bigint
				-- For every week which employees 
				-- are assigned to this world, sums up their working hours 
				-- of their contracts for this week. 
			,ContractWorkingHours decimal (9,2)
			,AvgPersPeopleInYear smallmoney
			,ContractWorkingHoursBuffH decimal (9,2)--AWH1.2
			,ContractWorkingHoursNoBuffH decimal (9,2)--AWH1
			,AvgRestingTime smallint-- average resting time minutes
			,AvgContractTime smallint--average working hours in week
			,AvgWorkingTime decimal (4,2)--average working time
			,PersonMin smallint-- minimum person 
			,PersonMax smallint-- maximum person 
		)

		insert into #WorldData (StoreID, WorldID, ContractWorkingHours)
		select
			StoreID
			,WorldID
			,sum (ContractWorkingHours) ContractWorkingHours 
		from #ContractHoursPerEmployee
		group by 
			StoreID
			,WorldID

		update #WorldData
		set
			--AWH1
			ContractWorkingHoursNoBuffH= 
				ContractWorkingHours*(convert(smallmoney,AvgWeeks)/LastWeekNumber ) 
			--AWH1.2
			,ContractWorkingHoursBuffH= 
				ContractWorkingHours*(convert(smallmoney,AvgWeeks)/LastWeekNumber ) - isnull(bh.Value,0)
			,AvgPersPeopleInYear= convert(smallmoney,AvgWeeks)/LastWeekNumber 
			,AvgRestingTime= avga.AvgRestingTime
			,AvgContractTime= avga.AvgContractTime
			,PersonMin = isnull(pmm.Min, 0)
			,PersonMax = isnull(pmm.Max, 0)
			,AvgWorkingTime = avga.AvgContractTime--convert(decimal(4,2),avga.AvgContractTime)/awd.DaysCount
		from #WorldData wd 
		left outer join Store s 
		on
		  wd.StoreID = s.StoreID
		left outer join dbo.Region r
		on
		  r.RegionID = s.RegionID
		left outer join	dbo.AvgAmounts avga--
		on	
		  avga.CountryID = r.CountryID
		  and avga.Year = @EstimateYear
		left outer join dbo.bauMaxYear bauy
		on
		  avga.Year = bauy.Year
		left outer join Store_World sw
		on
		  sw.StoreID = wd.StoreID
		  and sw.WorldID = wd.WorldID
		left outer join dbo.BufferHours bh--
		on
		  bh.Store_WorldID = sw.Store_WorldID
		  and bh.Year = @EstimateYear	 
		left outer join dbo.PersonMinMax pmm--
		on
		  sw.Store_WorldID = pmm.Store_WorldID
		  and pmm.Year = @EstimateYear
		left outer join dbo.AvgWorkingDaysInWeek awd--
		on
		  avga.CountryID = awd.CountryID
		  and awd.Year = @EstimateYear

		if (@debug = 1) print 'create world data - ok'

--	Calculate targeted business volume of the worlds per year 
		--BC bauMax currency
		--CC country currency	 
		create table #TargetedBVofWorldEstYear
		(
			StoreID bigint-- store ID
			,WorldID bigint-- world ID
			,CVolumeBC money --targeted business volume of the worlds per year 
			,CVolumeCC money --targeted business volume of the worlds per year  

								-- “Targeted net-performance per hour (incl. buffer)” NP1 
			,TargNetPerformanceBCBuffH decimal (14,4)
			,TargNetPerformanceCCBuffH decimal (14,4)

								--“Targeted net-performance per hour (no buffer)” NP1 
			,TargNetPerformanceBCNoBuffH decimal (14,4)
			,TargNetPerformanceCCNoBuffH decimal (14,4)

								--all “opening hours variation for minimum and maximum presence per year”.
			,OpenHoursBCVarMin money
			,OpenHoursCCVarMin money
			,OpenHoursBCVarMax money
			,OpenHoursCCVarMax money
								--“available working hours per world (without unavoidable additional factor hours)” AWH2
			,BCAWH2 decimal (11,4)
			,CCAWH2 decimal (11,4)

			,BCNP2 decimal (12,4) --NP2 Targeted net-performance per hour (incl. buffer)
			,CCNP2 decimal (12,4) --NP2 Targeted net-performance per hour (incl. buffer)

								--“available working hours per world” AWH3
			,BCAWH3 decimal (11,4)
			,CCAWH3 decimal (11,4)

			,BCNP3 decimal (12,4) --NP3 Targeted net-performance per hour (incl. buffer)
			,CCNP3 decimal (12,4) --NP3 Targeted net-performance per hour (incl. buffer)
		)

		insert into #TargetedBVofWorldEstYear (StoreID,WorldID,CVolumeBC,CVolumeCC)
		select	
			bva.StoreID
			,bva.WorldID
			,sum (isnull([CVolumeBC],0)) CVolumeBC
			,sum (isnull([CVolumeCC],0)) CVolumeCC
		--from #BusinessVolumeActual bva
		from #ewTargetedBVperDayNoWGR bva
		where  Date between @DateBegin1 and @DateEnd1
		group by 
			bva.StoreID
			,bva.WorldID


		--Calculate “Targeted net-performance per hour (incl. buffer)” NP1 = 
		-- (Targeted business volume of this world per year) / AWH1.1 (Without buffer)
		--Calculate “Targeted net-performance per hour (incl. buffer)” NP1 = 
		-- (Targeted business volume of this world per year) / AWH1.2 (Including buffer)

		update #TargetedBVofWorldEstYear
		set
		  --NP1	
		  TargNetPerformanceBCBuffH= isnull(t.[CVolumeBC]/ContractWorkingHoursBuffH,0)
		  ,TargNetPerformanceCCBuffH= isnull(t.[CVolumeCC]/ContractWorkingHoursBuffH,0)
		  ,TargNetPerformanceBCNoBuffH= isnull(t.[CVolumeBC]/ContractWorkingHoursNoBuffH,0)
		  ,TargNetPerformanceCCNoBuffH= isnull(t.[CVolumeCC]/ContractWorkingHoursNoBuffH,0)
		from #TargetedBVofWorldEstYear t
		left outer join #WorldData wd
		on
		  t.StoreID = wd.StoreID
		  and t.WorldID = wd.WorldID

		if (@debug = 1) print 'NP1 - ok'

		--4
		--Targeted hours (analyzes)” = 
		-- (Targeted business volume of this world per day) / (Targeted net-performance per hour  (without buffer))
		--Targeted hours (analyzes)” = 
		-- (Targeted business volume of this world per day) / (Targeted net-performance per hour  (with buffer))

		update #ewTargetedBVperDayNoWGR 
		set
			--TH1
			TargHoursBCBuffHph= case when TargNetPerformanceBCBuffH = 0 then 0 else b.CVolumeBC/TargNetPerformanceBCBuffH end     
			,TargHoursCCBuffHph = case when TargNetPerformanceCCBuffH = 0 then 0 else b.CVolumeCC/TargNetPerformanceCCBuffH end     

			--“Targeted hours (analyzes)” = (Targeted business volume of this world per day) / (Targeted net-performance per hour  (without buffer))
			,TargHoursBCNoBuffHph= case when TargNetPerformanceBCNoBuffH = 0 then 0 else b.CVolumeBC/TargNetPerformanceBCNoBuffH end 
			,TargHoursCCNoBuffHph= case when TargNetPerformanceCCNoBuffH = 0 then 0 else b.CVolumeCC/TargNetPerformanceCCNoBuffH end 
		from #ewTargetedBVperDayNoWGR b
		left outer join #TargetedBVofWorldEstYear w
		on
			b.StoreID = w.StoreID
			and b.WorldID = w.WorldID

		if (@debug = 1) print 'TH1 - ok'


		-- 5
		--	Now we calculate the opening-hours variations (for minimum presence):	
		--	Now we calculate the opening-hours variations (for maximum presence):
		update #ewTargetedBVperDayNoWGR
		set 
			OpenHoursBCVarMin= 
			case 
					--CR p3 for #124951
				when (OpenHoursBCVarMin = 0) then 0	
				when ((isnull(wd.PersonMin,0)*((Closetime - Opentime)/60 - isnull(AvgRestingTime,0)/60)) - isnull(t.TargHoursBCBuffHph,0)) < 0 then 0
				else (isnull(wd.PersonMin,0)*((Closetime - Opentime)/60 - isnull(AvgRestingTime,0)/60)) - isnull(t.TargHoursBCBuffHph,0)
			end   
			,OpenHoursCCVarMin= 
			case 
					--CR p3 for #124951
				when (OpenHoursCCVarMin = 0) then 0	
				when ((isnull(wd.PersonMin,0)*((Closetime - Opentime)/60 - isnull(AvgRestingTime,0)/60)) - isnull(t.TargHoursCCBuffHph,0)) < 0 then 0
				else (isnull(wd.PersonMin,0)*((Closetime - Opentime)/60 - isnull(AvgRestingTime,0)/60)) - isnull(t.TargHoursCCBuffHph,0)
			end  
			,OpenHoursBCVarMax=
			case
					--CR p3 for #124951
				when (OpenHoursBCVarMax = 0) then 0	
				when (t.TargHoursBCBuffHph - isnull(eyw.EmployeeCount,0)*isnull(wd.AvgWorkingTime,0)) < 0 then 0
				else t.TargHoursBCBuffHph - isnull(eyw.EmployeeCount,0)*isnull(wd.AvgWorkingTime,0)
			end 
			,OpenHoursCCVarMax= 
			case
					--CR p3 for #124951
				when (OpenHoursCCVarMax = 0) then 0	
				when (t.TargHoursCCBuffHph - isnull(eyw.EmployeeCount,0)*isnull(wd.AvgWorkingTime,0)) < 0 then 0
				else t.TargHoursCCBuffHph - isnull(eyw.EmployeeCount,0)*isnull(wd.AvgWorkingTime,0)
			end
			,HoursMin = isnull(wd.PersonMin,0)*((Closetime - Opentime)/60 - isnull(AvgRestingTime,0)/60)--#123986
			,HoursMax = isnull(eyw.EmployeeCount,0)*isnull(wd.AvgWorkingTime,0)
		from 
		#ewTargetedBVperDayNoWGR t
		left outer join StoreWorkingTime swt
		on
		  t.StoreID = swt.StoreID
		  and Date between swt.BeginTime and swt.EndTime
		left outer join StoreWTWeekday swd
		on
		  swt.StoreWorkingTimeID = swd.StoreWorkingTimeID
		  and swd.Weekday = case when t.Weekday = 7 then 0 else t.Weekday end 
		left outer join #WorldData wd
		on
		  wd.StoreID = t.StoreID
		  and wd.WorldID = t.WorldID
		left outer join #EsimateYearDate_World eyw
		on
			eyw.Date = t.Date
			and eyw.StoreID = t.StoreID
			and eyw.WorldID = t.WorldID

		if (@debug = 1) print 'opening-hours variations (for min, max presence) - ok'


		--	Now sum up all hours of every day of the to be estimated year, 
		-- to get all “opening hours variation for minimum and maximum presence per year”.
		update #TargetedBVofWorldEstYear
		set
			OpenHoursBCVarMin= t.OpenHoursBCVarMin
			,OpenHoursCCVarMin= t.OpenHoursCCVarMin	 
			,OpenHoursBCVarMax= t.OpenHoursBCVarMax	 
			,OpenHoursCCVarMax= t.OpenHoursCCVarMax	
		from 
			#TargetedBVofWorldEstYear d
		inner join 
		(
			select 
			StoreID
			,WorldID
			, sum (isnull(OpenHoursBCVarMin,0)) OpenHoursBCVarMin
			, sum (isnull(OpenHoursCCVarMin,0)) OpenHoursCCVarMin
			, sum (isnull(OpenHoursBCVarMax,0)) OpenHoursBCVarMax
			, sum (isnull(OpenHoursCCVarMax,0)) OpenHoursCCVarMax
			from #ewTargetedBVperDayNoWGR 
			where Date between @DateBegin1 and @DateEnd1
			group by 
			StoreID
			,WorldID
		)t
		on
		  d.StoreID = t.StoreID
		  and d.WorldID = t.WorldID

		if (@debug = 1) print 'opening hours variation for minimum and maximum presence per year - ok'


		--6
		--Calculate “available working hours per world (without unavoidable additional factor hours)” AWH2: 
		--AWH2 = (AWH1.2) – (opening-hours variations (for minimum presence) per year) +  (opening-hours variations (for maximum presence) per year):
		--Calculate “Targeted net-performance per hour (incl. buffer)” NP2 = (Targeted business volume of this world per year) / AWH2 
		update #TargetedBVofWorldEstYear
		set
			BCAWH2= isnull(ContractWorkingHoursBuffH,0) - isnull(OpenHoursBCVarMin,0) + isnull(OpenHoursBCVarMax,0)--AWH2 
			,CCAWH2= isnull(ContractWorkingHoursBuffH,0) - isnull(OpenHoursCCVarMin,0) + isnull(OpenHoursCCVarMax,0)--AWH2 
--			,BCNP2= isnull(CVolumeBC,0)/(isnull(ContractWorkingHoursBuffH,0) - isnull(OpenHoursBCVarMin,0) + isnull(OpenHoursBCVarMax,0))--NP2
--			,CCNP2= isnull(CVolumeCC,0)/(isnull(ContractWorkingHoursBuffH,0) - isnull(OpenHoursCCVarMin,0) + isnull(OpenHoursCCVarMax,0))
			,BCNP2= isnull(CVolumeBC/(ContractWorkingHoursBuffH - OpenHoursBCVarMin + OpenHoursBCVarMax),0)--NP2
			,CCNP2= isnull(CVolumeCC/(ContractWorkingHoursBuffH - OpenHoursCCVarMin + OpenHoursCCVarMax),0)
		from #WorldData wd
		left outer join #TargetedBVofWorldEstYear y
		on
		  wd.StoreID = y.StoreID
		  and wd.WorldID = y.WorldID

		if (@debug = 1) print 'AWH2 - ok'

		--Targeted hours (estimation) per day (without unavoidable additional factor hours)” 
		--TH2 = (Targeted business volume of this world per day) / NP2
		update #ewTargetedBVperDayNoWGR
		set
			BCTH2= case 
				when isnull(t.CVolumeBC/BCNP2,0) <  HoursMin then HoursMin
				when isnull(t.CVolumeBC/BCNP2,0) > HoursMax then HoursMax
				else isnull(t.CVolumeBC/BCNP2,0)
			end 
			,CCTH2= case 
				when isnull(t.CVolumeCC/CCNP2,0) <  HoursMin then HoursMin
				when isnull(t.CVolumeCC/CCNP2,0) > HoursMax then HoursMax
				else isnull(t.CVolumeCC/CCNP2,0)
			end 
		from #ewTargetedBVperDayNoWGR t
		left outer join #TargetedBVofWorldEstYear y
		on
		  t.StoreID = y.StoreID
		  and t.WorldID = y.WorldID
		  and BCNP2 <> 0
		  and CCNP2 <> 0

		if (@debug = 1) print 'TH2 - ok'
 

		-- Calculate “available working hours per world” AWH3: 
		-- Calculate “Targeted net-performance per hour (incl. buffer)” NP3 

--4testers
		--unavoidable additional factor hours per year:
/*
#124951 p 4.
	isnull(AdditionalHours,0)

*/
			select 
				t.StoreID
				,t.WorldID
				,sum(isnull((t.BCTH2/wd.AvgWorkingTime)*isnull(AdditionalHours,0),0)) BCunavoidAddFaktorPerYear
				,sum(isnull((t.CCTH2/wd.AvgWorkingTime)*isnull(AdditionalHours,0),0)) CCunavoidAddFaktorPerYear
			into #EstUnavoidAddFaktorPerYear
			from #ewTargetedBVperDayNoWGR t
			left outer join #WorldData wd
			on
			  t.StoreID = wd.StoreID
			  and t.WorldID = wd.WorldID
			left outer join dbo.StoreAdditionalHours sah
			on
			  sah.StoreID = t.StoreID
			  and sah.WeekDay = t.WeekDay
			  and t.Date between BeginDate and EndDate
			group by 
				t.StoreID
				,t.WorldID
--end 4testers


		update #TargetedBVofWorldEstYear
		set
			BCAWH3= BCAWH2 - BCunavoidAddFaktorPerYear 
			,CCAWH3= CCAWH2 - CCunavoidAddFaktorPerYear  
--			,BCNP3= CVolumeBC/(BCAWH2 - BCunavoidAddFaktorPerYear) 
--			,CCNP3= CVolumeCC/(CCAWH2 - CCunavoidAddFaktorPerYear) 
--#122523
			,BCNP3= case 
				when (BCAWH2 - BCunavoidAddFaktorPerYear) = 0 then 0
				else CVolumeBC/(BCAWH2 - BCunavoidAddFaktorPerYear) 
			end
			,CCNP3= case 
				when (CCAWH2 - CCunavoidAddFaktorPerYear) = 0 then 0
				else CVolumeCC/(CCAWH2 - CCunavoidAddFaktorPerYear) 
			end	

		from #TargetedBVofWorldEstYear y 
		left outer join #EstUnavoidAddFaktorPerYear t
/*
		left outer join (
		--unavoidable additional factor hours per year:
			select 
				t.StoreID
				,t.WorldID
				,sum(isnull((t.BCTH2/wd.AvgWorkingTime)*AdditionalHours,0)) BCunavoidAddFaktorPerYear
				,sum(isnull((t.CCTH2/wd.AvgWorkingTime)*AdditionalHours,0)) CCunavoidAddFaktorPerYear
			from #ewTargetedBVperDayNoWGR t
			left outer join #WorldData wd
			on
			  t.StoreID = wd.StoreID
			  and t.WorldID = wd.WorldID
			left outer join dbo.StoreAdditionalHours sah
			on
			  sah.StoreID = t.StoreID
			  and sah.WeekDay = t.WeekDay
			  and t.Date between BeginDate and EndDate
			group by 
				t.StoreID
				,t.WorldID
		--end calc unavoidable additional factor hours per year
			) t
*/
		on
			y.StoreID = t.StoreID
			and y.WorldID = t.WorldID

		if (@debug = 1) print 'AWH3 - ok'


		update #ewTargetedBVperDayNoWGR
		set
			BCTH3= case 
--				when HoursMin > HoursMax ?
				when isnull(t.CVolumeBC/BCNP3,0) <  HoursMin then HoursMin
				when isnull(t.CVolumeBC/BCNP3,0) > HoursMax then HoursMax
				else isnull(t.CVolumeBC/BCNP3,0)
			end 
			,CCTH3= case 
				when isnull(t.CVolumeCC/CCNP3,0) <  HoursMin then HoursMin
				when isnull(t.CVolumeCC/CCNP3,0) > HoursMax then HoursMax
				else isnull(t.CVolumeCC/CCNP3,0)
			end 
		from #ewTargetedBVperDayNoWGR t
		left outer join #TargetedBVofWorldEstYear y
		on
		  t.StoreID = y.StoreID
		  and t.WorldID = y.WorldID
		  and BCNP3 <> 0
		  and CCNP3 <> 0

		update #ewTargetedBVperDayNoWGR	
		set 
			BCTH3 =0
			,CCTH3= 0
		from #ewTargetedBVperDayNoWGR c
		inner join Store s
		on
		  c.StoreID = s.StoreID
		inner join dbo.Region r 
		on
		  s.RegionID = r.RegionID
		inner join dbo.YearlyWorkingDays cd
		on
		  r.CountryID = cd.CountryID
		  and c.Date = cd.WorkingDay
		where 
			datepart(year,c.Date) = @EstimateYear

		if (@debug = 1) print 'Calculations have passed successfully - ok'

		begin tran

			delete from EstWorldWorkingHours
			where 
				Date between @DateBegin1 and @DateEnd1
				and exists (select * from #Store s where EstWorldWorkingHours.StoreID = s.StoreID)

			delete from EstWorldDifferentData 
			where 
				[Year] = @EstimateYear
				and exists (select * from #Store s where EstWorldDifferentData.StoreID = s.StoreID)
			
			delete from EstWorldYearValues	
			where 
				[Year] = @EstimateYear
				and exists (select * from #Store s where EstWorldYearValues.StoreID = s.StoreID)

			delete from dbo.EstUnavoidAddFaktorPerYear			
			where 
				[Year] = @EstimateYear
				and exists (select * from #Store s where EstUnavoidAddFaktorPerYear.StoreID = s.StoreID)

			insert into EstWorldWorkingHours
			(Date, StoreID, WorldID, Month, Week, WeekDay, VolumeBC, VolumeCC, CVolumeBC, CVolumeCC, TargHoursBCBuffHph, TargHoursCCBuffHph, TargHoursBCNoBuffHph, TargHoursCCNoBuffHph, OpenHoursBCVarMin, OpenHoursCCVarMin, OpenHoursBCVarMax, OpenHoursCCVarMax, BCTH2, CCTH2, BCTH3, CCTH3, HoursMin, HoursMax)
			select Date, StoreID, WorldID, Month, Week, WeekDay, VolumeBC, VolumeCC, CVolumeBC, CVolumeCC, TargHoursBCBuffHph, TargHoursCCBuffHph, TargHoursBCNoBuffHph, TargHoursCCNoBuffHph, OpenHoursBCVarMin, OpenHoursCCVarMin, OpenHoursBCVarMax, OpenHoursCCVarMax, BCTH2, CCTH2, BCTH3, CCTH3, HoursMin, HoursMax
			from #ewTargetedBVperDayNoWGR
			
			insert into EstWorldDifferentData
			(Year, StoreID, WorldID, ContractWorkingHours, AvgPersPeopleInYear, ContractWorkingHoursBuffH, ContractWorkingHoursNoBuffH, AvgRestingTime, AvgContractTime, AvgWorkingTime, PersonMin, PersonMax)
			select @EstimateYear, StoreID, WorldID, ContractWorkingHours, AvgPersPeopleInYear, ContractWorkingHoursBuffH, ContractWorkingHoursNoBuffH, AvgRestingTime, AvgContractTime, AvgWorkingTime, PersonMin, PersonMax
			from #WorldData
			
			insert into EstWorldYearValues
			(Year, StoreID, WorldID, CVolumeBC, CVolumeCC, TargNetPerformanceBCBuffH, TargNetPerformanceCCBuffH, TargNetPerformanceBCNoBuffH, TargNetPerformanceCCNoBuffH, OpenHoursBCVarMin, OpenHoursCCVarMin, OpenHoursBCVarMax, OpenHoursCCVarMax, BCAWH2, CCAWH2, BCNP2, CCNP2, BCAWH3, CCAWH3, BCNP3, CCNP3)
			select @EstimateYear, StoreID, WorldID, CVolumeBC, CVolumeCC, TargNetPerformanceBCBuffH, TargNetPerformanceCCBuffH, TargNetPerformanceBCNoBuffH, TargNetPerformanceCCNoBuffH, OpenHoursBCVarMin, OpenHoursCCVarMin, OpenHoursBCVarMax, OpenHoursCCVarMax, BCAWH2, CCAWH2, BCNP2, CCNP2, BCAWH3, CCAWH3, BCNP3, CCNP3
			from #TargetedBVofWorldEstYear
			
			insert into EstUnavoidAddFaktorPerYear
			(Year, StoreID, WorldID, BCunavoidAddFaktorPerYear, CCunavoidAddFaktorPerYear)
			select @EstimateYear, StoreID, WorldID, BCunavoidAddFaktorPerYear, CCunavoidAddFaktorPerYear
			from #EstUnavoidAddFaktorPerYear
		commit 

		if (@debug = 1) print 'update data tables - ok'

		--drop temporary tables
		drop table #TargetedBVofWorldEstYear	
		drop table #ewTargetedBVperDayNoWGR
		drop table #WorldData
		drop table #EsimateYearDate
		drop table #ContractHoursPerEmployee
		drop table #EsimateYearDate_World
		drop table #EstUnavoidAddFaktorPerYear
		if (@debug = 1) print 'drop temporary tables - ok'

	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		set @result = -1;
	end catch

END
GO
