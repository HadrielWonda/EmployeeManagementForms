print '%Creating procedure% spEmployeeTimePlanning_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeTimePlanning_ImportData' 
)
   DROP PROCEDURE spEmployeeTimePlanning_ImportData
GO

create procedure spEmployeeTimePlanning_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	set @result = 1;
	begin try
--		insert into dbo.tp4insert( PersID, Date, CharID, [Begin], [End])
--		select PersID, Date, CharID, [Begin], [End] from #tp4insert
		begin tran
			insert into dbo.WorkingTimePlanning
			(EmployeeID, Date, [Begin], [End], [Time])
			select e.EmployeeID, Date, [Begin], [End], [End] - [Begin] from #tp4insert i
			inner join Employee e
			on
				e.PersID = i.PersID
			where CharID = ''
			and not exists 
				(
					select * from WorkingTimePlanning wtp 
					where 
						wtp.EmployeeID = e.EmployeeID 
						and wtp.Date = i.Date
						and wtp.[Begin] = i.[Begin]
						and wtp.[End] = i.[End]
				)

			insert into dbo.AbsenceTimePlanning
			(EmployeeID, Date, AbsenceID, [Begin], [End], [Time])
			select e.EmployeeID, Date, AbsenceID, [Begin], [End], [End] - [Begin] from #tp4insert i
			inner join Employee e
			on
				e.PersID = i.PersID
			inner join dbo.Absence a
			on
				i.CharID = convert(nvarchar(10),a.SystemID)
			where i.CharID <> ''
			and not exists 
				(
					select * from AbsenceTimePlanning atp 
					where 
						atp.EmployeeID = e.EmployeeID 
						and atp.Date = i.Date
						and atp.AbsenceID = a.AbsenceID
						and atp.[Begin] = i.[Begin]
						and atp.[End] = i.[End]
				)
		commit
		select min (Date) DateMin, max (Date) DateMax from #tp4insert
		drop table #tp4insert
	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		set @result = -1;
	end catch
	
end
GO
