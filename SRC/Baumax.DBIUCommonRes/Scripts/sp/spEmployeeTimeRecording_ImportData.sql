print '%Creating procedure% spEmployeeTimeRecording_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spEmployeeTimeRecording_ImportData' 
)
   DROP PROCEDURE spEmployeeTimeRecording_ImportData
GO

create procedure spEmployeeTimeRecording_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	set @result = 1;
	begin try
		begin tran
			insert into dbo.WorkingTimeRecording
			(EmployeeID, Date, [Begin], [End], [Time])
			select e.EmployeeID, Date, [Begin], [End], [End] - [Begin] from #tp4insert i
			inner join Employee e
			on
				e.PersID = i.PersID
			where CharID = ''
			and not exists 
				(
					select * from WorkingTimeRecording wtr 
					where 
						wtr.EmployeeID = e.EmployeeID 
						and wtr.Date = i.Date
						and wtr.[Begin] = i.[Begin]
						and wtr.[End] = i.[End]
				)

			insert into dbo.AbsenceTimeRecording
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
					select * from AbsenceTimeRecording atr 
					where 
						atr.EmployeeID = e.EmployeeID 
						and atr.Date = i.Date
						and atr.AbsenceID = a.AbsenceID
						and atr.[Begin] = i.[Begin]
						and atr.[End] = i.[End]
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
