print '%Creating procedure% spStoreStructureCopyForEmpties'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStoreStructureCopyForEmpties' 
)
   DROP PROCEDURE spStoreStructureCopyForEmpties
GO

create procedure spStoreStructureCopyForEmpties
WITH ENCRYPTION
as
begin
	set nocount on;
	begin try
		declare @ID bigint, @BeginDate smalldatetime

		create table #StoreNoStruct
		(
			StoreID bigint primary key
		)

		insert into #StoreNoStruct (StoreID)
		select StoreID 
		from Store s
		  where not exists (select * from World_HWGR wh where s.StoreID = wh.StoreID)

		if (@@rowcount > 0)
		begin
			select top 1 @BeginDate = BusinessValuesBegin from dbo.dbProperties
			begin tran
				select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'

				insert into dbo.Store_World (StoreID, WorldID)
				select 
					s.StoreID, w.WorldID
				from #StoreNoStruct s
				cross join dbo.World w
				where WorldID not in (101,102)

				insert into dbo.World_HWGR (World_HWGR_ID, StoreID, WorldID, HWGR_ID, BeginTime, EndTime, Import)
				select 
					@ID+ ROW_NUMBER() over (order by s.StoreID) 
					,s.StoreID, wh.WorldID, wh.HWGR_ID
					,@BeginDate, '20790606', 1
				from #StoreNoStruct s
				cross join DS_World_HWGR wh

				set @ID = @ID + @@rowcount

				insert into dbo.HWGR_WGR (HWGR_WGR_ID, StoreID, HWGR_ID, WGR_ID, BeginTime, EndTime, Import)
				select 
					@ID+ ROW_NUMBER() over (order by s.StoreID) 
					,s.StoreID, hw.HWGR_ID, hw.WGR_ID
					,@BeginDate, '20790606', 1
				from #StoreNoStruct s
				cross join DS_HWGR_WGR hw

				set @ID = @ID + @@rowcount

				update PKGen 
				set
				  [Value] = @ID
				where DomainName = 'Entities'
					and [Value] <> @ID
			commit
		end
		drop table #StoreNoStruct
	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		return -1;
	end catch

	return 0
end
GO
