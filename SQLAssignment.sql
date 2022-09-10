use [sqlassignment]
go

select * from tblcustomer
select * from tblorderitem
select * from tblorder
select * from tblproduct
select * from employee
select * from manager
select * from ship


--creating tables

create table tblproduct
(
Id int not null primary key,
productname nvarchar(50) null,
unitprice decimal(12,3) null,
package nvarchar(30) null
)

alter table tblproduct
add isdiscontinued bit null

alter table tblproduct
add supply nvarchar null

Alter table tblproduct
alter column supply nvarchar(50) null

alter table tblproduct
add category nvarchar(50) null

alter table tblproduct
add unitinstock int null

alter table tblproduct
add unitonorder int null

alter table tblproduct
add shipid int null




create table tblorderitem
(
id int not null primary key,
orderid int null,
productid int null,
unitprice decimal(12,2) null,
quantity int null
)






create table tblorder
(
id int not null primary key,
orderdate datetime null,
ordernumber nvarchar(10) null,
customerid int null,
totalamount decimal(12,2) null
)


alter table tblorder
add shippingName nvarchar(50) null

alter table tblorder
add discountprice int null

alter table tblorder
add shippingDate datetime null






create table tblcustomer
(
id int not null primary key,
firstname nvarchar(40) null,
lastname nvarchar(40) null,
city nvarchar(40) null,
country nvarchar(40) null,
phone nvarchar(40) null,
)

alter table tblcustomer
add faxnumber int null


alter table tblcustomer
alter column faxnumber nvarchar(50) null








create table employee
(
id int not null primary key,
efirstname nvarchar(50) null,
elastname nvarchar(50) null,
esalary int null,
hiredate datetime,
managerid int null
)

alter table employee
add companyName nvarchar(50) null

alter table employee
add departmentName nvarchar(50) null,
ratings int null






create table manager
(
id int not null primary key,
managerName nvarchar(50) null
)



create table ship
(
id int not null primary key,
shipName nvarchar(50) null,
shippingCompanyName nvarchar(50) null
)





--Adding indexes
create index indexproductsupplierid
on tblproduct (id)

create index indexproductname
on tblproduct (productname)


create index indexorderitemorderid
on tblorderitem (orderid)


create index indexorderitemproductid
on tblorderitem (productid)


create index indexordercustomerid
on tblorder (customerid)

create index indexorderorderdate
on tblorder (orderdate)


create index indexcustomername
on tblcustomer (firstname)





--applying foreign keys

Alter table tblorderitem
add constraint tblorderitem_productid_FK
foreign key (productid) references  tblproduct (id)

Alter table tblorderitem
add constraint tblorderitem_orderid_FK
foreign key (orderid) references  tblorder (id)

Alter table tblorder
add constraint tblorder_customerid_FK
foreign key (customerid) references  tblcustomer (id)

Alter table employee
add constraint employee_managerid_FK
foreign key (managerid) references  manager (id)


Alter table tblproduct
add constraint tblproduct_shipid_FK
foreign key (shipid) references  ship (id)








--inserting data

Insert into tblcustomer values(1,'stefan','salvatore',	'kansas','Australia','4552569874'),
(2,	'nina',	'dobrev',	'seoul',	'south korea',	'2369874561'),
(3,	'Akshata',	'choudhari',	'mumbai',	'India',	'3569854723'),
(4, 'alex',	'comen',	'graz',	'Austria',	'5478923457'),
(5,	'heyley',	'iyers',	'tokyo',	'japan',	'6589423178'),
(6,	'sairaj',	'patil',	'mumbai',	'india',	'9954784563'),
(7,'klaus', 'mikelson', 'berlin', 'Germany', '9654782135'),
(8,	'Juana',	'alfonso',	'mumbai',	'india',	'9654782135')

update tblcustomer
set country = 'London'
where id = 1

update tblcustomer
set phone = '5124896475'
where id = 8

update tblcustomer
set firstname = 'parag'
where id = 2


update tblcustomer
set faxnumber = 2356985416
where id = 3

update tblcustomer
set faxnumber = 9578412358
where id = 6


update tblcustomer
set faxnumber = 1245736985
where id = 8












Insert into tblorderitem values
(1,1,1,9.2,2),
(2,3,4,11,1),
(3,2,3,22,3)
Insert into tblorderitem values(4,4,2,15.0,0)

Insert into tblorderitem values(5,8,6,52.12,6),
(6,6,5,89.00,4),
(7,7,8,25.32,0),
(8,5,7,40.00,9)


Insert into tblorder values
(1,2016-06-20,1,1,20.2),
(2,2015-05-15,2,3,30.15),
(3,2012-07-02,3,2,10.2)

Insert into tblorder values
(4,'2013-01-10',6,8,22.2),
(5,'2018-04-15',15,7,30.15),
(6,'2014-07-15',11,6,10.2),
(7,'2017-12-12',22,5,30.15),
(8,'2022-09-23',9,4,10.2)

update tblorder
set shippingName = 'La come d''abondance'
where id = 1

update tblorder
set shippingName = 'La come d''abondance'
where id = 4

update tblorder
set shippingName = 'La come d''abondance'
where id = 3


update tblorder
set shippingDate = '2019-10-19 00:00:00.000'
where id = 1


update tblorder
set discountprice = 15
where id = 8

update tblorder
set orderdate = '2016-06-14 00:00:00.000'
where orderdate = '1905-06-14 00:00:00.000'

update tblorder
set orderdate = '2015-05-19 00:00:00.000'
where orderdate = '1905-06-19 00:00:00.000'

update tblorder
set orderdate = '2012-07-02 00:00:00.000'
where orderdate = '1905-07-02 00:00:00.000'


update tblorder
set ordernumber = 5
where id = 7








Insert into tblproduct values
(1,'abc',15.95,'xyz'),
(2,'xxx',11.9,'aaa'),
(3,'qqq',3.2,'sss'),
(4,'hhh',20.25,'ppp')


Insert into tblproduct values
(5,'rrr',20.25,'box',null,null,'dairyfood'),
(6,'bbb',20.25,'ball',null,null,'stationery'),
(7,'ccc',20.25,'pen',null,null,'stationery'),
(8,'ddd',20.25,'cabbage',null,null,'vegetables')


update tblproduct
set unitprice = 53
where id = 8


update tblproduct
set unitinstock = 15
where id = 8

update tblproduct
set unitonorder = 0
where id = 8

update tblproduct
set category = 'dietfood'
where id = 3

update tblproduct
set supply = 'exotic liquid'
where id = 8


update tblproduct
set shipid = 8
where id = 1









insert into employee values
(1,'harry','potter',25000, '2017-10-13',2),
(2,'sara', 'lang',20000,'2013-02-22',1),
(3,'marty', 'byrde',35000,'2022-07-12',3)

insert into employee values(4,'helen', 'pierce',15000, '2013-01-15',4)


update employee
set companName = 'Coal India'
where id =6

update employee
set departmentName = 'IT'
where id =4


update employee
set ratings =5
where id =4



insert into manager values(4,'steve')

insert into manager values(1,'wendy'),
(2,'noah'),
(3,'ruth')




insert into ship values
(1,'revenge', 'Hindalco Industries'),
(2,'renown', 'flyby'),
(3,'molten', 'valient'),
(4,'solution', 'bravo'),
(5,'mixture', 'rush'),
(6,'flash', 'anka'),
(7,'stable', 'bonded'),
(8,'antimony', 'arcus')






--not null firstname query
alter table tblcustomer
alter column firstname nvarchar(40) not null



--not null orderdate query
alter table tblorder
alter column orderdate datetime not null



--display customer details
select * from tblcustomer



--display Country whose name starts with A or I
select country from tblcustomer where (country LIKE'A%' OR country LIKE'I%')



--display whose name of customer whose third character is i
select firstname from tblcustomer where firstname like '__i%'
 









 --ASSIGNMENT 2

 --details of customer whose country is germany
select * from tblcustomer where country = 'Germany'



 --display full name of employee
select firstname + ' ' + lastname as fullname from tblcustomer



--display customer details who has fax number
select * from tblcustomer where faxnumber <> 'null'



 --display customer details whose name 2nd place is u
select * from tblcustomer where firstname LIKE '_u%'



 --display order details whose unitprice is less than 10 and greater the 20
 select * from tblorderitem where unitprice > 10 AND unitprice < 20



 --display order details that contains shipping date and arrage the order bt date
 select * from tblorder
 order by orderdate




 --print the order details which contain shipping date and arrange order by date
 select * from tblorder 
 order by shippingDate


 --print orders shipped by ship name La come d''abondance between 2 dates
  select * from tblorder where shippingName = 'La come d''abondance'
 and 
 shippingDate between '2019-10-01' and '2019-10-20' 




 --print product supplied bt exotic liquid
 select * from tblproduct where supply = 'exotic liquid' 




 --average quantity of every product
 select productid, avg(quantity) as avgquantity from tblorderitem
 group by productid



 --print shipping company name and ship name
 select * from ship




 --print employees with manager name 
 select efirstname, elastname,esalary, managerName
 from employee
 inner join manager
 on employee.managerid= manager.id

 --OR

 select efirstname+ ' ' + elastname as employeename, managerName
 from employee
  inner join manager
 on employee.managerid= manager.id



 --print the bill for the given orderid,bill should contain productname,categoryname,price after discount
 SELECT tblorderitem.id,tblproduct.productname,tblproduct.category,tblorder.discountprice
 FROM tblorderitem
INNER JOIN tblorder ON tblorder.id=tblorderitem.orderid
INNER JOIN tblproduct ON tblproduct.id=tblorderitem.productid
WHERE tblorderitem.orderid= 4



--print total price of orders which have product supplied by exotic liquids if the price is > 50 and also print it by shipping companys name
 SELECT supply,unitprice AS TOTALPRICE, shippingCompanyName
 FROM tblproduct
INNER JOIN ship 
ON tblproduct.shipid=ship.id
WHERE tblproduct.supply = 'exotic liquid' AND tblproduct.unitprice >50
















 --ASSIGNMENT 3


--display the orders placed by customer with phone number 030-0074321
select firstname, lastname, orderdate,ordernumber, totalamount
from tblcustomer
inner join tblorder
on tblorder.customerid= tblcustomer.id
where phone = '030-0074321'


--fetching all the products which are available under Category ‘Seafood’
select * from tblproduct where category = 'seafood'


--Display the orders placed by customers not in London
select firstname,lastname,orderdate,ordernumber
from tblcustomer
inner join tblorder
on tblorder.customerid = tblcustomer.id
where country != 'London'


--selects all the order which are placed for the product Chai.
select productname, orderid,orderunitprice, quantity
from tblproduct
inner join tblorderitem
on tblorderitem.productid =tblproduct.id
where productname = 'chai'



--Write a query to display the name , department name and rating  of any given employee
select efirstname + ' ' + elastname as [employee name], departmentName, ratings from employee


















--ASSIGNMENT 4



--Print the Total price of orders which have the products supplied by 'Exotic Liquids' if the price is > 50 and also print it by Shipping company's Name
 SELECT supply,unitprice AS TOTALPRICE, shippingCompanyName
 FROM tblproduct
INNER JOIN ship 
ON tblproduct.shipid=ship.id
WHERE tblproduct.supply = 'exotic liquid' AND tblproduct.unitprice >50



--employee details whose joined at first
select * from employee
order by hiredate ASC

--employee details whose joined at recently
select * from employee
order by hiredate DESC


--query to get most expense and least expensive Product list 
select productname,unitprice
from tblproduct 
order by unitprice desc


--query to get most expense and least expensive Product list
select productname,unitprice
from tblproduct 
order by unitprice ASC


--Display the list of products that are out of stock
select productname,unitprice,package,quantity
from tblproduct
inner join tblorderitem
on tblorderitem.productid= tblproduct.id
where quantity=0



--Display the list of products whose unitinstock is less than unitonorder
select productName, unitinstock, unitonorder 
from tblproduct
where unitinstock < unitonorder



--Display list of categories and suppliers who supply products within those categories
select category, supply from tblproduct



--Display complete list of customers, the OrderID and date of any orders they have made
select tblcustomer.firstname, tblcustomer.lastname, tblorderitem.orderid, tblorder.orderdate
from tblcustomer
inner join tblorder
on tblcustomer.id= tblorder.customerid
inner join tblorderitem
on tblorderitem.orderid= tblorder.id





--Write  query that determines the customer who has placed the maximum number of orders
select ordernumber,count(id) as ordercount
from tblorder
group by ordernumber
order by ordercount desc




--Display the customerid whose name has substring ‘RA’
select firstname,lastname, customerid
from tblcustomer
inner join tblorder
on tblcustomer.id= tblorder.customerid
where firstname like '%RA%'





--Display the first word of all the company name
select SUBSTRING(companyName,1,charindex(' ',companyName)-1) as firstword from employee


