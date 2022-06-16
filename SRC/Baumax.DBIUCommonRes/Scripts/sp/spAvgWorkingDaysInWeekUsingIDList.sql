print '%Creating procedure% spAvgWorkingDaysInWeekUsingIDList'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spAvgWorkingDaysInWeekUsingIDList' 
)
   DROP PROCEDURE spAvgWorkingDaysInWeekUsingIDList
GO

CREATE PROCEDURE spAvgWorkingDaysInWeekUsingIDList
	-- Add the parameters for the stored procedure here
	@CountryID bigint
WITH ENCRYPTION
AS
BEGIN
	set nocount on;
	select distinct 
		AvgWorkingDaysInWeekID ID
	from dbo.AvgWorkingDaysInWeek av
	inner join Absence a
	on
	  av.CountryID = a.CountryID
	where 
	  IsFixed = 1
	  and 
	  ( exists (select * from dbo.AbsenceTimePlanning ap where a.AbsenceID = ap.AbsenceID and datepart(year,ap.Date) = av.Year)
		or 
		exists (select * from dbo.AbsenceTimeRecording ar where a.AbsenceID = ar.AbsenceID and datepart(year,ar.Date) = av.Year)
	   )
	  and av.CountryID = @CountryID
END
GO
