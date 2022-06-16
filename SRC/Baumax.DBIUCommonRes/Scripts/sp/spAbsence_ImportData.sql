print '%Creating procedure% spAbsence_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spAbsence_ImportData' 
)
   DROP PROCEDURE spAbsence_ImportData
GO

create procedure spAbsence_ImportData
	@result int output
WITH ENCRYPTION
as
begin
	set nocount on;
	set @result = 1;
	begin try
		begin tran
			declare @ID bigint
			declare @CountryID bigint
			--Add data to vwAbsence	
			select @CountryID= dbo.getAustriaCountryID ()

			select  @ID =  [Value] from dbo.PKGen with(tablockx) where DomainName = 'Entities'
			insert into dbo.Absence (AbsenceID, SystemID, CountryID, AbsenceTypeID, CharID, Color, UseInCalck, IsFixed, [Value], WithoutFixedTime, Import)
			select  @ID+ ROW_NUMBER() over (order by SystemID) as AbsenceID
				,SystemID
				,@CountryID CountryID
				,1 AbsenceTypeID
				,CharID
				,0
				,0
				,0
				,0
				,1
				,1
			from #abs4insert i
			where not exists (select * from Absence a where a.SystemID = i.SystemID )
			set @ID = @ID + @@rowcount
			
			update AbsenceName
			set
				[Name] = i.[Name]
			from Absence a
			inner join #abs4insert i
			on
				a.SystemID = i.SystemID
			inner join AbsenceName an 
			on 
				an.AbsenceID = a.AbsenceID 

			insert into dbo.AbsenceName (Id, AbsenceID, LanguageID, [Name])
			select 	
				@ID+ ROW_NUMBER() over (order by AbsenceID) HWGR_NameID
				,a.AbsenceID 
				,1
				,i.[Name]
			from Absence a
			inner join #abs4insert i
			on
				a.SystemID = i.SystemID
			where not exists (select * from AbsenceName an where an.AbsenceID = a.AbsenceID )
			set @ID = @ID + @@rowcount

			update PKGen 
			set
			  [Value] = @ID
			where DomainName = 'Entities'
				and [Value] <> @ID
		commit
		select i.SystemID from #abs4insert i 
		where
			not exists (select * from dbo.Absence a where a.SystemID = i.SystemID)
		drop table #abs4insert
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
