print '%Creating procedure% spAbsenceUsingIDList'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spAbsenceUsingIDList' 
)
   DROP PROCEDURE spAbsenceUsingIDList
GO

CREATE PROCEDURE spAbsenceUsingIDList
	-- Add the parameters for the stored procedure here
	@CountryID bigint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select 
	  AbsenceID ID
	from dbo.Absence a
	where 
	  ( exists (select * from dbo.AbsenceTimePlanning ap where a.AbsenceID = ap.AbsenceID)
		or 
		exists (select * from dbo.AbsenceTimeRecording ar where a.AbsenceID = ar.AbsenceID)
	   )
	  and a.CountryID = @CountryID
END
GO
