# Part 1
use softuni;

# Exercise 1
select distinct e.job_title, e.salary
from employees as e
where e.salary = (
	select i.salary
    from employees as i
    where i.job_title = e.job_title
    order by i.salary desc
    limit 1
)
order by salary desc, job_title asc;

select j.job_title, (select max(e.salary) from employees as e where e.job_title = j.job_title) as `salary`
from (select distinct e.job_title from employees as e) as j
order by `salary` desc, j.job_title asc;

select job_title, max(salary) as `salary`
from employees
group by job_title
order by `salary` desc, job_title asc;

# Exercise 2
select e.first_name, e.last_name, e.salary, (select d.name from departments as d where d.department_id = e.department_id) as `department`
from employees as e
where e.salary = (
	select min(i.salary)
    from employees as i
    where i.department_id = e.department_id
)
order by e.salary asc, e.first_name asc, e.last_name asc;

# Exercise 3
with manager_ids as (
	select distinct manager_id
	from employees
	where manager_id is not null
)
select m.first_name, m.last_name
from employees as m
where
	m.middle_name is not null
    && m.employee_id in (select * from manager_ids)
    && exists (select * from employees as e where e.manager_id = m.employee_id && e.middle_name = m.middle_name)
order by m.first_name asc, m.last_name asc;

# Exercise 4
select m.first_name, m.last_name
from employees as m
where
	m.employee_id in (select distinct e.manager_id from employees as e)
    && exists (select * from employees as e where e.manager_id = m.employee_id && e.salary > m.salary);

# Exercise 5
select m.first_name, m.last_name
from employees as m
where
	m.employee_id in (select distinct e.manager_id from employees as e)
    && (select count(*) from employees as e where e.manager_id = m.employee_id) = 5
order by m.first_name asc, m.last_name asc;

# Part 2
use geography;

# Exercise 6
select m.mountain_range, (select p.peak_name from peaks as p where p.mountain_id = m.id order by p.elevation desc limit 1) as `peak_name`, (select p.elevation from peaks as p where p.mountain_id = m.id order by p.elevation desc limit 1) as `elevation`
from mountains as m
where m.id in (select mc.mountain_id from mountains_countries as mc where mc.country_code = 'BG')
order by `elevation` desc;

# Exercise 7
select m.mountain_range
from mountains as m
where
	m.id in (select mc.mountain_id from mountains_countries as mc where mc.country_code = 'BG')
	&& not exists (select * from peaks as p where p.mountain_id = m.id);