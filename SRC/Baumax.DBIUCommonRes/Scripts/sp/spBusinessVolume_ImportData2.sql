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
	@importFile nvarchar (255)
	,@tableName nvarchar (30)
	,@formatFile nvarchar (255)
	,@errorFile nvarchar (255)
	,@result int output
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	set @result = 1;
	begin try
			declare @SQL nvarchar(4000)

			set @SQL= 'BULK INSERT '+ @tableName +
			  ' FROM ''' + @importFile + '''
			   WITH 
				  (
					TABLOCK,
					FORMATFILE = '''+ @formatFile +'''
					,ORDER (Date)
					,ERRORFILE = '''+ @errorFile +'''
					,MAXERRORS = 0
				  )'
			exec sp_executesql @SQL	
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
