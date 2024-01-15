use geography;

# Get all peaks from mountains in Bulgaria
select mountain_id
from mountains_countries
where country_code = 'BG';

select peak_name, elevation
from peaks
where mountain_id in (
	select mountain_id
	from mountains_countries
	where country_code = 'BG'
)
order by elevation desc;

use softuni;

# Exercise 1
# In order to solve this problem, we need to know the lowest salary in our company.
# First option:
select salary
from employees
order by salary asc
limit 1;

# Second option:
select min(salary)
from employees;

select first_name, last_name, salary
from employees
where salary = (
	select salary
	from employees
	order by salary asc
	limit 1
);

with min_salary as (select min(salary) from employees)
select first_name, last_name, salary
from employees
where salary = (select * from min_salary);

# Exercise 2
select first_name, last_name, salary
from employees
where salary < 1.1 * (select min(salary) from employees);

with min_salary as (select min(salary) from employees)
select first_name, last_name, salary
from employees
where salary < 1.1 * (select * from min_salary);

# Exercise 3
select distinct manager_id
from employees
where manager_id is not null
order by manager_id asc;

select first_name, last_name, job_title
from employees
where employee_id in (
	select distinct manager_id
	from employees
	where manager_id is not null
)
order by first_name asc, last_name asc;

with managers as (
	select distinct manager_id
    from employees
    where manager_id is not null
)
select first_name, last_name, job_title
from employees
where employee_id in (select * from managers)
order by first_name asc, last_name asc;

# Exercise 4
select town_id
from towns
where name = 'San Francisco';

select a.address_id
from addresses as a
where a.town_id = (
	select t.town_id
	from towns as t
	where name = 'San Francisco'
);

select first_name, last_name
from employees as e
where e.address_id in (
	select a.address_id
	from addresses as a
	where a.town_id = (
		select t.town_id
		from towns as t
		where name = 'San Francisco'
	)
);