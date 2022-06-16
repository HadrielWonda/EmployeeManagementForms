print '%Creating procedure% spBusinessVolume_EstimateCashDeskPeople'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_EstimateCashDeskPeople' 
)
   DROP PROCEDURE spBusinessVolume_EstimateCashDeskPeople
GO

CREATE PROCEDURE spBusinessVolume_EstimateCashDeskPeople
	@EstimateYear smallint
	,@StoreID bigint = NULL
	,@result int output
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	set @result = 1;

	if (@StoreID is null)
	begin
		set @StoreID= -1
	end

	declare @DateBegin1 smalldatetime, @DateEnd1 smalldatetime, @DateBegin2 smalldatetime, @DateEnd2 smalldatetime, @Year smallint, @Month tinyint,@Week tinyint, @WeekDay tinyint

	select @DateBegin1= BeginDate, @DateEnd1= EndDate from dbo.bauMaxYear
	where
	  Year = @EstimateYear - 1

	select @DateBegin2= min (BeginDate) from dbo.bauMaxYear
	where Year between @EstimateYear - 2 and @EstimateYear - 1

	select @DateEnd2 = max (Date) from dbo.CashRegisterReceipt 
	where Date between @DateBegin1 and @DateEnd1

	select top 1 @DateBegin1= dateadd(year,-2,Date), @Year= Year - 2,@Month= Month ,@Week= Week ,@WeekDay= WeekDay from CashRegisterReceipt
	where Date = @DateEnd2

	select top 1 @DateBegin1= Date from CashRegisterReceipt
	where Year = @Year and Month = @Month and Week = @Week and WeekDay = @WeekDay
	and Date between @DateBegin1 and dateadd(week, 1, @DateBegin1)

	select @DateEnd1= EndDate from dbo.bauMaxYear
	where @DateBegin1 between BeginDate and EndDate

	select @Week = LastWeekNumber from bauMaxYear where [Year] = @EstimateYear
	
	begin try
      begin tran

			CREATE TABLE #CashRegisterReceiptAvg(
				[EstimateYear] [smallint] NULL,
				[StoreID] [bigint] NOT NULL,
				[Month] [tinyint] NULL,
				[Week] [tinyint] NULL,
				[WeekDay] [tinyint] NULL,
				[Hour] [tinyint] NOT NULL,
				[Number] [smallmoney] NULL
			) 

			insert into #CashRegisterReceiptAvg (EstimateYear, StoreID, Week, WeekDay, Hour, Number)
			select 
				@EstimateYear EstimateYear,StoreID, Week, WeekDay, Hour 
				,avg(convert(smallmoney,Number)) Number
			from dbo.CashRegisterReceipt
			where 
			Date between @DateBegin1 and @DateEnd2 and Converted = 1 and [Week] <=@Week
			and @StoreID = 
				  case 
					when @StoreID < 0 then @StoreID 
					else StoreID
				  end

			group by StoreID, Week, WeekDay, Hour

			delete from CashDeskPeoplePerHourEstimate 
			where 
				EstimateYear = @EstimateYear
				and @StoreID = 
					  case 
						when @StoreID < 0 then @StoreID 
						else StoreID
					  end

			insert into dbo.CashDeskPeoplePerHourEstimate 
			(
				EstimateYear
				, Date
				, StoreID
				, Week
				, WeekDay
				, Hour
				, PeoplePerHour
				, TargReceiptsPerHour)
			select 
				c.EstimateYear
				, dateadd(day,(Week-1)*7 + (WeekDay-1), y.BeginDate) Date
				, c.StoreID
				, Week
				, WeekDay
				, Hour
				,convert (smallint,case 
					when round(c.Number/a.CashDeskAmount, 0, 1) + case when c.Number%a.CashDeskAmount >= 1 then 1 else 0 end < m.Min then m.Min
					when round(c.Number/a.CashDeskAmount, 0, 1) + case when c.Number%a.CashDeskAmount >= 1 then 1 else 0 end > m.Max then m.Max
					else round(c.Number/a.CashDeskAmount, 0, 1) + case when c.Number%a.CashDeskAmount >= 1 then 1 else 0 end 
				  end) PeoplePerHour
				,c.Number
			from #CashRegisterReceiptAvg c
			inner join Store s
			on
			  c.StoreID = s.StoreID
			inner join dbo.Region r 
			on
			  s.RegionID = r.RegionID
			inner join AvgAmounts a
			on
			  r.CountryID = a.CountryID
			inner join Store_World sw
			on
			  s.StoreID = sw.StoreID
			inner join PersonMinMax m
			on
			  m.Store_WorldID = sw.Store_WorldID
			inner join bauMaxYear y
			on
			  c.EstimateYear = y.Year
			where 
			  a.Year = @EstimateYear 
			  and m.Year = @EstimateYear
			  and sw.WorldID= 102 

			update CashDeskPeoplePerHourEstimate
			set
				PeoplePerHour = 0  
				,TargReceiptsPerHour = 0 
			from CashDeskPeoplePerHourEstimate c
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
			where c.EstimateYear = @EstimateYear

			drop table #CashRegisterReceiptAvg
		commit 
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
