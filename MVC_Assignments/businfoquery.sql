select * from BusInfo


create table BusInfo
(
BusID int identity(1,1) primary key,
BoardingPoint nvarchar(20) not null,
TravelDate date not null,
Amount decimal(10,5) not null,
Rating int not null
)

insert into BusInfo values('BGL','2017-06-18',400.65,2)
insert into BusInfo values('HYD','2017-05-10',600.00,3)
insert into BusInfo values('CHN','2016-07-25',445.95,3)
insert into BusInfo values('PUN','2017-12-10',543.00,4)
insert into BusInfo values('MUM','2017-01-28',500.50,4)
insert into BusInfo values('PUN','2016-03-27',333.55,3)
insert into BusInfo values('MUM','2016-11-06',510.00,4)


create procedure insertdataInBusinfo
@boardingpts nvarchar(20),
@traveldate date,
@amount decimal(10,5),
@rate int
as
begin
	Insert into BusInfo(BoardingPoint,TravelDate,Amount, Rating) 
	values(@boardingpts,@traveldate,@amount,@rate)
end


create procedure spAmountGreaterThan
as
begin
select BoardingPoint, TravelDate from BusInfo where Amount> 450
end 

create procedure spGivenTraveldate
as
begin
select BusID, BoardingPoint  from BusInfo where TravelDate = '2017-12-10'
end


select * from BusInfo where BoardingPoint = 'MUM'