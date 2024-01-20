use geography;

# peak name, elevation, mountain range
select p.peak_name, p.elevation, (select m.mountain_range from mountains as m where p.mountain_id = m.id) as `mountain_range`
from peaks as p;

select p.id, p.peak_name, m.mountain_range
from peaks as p
join mountains as m
	on p.mountain_id = m.id;
    
select *
from mountains as m
left join peaks as p
	on p.mountain_id = m.id
where p.id is null;

# We should be cautious with the joining conditions.
select * from peaks, mountains;
select * from peaks as p join mountains as m on 1 = 1;

# Part 1
use softuni;

# Exercise 1
select e.first_name, e.last_name, a.address_text, t.name as `town`
from employees as e
join addresses as a
	on e.address_id = a.address_id
join towns as t
	on a.town_id = t.town_id;

# In comparison - if we use subqueries only.
select
	e.first_name,
    e.last_name,
    (select a.address_text from addresses as a where e.address_id = a.address_id) as `address_text`,
    (select t.name from towns as t where t.town_id = (select a.town_id from addresses as a where e.address_id = a.address_id)) as `town`
from employees as e;

# Exercise 2
select e.employee_id, e.first_name, e.last_name, d.name as `department_name`
from employees as e
join departments as d
	on e.department_id = d.department_id && d.name = 'Sales'
order by e.employee_id desc;

# Exercise 3
select e.employee_id, e.first_name, e.salary, d.name as `department_name`
from employees as e
join departments as d
	on e.department_id = d.department_id
where e.salary > 15000
order by e.department_id desc
limit 5;

# Exercise 4
select e.employee_id, e.first_name
from employees as e
left join employees_projects as ep
	on ep.employee_id = e.employee_id
where ep.employee_id is null
order by e.employee_id desc
limit 3;

select e.employee_id, e.first_name
from employees as e
where e.employee_id not in (select distinct ep.employee_id from employees_projects as ep)
order by e.employee_id desc
limit 3;

# Exercise 5
select e.employee_id, e.first_name, e.manager_id, m.first_name
from employees as e
join employees as m
	on m.employee_id = e.manager_id && e.manager_id in (3, 7)
order by e.first_name;

# Exercise 6
select e.salary, d.name as `department_name`
from employees as e
join departments as d
	on d.department_id = e.department_id
order by e.salary asc
limit 1;

# Part 2
use geography;

# Exercise 7
select c.country_name
from countries as c
left join mountains_countries as mc
	on mc.country_code = c.country_code
where mc.country_code is null;

select c.country_name
from mountains_countries as mc
right join countries as c
	on mc.country_code = c.country_code
where mc.country_code is null;