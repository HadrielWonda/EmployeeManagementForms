print '%Creating procedure% spHWGR_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spHWGR_ImportData' 
)
   DROP PROCEDURE spHWGR_ImportData
GO

create procedure spHWGR_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	begin try
		begin tran
		set @result = 1;
		declare @ID bigint
		declare @ImportDate smalldatetime
		if not exists (select * from World_HWGR)
			select top 1 @ImportDate = BusinessValuesBegin from dbo.dbProperties
		else
			set @ImportDate = convert(datetime,convert(varchar(12),getdate(), 112),112)
	--Add data to vwHWGR	
		
		create table #hwgr
		(
			HWGR_SystemID int primary key,
			ImportName nvarchar (50)
		)

		insert into #hwgr (HWGR_SystemID)
		select distinct i.HWGR_SystemID from #hwgr4insert i where not exists ( select * from dbo.HWGR h where h.SystemID = i.HWGR_SystemID )
		
		update #hwgr
		set
			ImportName= i.ImportName
		from #hwgr inner join #hwgr4insert i 
		on
			#hwgr.HWGR_SystemID = i.HWGR_SystemID

		update HWGR_Name
		set
			[Name] = ImportName
		from HWGR h
		inner join #hwgr4insert i
		on
			h.SystemID = i.HWGR_SystemID
		where  
			HWGR_Name.HWGR_ID = h.HWGR_ID 

		select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'
		insert into HWGR (HWGR_ID, SystemID, Import)
		select  @ID+ ROW_NUMBER() over (order by HWGR_SystemID) as HWGR_ID
			,HWGR_SystemID, 1 from #hwgr
		
		set @ID = @ID + @@rowcount
		insert into dbo.HWGR_Name (Id, HWGR_ID, LanguageID, [Name])
		select 	
			@ID+ ROW_NUMBER() over (order by HWGR_ID) HWGR_NameID
			,h.HWGR_ID 
			,1
			,ImportName
		from HWGR h
		inner join #hwgr i
		on
			h.SystemID = i.HWGR_SystemID
		where not exists (select * from HWGR_Name hn where hn.HWGR_ID = h.HWGR_ID )
		set @ID = @ID + @@rowcount
		
		
	--add data to World_HWGR
		insert into dbo.World_HWGR (World_HWGR_ID, StoreID, WorldID, HWGR_ID, BeginTime, EndTime, Import)
		select 
			@ID+ROW_NUMBER() over (order by i.HWGR_SystemID) as World_HWGR_ID
			,sw.StoreID
			,sw.WorldID 
			,hw.HWGR_ID
			, @ImportDate
			, '20790606'
			, 1
		from #hwgr4insert i
		inner join World w
		on
			i.World_SystemID = w.ExSystemID  
		inner join dbo.Store_World sw
		on
			w.WorldID = sw.WorldID
		inner join dbo.HWGR	hw
		on	
			i.HWGR_SystemID = hw.SystemID
		where not exists (select * from World_HWGR where World_HWGR.HWGR_ID = hw.HWGR_ID and World_HWGR.StoreID = sw.StoreID and World_HWGR.WorldID = sw.WorldID and World_HWGR.Import = 1 and World_HWGR.EndTime > @ImportDate)
		set @ID = @ID + @@rowcount

		update PKGen 
		set
		  [Value] = @ID
		where DomainName = 'Entities'
			and [Value] <> @ID

	-- add data to default store structure
		insert into DS_World_HWGR (WorldID, HWGR_ID)
		select 	w.WorldID, h.HWGR_ID
		from #hwgr4insert i
		inner join World w
		on
			i.World_SystemID = w.ExSystemID  
		inner join HWGR h
		on
			i.HWGR_SystemID = h.SystemID
		where 
			not exists (select * from DS_World_HWGR ds where ds.WorldID = w.WorldID and ds.HWGR_ID = h.HWGR_ID)

		select ds.WorldID, ds.HWGR_ID into #delFromDS
		from DS_World_HWGR ds 
		inner join World w
		on
			ds.WorldID = w.WorldID  
		inner join HWGR h
		on
			ds.HWGR_ID = h.HWGR_ID
		where not exists (select * from #hwgr4insert i where i.World_SystemID = w.ExSystemID  and i.HWGR_SystemID = h.SystemID)

		delete from DS_World_HWGR
		where exists (select * from #delFromDS d where DS_World_HWGR.WorldID = d.WorldID and DS_World_HWGR.HWGR_ID = d.HWGR_ID)

		set @ImportDate = DATEADD(day, -1, @ImportDate)

		update World_HWGR 
		set
			EndTime= @ImportDate
		from World_HWGR wh
		inner join 	#delFromDS d
		on
			wh.HWGR_ID = d.HWGR_ID
		inner join Store_World sw
		on
			d.WorldID = sw.WorldID
		

		commit

	-- get no add data
		select i.HWGR_SystemID, i.World_SystemID from #hwgr4insert i
		where
			not exists (select * from HWGR h where h.SystemID = i.HWGR_SystemID)
			or not exists (select * from World w where w.ExSystemID = i.World_SystemID)

		drop table #hwgr
		drop table #hwgr4insert
		drop table #delFromDS
			

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
