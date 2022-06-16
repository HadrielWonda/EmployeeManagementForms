print '%Creating triggers%'
GO

IF OBJECT_ID ('dbo.trStore_insert','TR') IS NOT NULL
   DROP TRIGGER dbo.trStore_insert
GO

print '%Creating trigger% [trStore_insert]'
GO
CREATE TRIGGER dbo.trStore_insert
   ON  dbo.Store
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;
	insert into dbo.Store_World (StoreID, WorldID)
	select i.StoreID, w.WorldID
	from inserted i
	cross join dbo.World w
	where w.WorldTypeID in (1,2)
		
END
GO
