use master 
go

if exists(select * from sysdatabases where [name] = '%dbName%')
begin
print '%Droping database% %dbName%'

declare @SpId smallint
declare @DbId smallint
declare @SQL nvarchar(4000)
select 
	 @DbId = DbId 
from 
	master..sysdatabases
where
	[name] = '%dbName%'

declare sp_complete_cursor  cursor FAST_FORWARD for 
	select 
		spid
	from
		master..sysprocesses nolock
	where
		dbid=@DbId AND spid<>@@spid

	open sp_complete_cursor
	fetch next from sp_complete_cursor into @SpId
	while @@FETCH_STATUS = 0
		begin
			set @SQL = 'KILL ' + convert(VARCHAR(4), @spid)
			exec sp_ExecuteSQL @SQL
			fetch next from sp_complete_cursor into @SpId
		end
	close sp_complete_cursor
	deallocate sp_complete_cursor
	
	drop database [%dbName%]
	
end
go