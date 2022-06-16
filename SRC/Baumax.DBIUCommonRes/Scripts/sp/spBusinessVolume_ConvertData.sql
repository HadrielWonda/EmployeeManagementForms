print '%Creating procedure% spBusinessVolume_ConvertData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_ConvertData' 
)
   DROP PROCEDURE spBusinessVolume_ConvertData
GO

create procedure spBusinessVolume_ConvertData
	@tableName nvarchar (30)
WITH ENCRYPTION
as
begin
	set nocount on;

	declare @mysql nvarchar(4000)
	if (@tableName = 'BusinessVolumeActual')
		set @mysql='set datefirst 1;

					create table #t 
					(
						Date smalldatetime primary key
					)

					insert into #t (Date)
					select Date from 
					(
						select Date from BusinessVolumeActual
						where Converted = 0
						group by Date
					) d

					update dbo.BusinessVolumeActual with (TABLOCKX)
					set
						StoreID = s.StoreID
						,WGR_ID = w.WGR_ID
						,Year= y.Year
						,Week= case 
							when datepart(year,bv.Date) > y.[Year] then y.LastWeekNumber
							when datepart(year,bv.Date) < y.[Year] then 1
							else datepart (week, bv.Date) - WeeksMinus
						end  
						,Weekday= datepart (weekday,bv.Date)
						,Converted = 1
						,WorldID= world_h.WorldID
					from BusinessVolumeActual bv
					inner hash join #t t
					on
					  bv.Date = t.Date
					inner join Store s 
					on
						bv.StoreID = s.SystemID
					inner join WGR w
					on
						bv.WGR_ID = w.SystemID
					inner join bauMaxYear y
					on
						t.Date between y.BeginDate and y.EndDate
					inner join dbo.HWGR_WGR hwgr_w
					on 
						s.StoreID = hwgr_w.StoreID
						and w.WGR_ID = hwgr_w.WGR_ID
						and t.Date between hwgr_w.BeginTime and hwgr_w.EndTime
					inner join dbo.World_HWGR world_h
					on 
						s.StoreID = world_h.StoreID
						and hwgr_w.HWGR_ID = world_h.HWGR_ID
						and t.Date between world_h.BeginTime and world_h.EndTime
					where
						Converted = 0

					drop table #t'

	else if (@tableName = 'BusinessVolumeTarget')
		set @mysql='set datefirst 1;
					update dbo.BusinessVolumeTarget with (TABLOCKX)
					set
						StoreID = s.StoreID
						,WGR_ID = w.WGR_ID
						,Date= Date + 200000
						,Month= right (convert (varchar(4),Date) , 2)
						,Converted = 1
					from BusinessVolumeTarget bv
					inner join Store s
					on
						bv.StoreID = s.SystemID
					inner join WGR w
					on
						bv.WGR_ID = w.SystemID
					where	
						Converted = 0'
	else if (@tableName = 'CashRegisterReceipt')
		set @mysql='set datefirst 1;
					update dbo.CashRegisterReceipt with (TABLOCKX)
					set
						StoreID= s.StoreID
						,Year= y.Year
						,Week= case 
							when datepart(year,Date) > y.[Year] then y.LastWeekNumber
							when datepart(year,Date) < y.[Year] then 1
							else datepart (week, Date) - WeeksMinus
						end  
						,Month= case 
							  when datepart(year,Date) < y.[Year] then 1
							  when datepart(year,Date) > y.[Year] then 12
							  else datepart (month, Date)
						end 
						,Weekday= datepart (weekday,Date)
						,Converted = 1
					from dbo.CashRegisterReceipt c
					inner join Store s
					on
						c.StoreID = s.SystemID
					inner join bauMaxYear y
					on
						c.Date between y.BeginDate and y.EndDate
					where	
						c.Converted = 0'

	exec sp_executesql @mysql

    if (@tableName = 'BusinessVolumeActual')
	begin
        begin tran
			insert into dbo.BusinessVolumeActualConvertError
			(Date, StoreID, WGR_ID, [Year], Week, WeekDay, [Month], VolumeBC, VolumeCC, Converted)
			select Date, StoreID, WGR_ID, [Year], Week, WeekDay, [Month], VolumeBC, VolumeCC, Converted
			from dbo.BusinessVolumeActual 
			where converted  = 0

			delete
			from dbo.BusinessVolumeActual 
			where converted  = 0
		commit tran
	end
	else if (@tableName = 'BusinessVolumeTarget')
	begin
        begin tran
			insert into dbo.BusinessVolumeTargetConvetError
			(Date, StoreID, WGR_ID, Month, VolumeBC, VolumeCC, Converted)
			select Date, StoreID, WGR_ID, Month, VolumeBC, VolumeCC, Converted
			from dbo.BusinessVolumeTarget 
			where converted  = 0

			delete
			from dbo.BusinessVolumeTarget 
			where converted  = 0  
		commit tran
	end
	else if (@tableName = 'CashRegisterReceipt')
	begin
        begin tran
			insert into dbo.CashRegisterReceiptConvertError
			(Date, StoreID, Year, Week, WeekDay, Month, Hour, Number, Converted)
			select Date, StoreID, Year, Week, WeekDay, Month, Hour, Number, Converted
			from dbo.CashRegisterReceipt 
			where converted  = 0

			delete
			from  dbo.CashRegisterReceipt
			where converted  = 0  
		commit tran
	end
end

GO
