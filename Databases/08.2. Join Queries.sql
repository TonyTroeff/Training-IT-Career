# Part 1
use softuni;

# Exercise 2
select e.first_name, e.last_name, e.hire_date, d.name as `department_name`
from employees as e
join departments as d
	on e.department_id = d.department_id && d.name in ('Sales', 'Finance')
where e.hire_date > '1999-01-01'
order by e.hire_date asc;

# Exercise 3
select e.employee_id, e.first_name, p.name as `project_name`
from employees as e
join employees_projects as ep
	on ep.employee_id = e.employee_id
join projects as p
	on ep.project_id = p.project_id && p.start_date > '2002-08-13' && p.end_date is null
order by e.first_name asc, p.name asc
limit 5;

# Exercise 4
select e.employee_id, concat(e.first_name, ' ', e.last_name) as `employee_name`, concat(m.first_name, ' ', m.last_name) as `manager_name`, d.name as `department_name`
from employees as e
join employees as m
	on e.manager_id = m.employee_id
join departments as d
	on e.department_id = d.department_id
order by e.employee_id asc
limit 5;

# Part 2
use geography;

# Exercise 5
select mc.country_code, m.mountain_range, p.peak_name, p.elevation
from peaks as p
join mountains as m
	on p.mountain_id = m.id
join mountains_countries as mc
	on mc.mountain_id = m.id && mc.country_code = 'BG'
where p.elevation > 2835
order by p.elevation desc;

# Exercise 6
select c.country_code, c.country_name, m.mountain_range
from countries as c
join mountains_countries as mc
	on mc.country_code = c.country_code
join mountains as m
	on mc.mountain_id = m.id
where c.country_code in ('BG', 'RU', 'US')
order by c.country_code asc, m.mountain_range asc;