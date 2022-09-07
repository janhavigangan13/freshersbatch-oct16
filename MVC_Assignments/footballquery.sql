select * from FootBallLeague


create table FootBallLeague
(
	MatchID int primary key,
	TeamName1 nvarchar(50) not null,
	TeamName2 nvarchar(50) not null, 
	Status1 nvarchar(20) not null, 
	WinningTeam nvarchar(50), 
	Points int not null
)

insert into FootBallLeague values(1001,'Italy', 'France', 'Win', 'France', 4)
insert into FootBallLeague values(1002,'Brazil', 'Portugal', 'Draw', null, 2)
insert into FootBallLeague values(1003,'England', 'Japan', 'Win', 'England', 4)
insert into FootBallLeague values(1004,'USA', 'Russia', 'Win', 'Russia', 4)
insert into FootBallLeague values(1005,'Portugal', 'Italy', 'Draw', null, 2)
insert into FootBallLeague values(1006,'Brazil', 'France', 'Win', 'Brazil', 4)
insert into FootBallLeague values(1007,'England', 'Russia', 'Win', 'Russia', 4)
insert into FootBallLeague values(1008,'Japan', 'USA', 'Draw', null, 2)


create procedure Insertdata
@MatchID int, 
@TeamName1 nvarchar(50),
@TeamName2 nvarchar(50),
@Status1 nvarchar(20),
@WinningTeam nvarchar(50),
@Points int
as
begin
	insert into FootBallLeague(MatchID, TeamName1, TeamName2, Status1, WinningTeam, Points)
	values (@MatchID, @TeamName1,@TeamName2,@Status1,@WinningTeam,@Points)
end




select TeamName1,TeamName2 from FootBallLeague where Status1 = 'Win'

select * from FootBallLeague where TeamName1 ='Japan' OR  TeamName2 ='Japan'


