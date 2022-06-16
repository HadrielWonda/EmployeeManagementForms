print '%Updating database to version% 0.0.6'
go

ALTER TABLE dbo.EmployeeWeekTimePlanning ADD
	AllIn bit NOT NULL CONSTRAINT DF_EmployeeWeekTimePlanning_AllIn DEFAULT 0
go

ALTER TABLE dbo.EmployeeWeekTimeRecording ADD
	AllIn bit NOT NULL CONSTRAINT DF_EmployeeWeekTimeRecording_AllIn DEFAULT 0
go

update EmployeeWeekTimePlanning
set
	AllIn = a.AllIn
from dbo.EmployeeWeekTimePlanning p
inner join dbo.EmployeeAllIn a
on
  p.EmployeeID = a.EmployeeID
  and ((WeekBegin between BeginTime and EndTime) or (WeekEnd between BeginTime and EndTime))
where 
  	a.AllIn = 1
go

update EmployeeWeekTimeRecording
set
	AllIn = a.AllIn
from dbo.EmployeeWeekTimeRecording r
inner join dbo.EmployeeAllIn a
on
  r.EmployeeID = a.EmployeeID
  and ((WeekBegin between BeginTime and EndTime) or (WeekEnd between BeginTime and EndTime))
where 
  	a.AllIn = 1
go

exec dbo.spDBVersionSet '0.0.6'
go