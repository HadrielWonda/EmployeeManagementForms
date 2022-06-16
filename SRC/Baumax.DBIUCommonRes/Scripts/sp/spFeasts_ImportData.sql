print '%Creating procedure% spFeasts_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spFeasts_ImportData' 
)
   DROP PROCEDURE spFeasts_ImportData
GO

create procedure spFeasts_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	begin try
		begin tran
		set @result = 1;
		declare @ID bigint
		select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'
		insert into dbo.Feasts (FeastsID, CountryID, FeastDate)
		select 
			@ID+ROW_NUMBER() over (order by i.CountryID) as FeastsID
			, c.CountryID
			, i.[Date]
		from #feast4insert i 
		inner join dbo.Country c
		on
			i.CountryID = c.SystemID1
		where not exists (select * from dbo.Feasts f where c.SystemID1 = i.CountryID and f.FeastDate = i.[Date])

		update PKGen 
		set
		  [Value] = @@rowcount + @ID
		where DomainName = 'Entities'
		commit
		
		select i.CountryID, i.Date from #feast4insert i
		where not exists (select * from dbo.Country c where i.CountryID = c.SystemID1)
		drop table #feast4insert
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
