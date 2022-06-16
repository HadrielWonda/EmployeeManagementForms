print '%Creating procedure% spWGR_HWGR_Assign'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spWGR_HWGR_Assign' 
)
   DROP PROCEDURE spWGR_HWGR_Assign
GO

create procedure spWGR_HWGR_Assign
	@HWGR_WGR_ID bigint
	, @World_HWGR_ID bigint
	, @BeginTime smalldatetime
	, @EndTime smalldatetime
	, @result int output
WITH ENCRYPTION
as
begin
	set nocount on;
/*	
	declare @WGR_ID  bigint, @IN_HWGR_WGR_ID bigint, @ID bigint

	select @WGR_ID= WGR_ID from HWGR_WGR where HWGR_WGR_ID = @HWGR_WGR_ID

	select top 1 @IN_HWGR_WGR_ID= HWGR_WGR_ID from HWGR_WGR
		where 
			World_HWGR_ID = @World_HWGR_ID
			and WGR_ID = @WGR_ID
			and (BeginTime < @BeginTime and  @EndTime < EndTime)
		order by BeginTime desc

	select * from HWGR_WGR
		where 
			HWGR_WGR_ID <> isnull(@IN_HWGR_WGR_ID,-1)
			and World_HWGR_ID = @World_HWGR_ID
			and WGR_ID = @WGR_ID
			and( 
					(@BeginTime between BeginTime and EndTime or @EndTime between BeginTime and EndTime) 
					or (@BeginTime < BeginTime and  EndTime < @EndTime)
				)

if @@rowcount = 0
begin
	begin try
		begin tran

			select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'

			select @ID = @ID + 1
			insert into HWGR_WGR (HWGR_WGR_ID, World_HWGR_ID, WGR_ID, BeginTime, EndTime, Import)
			select @ID, World_HWGR_ID, WGR_ID, dateadd(minute,1,@EndTime), EndTime, Import from HWGR_WGR
			where
				HWGR_WGR_ID = @HWGR_WGR_ID


			update HWGR_WGR
			set
				EndTime = @BeginTime
			where HWGR_WGR_ID = @HWGR_WGR_ID

			select @ID = @ID + 1
			insert into HWGR_WGR (HWGR_WGR_ID, World_HWGR_ID, WGR_ID, BeginTime, EndTime, Import)
			values (@ID, @World_HWGR_ID, @WGR_ID, dateadd(minute,1,@BeginTime), @EndTime, 0)

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
*/	
	set @result = 1;	
end