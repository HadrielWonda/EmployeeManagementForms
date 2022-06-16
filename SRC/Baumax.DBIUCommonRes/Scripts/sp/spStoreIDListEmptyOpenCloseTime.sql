print '%Creating procedure% spStoreIDListEmptyOpenCloseTime'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spStoreIDListEmptyOpenCloseTime' 
)
   DROP PROCEDURE spStoreIDListEmptyOpenCloseTime
GO

CREATE PROCEDURE spStoreIDListEmptyOpenCloseTime
	@UserID bigint
WITH ENCRYPTION
AS
BEGIN
	SET NOCOUNT ON;
	select distinct st.StoreID from dbo.Store st
	left outer join dbo.StoreWorkingTime swt 
	on 
		st.StoreID = swt.StoreID
	where
		swt.StoreWorkingTimeID IS NULL  
		or 
		swt.StoreWorkingTimeID in
		(
			select StoreWorkingTimeID from StoreWTWeekday
			where Closetime = 0
			group by StoreWorkingTimeID
			having count (*)/7 = 1
		)

END
GO
