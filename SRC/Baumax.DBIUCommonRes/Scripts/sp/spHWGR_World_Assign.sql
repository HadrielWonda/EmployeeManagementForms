print '%Creating procedure% spHWGR_World_Assign'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spHWGR_World_Assign' 
)
   DROP PROCEDURE spHWGR_World_Assign
GO

create procedure spHWGR_World_Assign
	@StoreID bigint
	, @WorldID bigint
	, @HWGR_ID bigint
	, @BeginTime smalldatetime
	, @EndTime smalldatetime
	, @result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	


	select * from World_HWGR
		where 
			StoreID = @StoreID
			and WorldID = @WorldID
			and HWGR_ID  = @HWGR_ID
			and( 
					(@BeginTime between BeginTime and EndTime or @EndTime between BeginTime and EndTime) 
					or (@BeginTime < BeginTime and  EndTime < @EndTime)
				)

	if @@rowcount = 0
	begin
		begin try
			begin tran
				declare @ID bigint

				select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'

				select @ID = @ID + 1
				insert into World_HWGR (World_HWGR_ID, StoreID, WorldID, HWGR_ID, BeginTime, EndTime, Import)
				values( @ID, @StoreID, @WorldID, @HWGR_ID, dateadd(minute,1,@BeginTime), @EndTime, 0)

				update PKGen 
				set
				  [Value] = @ID
				where 
					DomainName = 'Entities'
					and [Value] <> @ID

				set @result = 1;

			commit
		end try
		begin catch
			if XACT_STATE() <> 0
			begin
				rollback tran;
			end
			set @result = -1;
		end catch
	end
	else
		set @result = -1;
end