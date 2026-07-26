use CRMDB;

---------------------------------- Customer----------
select *
from [Demo-VM].crmdb.dbo.customer;

insert into dbo.Customer( FullName, Age, BirthDate,salary)
values ('moaz',55,'4-4-2009',3333.4);

update dbo.Customer
set salary=4000
where id=2;

delete from dbo.Customer;
---------------------------------- Complaint----------
select *
from [Demo-VM].crmdb.dbo.complaint;

insert into dbo.Complaint( CustID, Description)
values (2,'toy not working');

update dbo.Complaint
set Description='NA'
where id=1;

delete from dbo.Complaint;

-----------------------------------------------------------------
-- Get All customers with age > 30 (Filter)
select id
	   ,FullName
	   ,age
	   ,BirthDate
	   ,salary
from dbo.Customer
where age >30 and salary>400;
----------------------------------------------------

select id
	   ,FullName
	   ,age
	   ,BirthDate
	   ,salary
from dbo.Customer
where FullName like '%al%' ;
-----------------------------------------------
select FullName
	   ,age
	   ,salary
from dbo.Customer
order by salary desc;

------------------------------------------
select max(salary) as 'MaxSalary'
from dbo.Customer;

select min(salary) as 'MinSalary'
from dbo.Customer;


select avg(salary) as 'AvgSalary'
from dbo.Customer;

-------------------------------------------
select cust.ID as customerID
		,cust.FullName
		,cust.salary
		,comp.id as complaintID
		,comp.Description
		,comp.status
from dbo.customer as cust inner join dbo.complaint as comp
on cust.ID = comp.CustID;

-------------------------------------
select cust.ID as customerID
		,cust.FullName
		,comp.id as complaintID
		,comp.Description
from dbo.customer as cust left outer join dbo.complaint as comp
on cust.ID = comp.CustID;
-----------------------------------
select cust.ID as customerID
		,cust.FullName
		,comp.id as complaintID
		,comp.Description
from dbo.customer as cust right outer join dbo.complaint as comp
on cust.ID = comp.CustID;
-----------------------------------
select cust.ID as customerID
		,cust.FullName
		,comp.id as complaintID
		,comp.Description
from dbo.customer as cust full outer join dbo.complaint as comp
on cust.ID = comp.CustID
where cust.ID is null or comp.CustID is null;
-----------------------------------

select cust.FullName
	   ,count(cust.FullName) as NumberOfComplaints
from dbo.customer as cust inner join dbo.complaint as comp
on cust.ID = comp.CustID
group by cust.FullName
having count(cust.fullname)>1
order by NumberOfComplaints desc

-----------------------------------
-- Get customers whom Age > 30 and salary > 300 and 
-- created more than 2 complaints

select cust.FullName
      , count(cust.FullName) as NumberOfComplaints
from dbo.Customer as cust inner join dbo.Complaint as comp
on cust.ID = comp.CustID
where cust.age > 30 and cust.salary>300
group by cust.FullName
having count(cust.FullName)>2
order by cust.FullName;
--------------------------------------------
-- Get Total Salary for of customers for each type complaints
-- ComplainType  |   TotalSalary
-- InProgress    |   4000
-- Opened        |   4000
-- Closed        |   4000


select cust.ID as customerID
		,cust.FullName
		,cust.salary
		,comp.id as complaintID
		,comp.Description
		,comp.status
from dbo.customer as cust inner join dbo.complaint as comp
on cust.ID = comp.CustID;


select comp.status,
	   sum(cust.salary) as TotalCustomerSalary
from dbo.customer as cust inner join dbo.complaint as comp
on cust.ID = comp.CustID
group by comp.status