print '%Creating procedure% spBusinessVolume_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spBusinessVolume_ImportData' 
)
   DROP PROCEDURE spBusinessVolume_ImportData
GO

CREATE PROCEDURE spBusinessVolume_ImportData
	@xmlDocument nvarchar(max)
	,@tableName nvarchar (30)
	,@formatFile nvarchar (255)
	,@result int output
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	set @result = 1;
	begin try
		--begin tran
			declare @docHandle int
			declare @datafield nvarchar(255), @SQL nvarchar(4000)
			exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument
			declare data_Cursor cursor for
			select [name] 
			from openxml(@docHandle, N'/Root/File') 
			  with ([name] nvarchar(255))

			open data_Cursor;

			fetch from data_Cursor
			into @datafield
			while (@@fetch_status = 0)
			begin
				set @SQL= 'BULK INSERT '+ @tableName +
				  ' FROM ''' + @datafield + '''
				   WITH 
					  (
						TABLOCK,
						FORMATFILE = '''+ @formatFile +'''
						,ORDER (Date)
						,ERRORFILE = '''+ @errorFile +'''
						,MAXERRORS = 0
					  )'
				exec sp_executesql @SQL	
				fetch from data_Cursor
				into @datafield
			end;
			close data_Cursor;
			deallocate data_Cursor;

			exec sp_xml_removedocument @docHandle
		--commit 
	end try
	begin catch
		if XACT_STATE() <> 0
		begin
			rollback tran;
		end
		set @result = -1;
	end catch

END
GO
