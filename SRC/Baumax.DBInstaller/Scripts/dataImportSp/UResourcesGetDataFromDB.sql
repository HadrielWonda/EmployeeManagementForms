--select count (*) from UIResources
--Get data for UI resources
select ResourceID, LanguageID, Resource from UIResources 
order by LanguageID, ResourceID
FOR XML AUTO


select ResourceID, LanguageID, max(UIResourceID) UIResourceID into #t 
from UIResources
group by ResourceID, LanguageID
having count (*) > 1

/*
select * from #t
select * from UIResources
*/
delete from dbo.UIResources 
where exists 
(
	select * from #t t
		where UIResources.ResourceID = t.ResourceID and UIResources.LanguageID = t.LanguageID and UIResources.UIResourceID <> t.UIResourceID
)

drop table #t


update UIResources
set
	LanguageID= 2
where
	LanguageID = 1003
go
update UIResources
set
	LanguageID= 3
where
	LanguageID = 27009
go
update UIResources
set
	LanguageID= 4
where
	LanguageID = 27010
go

update UIResources
set
	LanguageID= 5
where
	LanguageID = 27011
go

update UIResources
set
	LanguageID= 6
where
	LanguageID = 27012
go

update UIResources
set
	LanguageID= 7
where
	LanguageID = 27013
go

update UIResources
set
	LanguageID= 8
where
	LanguageID = 27014
go

