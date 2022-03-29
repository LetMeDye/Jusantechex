--task 2
create database JusanTechExercize;
use JusanTechExercize;
--task 2.1
SELECT c.customername, m.firstname FROM Customers c
inner join orders o on c.id = o.customerid 
left join managers m on c.manager_id = m.id 
where amount>10000 and datediff(day, o.date, '2013-01-01')>1
order by c.name asc
--Task 2.2
--creating tables
create table departments(
dept_id int primary key,
dept_name varchar(50))
create table employees(
emp_id int primary key identity(1,1),
emp_name varchar(50),
dept_id int foreign key references departments(dept_id),
salary int)
--populating data
insert into departments values (10, 'IT')
insert into departments values (11, 'Marketing')
insert into employees values('James',10,20000)
insert into employees values('Jack',10,40000)
insert into employees values('Henry',11,60000)
insert into employees values('Tom',11,80000)
insert into employees values('Harry',11,40000)
insert into employees values('Alisa',10,60000)
insert into employees values('Martha',11, 45000)
--task 2.2.1
select * from employees where emp_name like '%m%'
--task 2.2.2
-- If we need to show only the highest salary by dept_id
select 
	max(salary), 
	dept_id 
from 
	employees
group by dept_id
--If we need to show the highest salary by dept_id plus show the owner of the highest salary and the department name
;WITH cteRowNum AS (
    SELECT Dept_ID, Emp_Name, Salary,
           Row_number() OVER(PARTITION BY Dept_ID ORDER BY Salary DESC) AS RowNum
        FROM employees
)
SELECT c.Dept_ID, dept_name, Emp_Name, Salary
    FROM cteRowNum c
	left join departments d on c.dept_id = d.dept_id
	    WHERE RowNum = 1 -- we can select second row, to select the second highest salary by dept_ids
--task 2.2.3
select e.emp_name from employees e
inner join employees e1 on e.salary=e1.salary and e.emp_name<>e1.emp_name
select emp_name from employees where salary in
		(
			select salary 
			from employees 
			group by salary 
			having count(*)>1
		)