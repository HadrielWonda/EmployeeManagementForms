IF OBJECT_ID ('dbo.trEmployee_Relations_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.trEmployee_Relations_insert
GO

print '%Creating trigger% [trEmployee_Relations_insert]'
GO
CREATE TRIGGER dbo.trEmployee_Relations_insert
   ON  dbo.Employee_Relations
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	declare @WorldID bigint
	select @WorldID = WorldID from dbo.World where WorldTypeID = 1
	update Employee_Relations
	set 
		WorldID = @WorldID
	where WorldID is null		
END
GO
