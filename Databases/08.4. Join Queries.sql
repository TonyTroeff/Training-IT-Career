# Part 1
use softuni;

# Exercise 1
select e.employee_id, e.first_name, if(p.start_date < '2005-01-01', p.name, null) as `project_name`
from employees as e
join employees_projects as ep
	on ep.employee_id = e.employee_id
join projects as p
	on ep.project_id = p.project_id
where e.employee_id = 24
order by `project_name` asc;

select e.employee_id, e.first_name, p.name as `project_name`
from employees as e
join employees_projects as ep
	on ep.employee_id = e.employee_id
left join projects as p
	on ep.project_id = p.project_id && p.start_date < '2005-01-01'
where e.employee_id = 24
order by `project_name` asc;

# Part 2
use geography;

# Exercise 2
select c1.continent_name, c2.continent_name
from continents as c1, continents as c2
order by c1.continent_name asc, c2.continent_name asc;

select c1.continent_name, c2.continent_name
from continents as c1
cross join continents as c2
order by c1.continent_name asc, c2.continent_name asc;