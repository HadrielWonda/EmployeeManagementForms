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
	@StoreID bigint
	, @HWGR_ID bigint
	, @WGR_ID bigint
	, @BeginTime smalldatetime
	, @EndTime smalldatetime
	, @result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	


	select * from HWGR_WGR
		where 
			StoreID = @StoreID
			and HWGR_ID  = @HWGR_ID
			and WGR_ID = @WGR_ID
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
				insert into HWGR_WGR (HWGR_WGR_ID, StoreID, HWGR_ID, WGR_ID, BeginTime, EndTime, Import)
				values( @ID, @StoreID, @HWGR_ID, @WGR_ID, dateadd(minute,1,@BeginTime), @EndTime, 0)

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