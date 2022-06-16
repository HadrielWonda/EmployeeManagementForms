print '%Creating view% vwEmployeeRelations'
go

if object_id(N'dbo.vwEmployeeRelations', 'V') is not null
	drop view dbo.vwEmployeeRelations
go

create view dbo.vwEmployeeRelations as
select 
	e.EmployeeID
	, PersID
	, LastName
	, FirstName
	, ec.ContractBegin	
	, ec.ContractEnd
	, Import
	, MainStoreID
	, ec.ContractWorkingHours
	, OldHolidays
	, NewHolidays
	, BalanceHours
	, CreateDate
	, StoreID
	, WorldID
	, HWGR_ID
	, BeginTime
	, EndTime
	, EmployeeContractID
	, Employee_RelationsID
from dbo.Employee e
inner join dbo.Employee_Relations er
on
	e.EmployeeID = er.EmployeeID
left outer join EmployeeContract ec
on
	e.EmployeeID = ec.EmployeeID
	and ec.EmployeeContractID  = (select top 1 EmployeeContractID from dbo.EmployeeContract cc where e.EmployeeID = cc.EmployeeID order by ContractBegin desc)
go
/*
CREATE TABLE T1 (
  C1 varchar (50) )

CREATE TABLE T2 (
  D1 varchar (20),
  D2 float,
  D3 datetime,
  D4 int
   )

INSERT INTO T1 VALUES ('aaa1')
INSERT INTO T1 VALUES ('bbb1')
INSERT INTO T1 VALUES ('ccc1')
INSERT INTO T1 VALUES ('ddd1')
INSERT INTO T2 VALUES ('aaa1',10.55,'2006-04-07 11:12:39',1)
INSERT INTO T2 VALUES ('aaa1',10.58,'2006-04-06 11:10:39',2)
INSERT INTO T2 VALUES ('bbb1',5.4,'2006-04-07 11:12:40',3)
INSERT INTO T2 VALUES ('bbb1',5.6,'2006-04-07 11:12:45',4)
INSERT INTO T2 VALUES ('ddd1',3.2,'2006-04-07 11:12:49',5)
INSERT INTO T2 VALUES ('ddd1',3.3,'2006-04-06 11:12:50',6)
INSERT INTO T2 VALUES ('ccc1',7.7,'2006-04-07 11:12:10',7)
INSERT INTO T2 VALUES ('ccc1',7.6,'2006-04-07 11:12:15',8)
INSERT INTO T2 VALUES ('ccc1',7.7,'2006-04-07 11:12:10',9)
INSERT INTO T2 VALUES ('ccc1',7.5,'2006-04-07 11:12:15',10)
INSERT INTO T2 VALUES ('eee1',9.6,'2006-04-07 10:12:15',11)
INSERT INTO T2 VALUES ('eee1',9.7,'2006-04-07 10:12:10',12)
INSERT INTO T2 VALUES ('fff1',8.6,'2006-04-07 10:12:15',13)

select T2.*
from T1
  inner join T2 on
    T1.C1 = T2.D1
  inner join (select D1, max(D3) as D3 from T2 group by D1) T22 on
    T2.D1 = T22.D1 and T2.D3 = T22.D3

select T2.*
from T1
  inner join T2 on
    T1.C1 = T2.D1
and T2.D4 = (select top 1 D4 from T2 where T1.C1 = T2.D1  order by D3 desc)

DROP TABLE T1
DROP TABLE T2
*/
