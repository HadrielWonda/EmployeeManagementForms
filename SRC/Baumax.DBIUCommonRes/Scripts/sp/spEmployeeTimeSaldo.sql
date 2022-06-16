print '%Creating procedure% spEmployeeTimeSaldo'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeTimeSaldo' 
)
   DROP PROCEDURE spEmployeeTimeSaldo
GO
-- 1 - TimeRecording, 2 - TimePlanning
CREATE PROCEDURE spEmployeeTimeSaldo
	@xmlDocument nvarchar(max)
	,@type int 
	,@Date smalldatetime
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	
	create table #Employee
	(
		EmployeeID bigint primary key
		,Saldo int null
		,WeekBegin smalldatetime null
	)

	declare @docHandle int
	declare @datafield nvarchar(255), @SQL nvarchar(4000)
	exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument

	insert into #Employee (EmployeeID)
	select [EmployeeID] 
	from openxml(@docHandle, N'/Root/Employee') 
	  with ([EmployeeID] bigint)


	update #Employee
	set
		Saldo = t1.Saldo
		,WeekBegin = t1.WeekBegin 
	from #Employee e
	inner join  dbo.EmployeeWeekTimeRecording t1
	on
		e.EmployeeID = t1.EmployeeID
	where 
	exists
	( 
		select * from
		(
			select 
				EmployeeID 
				, max(WeekBegin) WeekBegin
			from dbo.EmployeeWeekTimeRecording 
			where WeekBegin < @Date and EmployeeID in (select EmployeeID from #Employee)
			group by EmployeeID
		) t2 
		where t1.EmployeeID = t2.EmployeeID and t1.WeekBegin = t2.WeekBegin
	) 

	if (@type = 2)
	begin
		update #Employee
		set
			Saldo = t1.Saldo
			--,WeekBegin = t1.WeekBegin 
		from #Employee e
		inner join dbo.EmployeeWeekTimePlanning  t1
		on
			e.EmployeeID = t1.EmployeeID
		where 
		exists
		( 
			select * from
			(
				select 
					EmployeeID 
					, max(WeekBegin) WeekBegin
				from dbo.EmployeeWeekTimePlanning 
				where WeekBegin < @Date and EmployeeID in (select EmployeeID from #Employee)
				group by EmployeeID
			) t2 
			where t1.EmployeeID = t2.EmployeeID and t1.WeekBegin = t2.WeekBegin and (e.Saldo is null or e.WeekBegin < t2.WeekBegin)
		) 
	end

	update #Employee
	set
	  Saldo= BalanceHours
	from #Employee te
	inner join Employee e
	on
	  e.EmployeeID = te.EmployeeID
	where te.Saldo is null

	select EmployeeID, Saldo from #Employee

	drop table #Employee

END
GO
