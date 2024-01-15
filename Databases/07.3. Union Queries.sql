use geography;

(select m.mountain_range as 'name'
from mountains as m
where m.id in (select mc.mountain_id from mountains_countries as mc where mc.country_code = 'BG'))
union
(select r.river_name as `name`
from rivers as r
where r.id in (select cr.river_id from countries_rivers as cr where cr.country_code = 'BG'))
order by `name` asc
limit 5;

# Part 1
use softuni;

# Exercise 1
(select first_name, last_name, '(no manager)' as manager_name
from employees
where manager_id is null)
union
(select e.first_name, e.last_name, (select concat(m.first_name, ' ', m.last_name) from employees as m where m.employee_id = e.manager_id) as manager_name
from employees as e
where e.manager_id is not null)
order by manager_name asc;

# Exercsie 2
(select m.first_name, m.last_name, m.salary, 'manager' as `position`
from employees as m
where exists (select * from employees as e where e.manager_id = m.employee_id)
order by m.salary desc
limit 3)
union
(select e.first_name, e.last_name, e.salary, 'employee' as `position`
from employees as e
where e.manager_id is not null && not exists (select * from employees as i where i.manager_id = e.employee_id)
order by e.salary desc
limit 3)
order by salary desc, first_name asc, last_name asc;

# Part 2
use geography;

# Exercise 4
(select r.river_name as `name`, 'river' as `type`, r.length as `info`
from rivers as r
where exists (select * from countries_rivers as cr where cr.river_id = r.id && cr.country_code = 'BG'))
union
(select m.mountain_range as `name`, 'mountain' as `type`, (select max(p.elevation) from peaks as p where p.mountain_id = m.id) as `info`
from mountains as m
where exists (select * from mountains_countries as mc where mc.mountain_id = m.id && mc.country_code = 'BG'))
union
(select p.peak_name as `name`, 'peak' as `type`, p.elevation as `info`
from peaks as p
where exists (select * from mountains_countries as mc where mc.mountain_id = p.mountain_id && mc.country_code = 'BG'))
order by `name` asc;
