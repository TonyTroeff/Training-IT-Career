# Part 1
use geography;

# Exercise 1
select c.country_name, r.river_name
from countries as c
left join countries_rivers as cr
	on cr.country_code = c.country_code
left join rivers as r
	on cr.river_id = r.id
where c.continent_code = 'AF'
order by c.country_name asc
limit 5;

# Exercise 2
select c.country_name
from countries as c
left join mountains_countries as mc
	on mc.country_code = c.country_code
where mc.country_code is null;

# Exercise 3
select m.mountain_range, p.peak_name, p.elevation
from mountains as m
join mountains_countries as mc
	on mc.mountain_id = m.id && mc.country_code = 'BG'
left join peaks as p
	on p.mountain_id = m.id && p.elevation = (select max(i.elevation) from peaks as i where i.mountain_id = m.id)
order by p.elevation desc;