create table #Year
(
	[Year] smallint primary key
)

declare @Year smallint

set @Year= 2000
while @Year < 2079
begin
	insert into #Year ([Year])
	values (@Year)
	set @Year= @Year + 1
end

set datefirst 1;
insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
select 
	Year
	--, datepart(weekday,convert(varchar(4), Year) + '0101') WeeekDay
	,case 
		when datepart(weekday,convert(varchar(4), Year) + '0101')  < 5 then dateadd(day,1-datepart(weekday,convert(varchar(4), Year) + '0101') , convert(varchar(4), Year) + '0101')
		else dateadd(day,8-datepart(weekday,convert(varchar(4), Year) + '0101') , convert(varchar(4), Year) + '0101')
	end BeginDate
	,case 
		when datepart(weekday,convert(varchar(4), Year+1) + '0101')  < 5 then dateadd(day,-datepart(weekday,convert(varchar(4), Year + 1) + '0101') , convert(varchar(4), Year+1) + '0101')
		else dateadd(day,7-datepart(weekday,convert(varchar(4), Year+1) + '0101') , convert(varchar(4), Year+1) + '0101')
	end EndDate
	,case 
		when datepart(weekday,convert(varchar(4), Year) + '0101')  < 5 then 0
		else 1
	end WeeksMinus
	,0
from #Year

insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
values(2079,'20790102', '20790606',	1, datepart(week,'20790606')-1)

update bauMaxYear
set
	LastWeekNumber= 
		case
			when datepart(year, EndDate) <= [Year] then datepart(week,EndDate) - WeeksMinus
			else datepart(week,convert(varchar(4), [Year]) + '1231') - WeeksMinus
		end
from bauMaxYear y

drop table #Year

/*
set datefirst 1;
declare @year int, @maxYear int, @day int, @weekMinus int
declare @date varchar (8), @dateNext varchar (8)
declare @beginYear smalldatetime, @endYear smalldatetime , @nextBeginYear smalldatetime

select @year = 2001, @maxYear = 2079, @endYear = '20001231', @nextBeginYear = '20000103' 

while (@year <= @maxYear)
begin
	select @date= convert(varchar(4), @year) + '0101'
	select @day= datepart(weekday,@date)
	if (@day <> 1)
		set @beginYear= dateadd(day,8-@day,@date)
	else
		set @beginYear= @date
	set @endYear= dateadd(day,-1,@beginYear)
	set @weekMinus= datepart(week,@nextBeginYear) -1
	insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
	select @year-1, @nextBeginYear, @endYear, @weekMinus, datepart(week,convert(varchar(4), @year-1) + '1231')  - @weekMinus
	set @nextBeginYear= @beginYear
	set @year= @year + 1
end
	insert into dbo.bauMaxYear ([Year], BeginDate, EndDate, WeeksMinus, LastWeekNumber)
	values (2079,'20790102','20790606',datepart(week,'20790102')-1, datepart(week,'20790606')-1)
*/