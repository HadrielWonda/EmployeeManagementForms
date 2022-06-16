print '%Creating procedure% spEmlpoyeeHolidaysSumInfoGet'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmlpoyeeHolidaysSumInfoGet' 
)
   DROP PROCEDURE spEmlpoyeeHolidaysSumInfoGet
GO

CREATE PROCEDURE spEmlpoyeeHolidaysSumInfoGet
	@MainStoreID bigint
	, @BeginDate smalldatetime
	, @EndDate smalldatetime
	, @CurrDate smalldatetime
	, @EmployeeID bigint = NULL -- if @EmployeeID is not null, in that case @MainStoreID ignore
	, @CountryID bigint = NULL -- if @CountryID is not null, in that case @MainStoreID and @EmployeeID ignore
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	declare 
		@CalcType tinyint
		,@SQL nvarchar (4000)
		,@DateCondition nvarchar (100)

			-- @Type values
			-- 1   @BeginDate <= @CurrDate <= @EndDate
			-- 2   @CurrDate < @BeginDate <= @EndDate
			-- 3   @BeginDate <= @EndDate < @CurrDate
			-- 4   else
		,@Type tinyint
	
	if (@MainStoreID is not null) 
		set @CalcType = 1
	else if (@EmployeeID is not null)	
		set @CalcType = 2
	else 
		set @CalcType =3

	if (@CurrDate between @BeginDate and @EndDate)
		set @Type = 1
	else if ( @CurrDate < @BeginDate and @BeginDate <= @EndDate )
		set @Type = 2
	else if (@BeginDate <= @EndDate and @EndDate < @CurrDate)
		set @Type = 3
	else
		set @Type = 4

	if (@CalcType = 2)
		select @MainStoreID= MainStoreID from Employee where EmployeeID = @EmployeeID

	select @CountryID = CountryID 
	from dbo.Country c where exists
	(
		select * from dbo.Region r
		inner join dbo.Store s
		on 
			s.RegionID = r.RegionID
		where 
			c.CountryID = r.CountryID and s.StoreID = @MainStoreID
	)

	create table #Absence
	(
		AbsenceID bigint primary key
	)

	insert into #Absence (AbsenceID)
	select AbsenceID from dbo.Absence
	where CountryID = @CountryID and AbsenceTypeID = 2

	create table #Employee
	(
		EmployeeID bigint primary key
		,[TimeRecording] int
		,[TimePlanning] int
	)
	
	if (@CalcType = 1)
	begin
		insert into #Employee (EmployeeID)
		select EmployeeID from Employee where MainStoreID = @MainStoreID
	end
	else if (@CalcType = 2)
	begin
		insert into #Employee (EmployeeID)
		select @EmployeeID
	end
	else 
	begin
		insert into #Employee (EmployeeID)
		select distinct e.EmployeeID
		from dbo.Employee e
		inner join  dbo.EmployeeContract ec
		on
		  ec.EmployeeID = e.EmployeeID
		  and (@BeginDate <= ContractBegin or ContractEnd >= @EndDate)
		inner join dbo.Store s
		on
		  s.StoreID = e.MainStoreID	
		inner join Region r 
		on 
			s.RegionID = r.RegionID
		where 
			r.CountryID = @CountryID 
	end

	if (@Type = 1 or @Type = 3)
	begin
		if (@Type = 1)
			set @DateCondition = ''''+convert(nvarchar(8),@BeginDate,112)+ ''' <= Date and Date < '''+convert(nvarchar(8),@CurrDate,112)+ ''''
		else
			set @DateCondition = 'Date between '''+convert(nvarchar(8),@BeginDate,112)+ ''' and '''+convert(nvarchar(8),@EndDate,112)+ ''''
		set @SQL= 'update #Employee
		set
		 [TimeRecording]= t.[TimeRecording]
		from #Employee emp
		inner join 
		(
			select 
			EmployeeID, sum (Time) [TimeRecording]
			from dbo.AbsenceTimeRecording atr
			where '+ @DateCondition +' 
				and exists (select * from #Absence a where a.AbsenceID = atr.AbsenceID)
				and exists (select * from #Employee e where e.EmployeeID = atr.EmployeeID)
			group by EmployeeID
		) t
		on
		  emp.EmployeeID = t.EmployeeID'

		exec sp_executesql @SQL
	end
	
	if (@Type = 1 or @Type = 2)  
	begin
		if (@Type = 1)
			set @DateCondition = ''''+convert(nvarchar(8),@CurrDate,112)+ ''' <= Date and Date <= '''+convert(nvarchar(8),@EndDate,112)+ ''''
		else
			set @DateCondition = 'Date between '''+convert(nvarchar(8),@BeginDate,112)+ ''' and '''+convert(nvarchar(8),@EndDate,112)+ ''''

		set @SQL= 'update #Employee
		set
		 [TimePlanning]= t.[TimePlanning]
		from #Employee emp
		inner join 
		(
			select EmployeeID, sum (Time) [TimePlanning]
			from dbo.AbsenceTimePlanning atp
			where  '+ @DateCondition +'  
				and exists (select * from #Absence a where a.AbsenceID = atp.AbsenceID)
				and exists (select * from #Employee e where e.EmployeeID = atp.EmployeeID)
			group by EmployeeID
		) t  
		on
		  emp.EmployeeID = t.EmployeeID'

		exec sp_executesql @SQL
	end

	select 
		EmployeeID
		, isnull([TimeRecording],0) [TimeRecording]
		, isnull([TimePlanning],0) [TimePlanning] 
	from #Employee

	drop table #Absence
	drop table #Employee
END
GO
