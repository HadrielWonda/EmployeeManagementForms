print '%Creating procedure% getNewID'
go

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'getNewID' 
)
   DROP PROCEDURE getNewID
GO

CREATE PROCEDURE getNewID
	@NewID bigint output
WITH ENCRYPTION	
AS
	select  @NewID =  Value from dbo.PKGen where DomainName = 'Entities'
	set @NewID = @NewID + 1
	update PKGen 
	set
		[Value] = @NewID
	where
		DomainName = 'Entities'

GO

