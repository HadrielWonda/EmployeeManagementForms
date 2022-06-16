print '%Creating procedure% spXmlResource_ImportData'

-- Drop stored procedure if it already exists
IF EXISTS (
  SELECT * 
    FROM INFORMATION_SCHEMA.ROUTINES 
   WHERE SPECIFIC_SCHEMA = N'dbo'
     AND SPECIFIC_NAME = N'spXmlResource_ImportData' 
)
   DROP PROCEDURE spXmlResource_ImportData
GO

create procedure spXmlResource_ImportData
	@resNumber int
	,@xmlDocument nvarchar(max)
WITH ENCRYPTION
as
begin
	set nocount on;
	declare @docHandle int
	declare @mysql nvarchar(4000)
	exec sp_xml_preparedocument @docHandle OUTPUT, @xmlDocument
	if (@resNumber = 1)
		set @mysql='insert into dbo.Country (CountryID, SystemID1, SystemID2, LanguageID, Import, WarningDays, MaxDays)
		select CountryID, SystemID1, SystemID2, LanguageID, Import, WarningDays, MaxDays
		from openxml(@docHandle, N''/Root/Country'') 
		  with Country'
	else if (@resNumber = 2)
		set @mysql='insert into dbo.CountryName (Id, CountryID, LanguageID, Name)
		select Id, CountryID, LanguageID, Name
		from openxml(@docHandle, N''/Root/CountryName'') 
		  with CountryName'
	else if (@resNumber = 3)
		set @mysql='insert into dbo.Region (RegionID, RegionSysID, CountryID, Import)
		select RegionID, RegionSysID, CountryID, Import
		from openxml(@docHandle, N''/Root/Region'') 
		  with Region'
	else if (@resNumber = 4)
		set @mysql='insert into dbo.RegionName (Id, RegionID, LanguageID, Name)
		select Id, RegionID, LanguageID, Name
		from openxml(@docHandle, N''/Root/RegionName'') 
		  with RegionName'
	else if (@resNumber = 5)
		set @mysql='insert into dbo.Store (StoreID, RegionID, SystemID, Number, City, Address, Area, Import)
		select StoreID, RegionID, SystemID, Number, City, Address, Area, Import
		from openxml(@docHandle, N''/Root/Store'') 
		  with Store'
	else if (@resNumber = 6)
		set @mysql='insert into dbo.StoreName (Id, StoreID, LanguageID, Name)
		select Id, StoreID, LanguageID, Name
		from openxml(@docHandle, N''/Root/StoreName'') 
		  with StoreName'
	else if (@resNumber = 7)
		set @mysql='insert into dbo.Feasts (FeastsID, CountryID, FeastDate)
		select FeastsID, CountryID, FeastDate
		from openxml(@docHandle, N''/Root/Feasts'') 
		  with Feasts'
	else if (@resNumber = 8)
		set @mysql='insert into dbo.YearlyWorkingDays (YearlyWorkingDaysID, CountryID, WorkingDay)
		select YearlyWorkingDaysID, CountryID, WorkingDay
		from openxml(@docHandle, N''/Root/YearlyWorkingDays'') 
		  with YearlyWorkingDays'
	else if (@resNumber = 9)
		set @mysql='insert into dbo.Absence (AbsenceID, SystemID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, Value, WithoutFixedTime, Import)
		select AbsenceID, SystemID, CountryID, AbsenceTypeID, Color, CharID, UseInCalck, IsFixed, Value, WithoutFixedTime, Import
		from openxml(@docHandle, N''/Root/Absence'') 
		  with Absence'
	else if (@resNumber = 10)
		set @mysql='insert into dbo.AbsenceName (Id, AbsenceID, LanguageID, Name)
		select Id, AbsenceID, LanguageID, Name
		from openxml(@docHandle, N''/Root/AbsenceName'') 
		  with AbsenceName'
	else if (@resNumber = 11)
		set @mysql='insert into dbo.LongTimeAbsence (CountryID, Code, CodeName, CharID, Import)
		select CountryID, Code, CodeName, CharID, Import
		from openxml(@docHandle, N''/Root/LongTimeAbsence'') 
		  with LongTimeAbsence'
	else if (@resNumber = 12)
		set @mysql='insert into dbo.WorkingModel (WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges)
		select WorkingModelID, CountryID, Data, ConditionType, MultiplyValue, AddValue, BeginTime, EndTime, AddCharges
		from openxml(@docHandle, N''/Root/WorkingModel'') 
		  with WorkingModel'
	else if (@resNumber = 13)
		set @mysql='insert into dbo.WorkingModelName (Id, WorkingModelID, LanguageID, Name)
		select Id, WorkingModelID, LanguageID, Name
		from openxml(@docHandle, N''/Root/WorkingModelName'') 
		  with WorkingModelName'
	else if (@resNumber = 14)
		set @mysql='insert into dbo.StoreWorkingTime (StoreWorkingTimeID, StoreID, BeginTime, EndTime)
		select StoreWorkingTimeID, StoreID, BeginTime, EndTime
		from openxml(@docHandle, N''/Root/StoreWorkingTime'') 
		  with StoreWorkingTime'
	else if (@resNumber = 15)
		set @mysql='insert into dbo.StoreWTWeekday (StoreWTWeekdayID, StoreWorkingTimeID, Weekday, Opentime, Closetime)
		select StoreWTWeekdayID, StoreWorkingTimeID, Weekday, Opentime, Closetime
		from openxml(@docHandle, N''/Root/StoreWTWeekday'') 
		  with StoreWTWeekday'
	else if (@resNumber = 16)
		set @mysql='insert into dbo.CountryPersShowMode (CountryID, PersShowMode)
		select CountryID, PersShowMode
		from openxml(@docHandle, N''/Root/CountryPersShowMode'') 
		  with CountryPersShowMode'
	else if (@resNumber = 17)
		set @mysql='insert into dbo.CountryReportingIdentifier (CountryID, ReportID, ReportName)
		select CountryID, ReportID, ReportName
		from openxml(@docHandle, N''/Root/CountryReportingIdentifier'') 
		  with CountryReportingIdentifier'


	exec sp_executesql @mysql, N'@docHandle int', @docHandle = @docHandle
	exec sp_xml_removedocument @docHandle
end
GO
