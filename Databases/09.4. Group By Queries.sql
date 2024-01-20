use gringotts;

# Exercise 1
select deposit_group, magic_wand_creator, min(deposit_charge) as `min_deposit_charge`
from wizzard_deposits
group by deposit_group, magic_wand_creator
order by magic_wand_creator asc, deposit_group asc;

# Exercise 2
select
	first_name, last_name, age,
    (case 
		when age <= 10 then '[0-10]'
		when age <= 20 then '[11-20]'
		when age <= 30 then '[21-30]'
		when age <= 40 then '[31-40]'
		when age <= 50 then '[41-50]'
		when age <= 60 then '[51-60]'
        else '[61+]'
    end) as `age_group`
from wizzard_deposits
order by `age_group` asc;

select 
	(case 
		when age <= 10 then '[0-10]'
		when age <= 20 then '[11-20]'
		when age <= 30 then '[21-30]'
		when age <= 40 then '[31-40]'
		when age <= 50 then '[41-50]'
		when age <= 60 then '[51-60]'
        else '[61+]'
    end) as `age_group`,
	count(*) as `wizzards_count`
from wizzard_deposits
group by `age_group`
order by `wizzards_count` asc;

# Exercise 3
select left(first_name, 1) as `first_letter`
from wizzard_deposits
where deposit_group = 'Troll Chest'
group by `first_letter`
order by `first_letter` asc;

# Exercise 4
select deposit_group, is_deposit_expired, avg(deposit_interest) as `average_interest`
from wizzard_deposits
where deposit_start_date > '1985-01-01'
group by deposit_group, is_deposit_expired
order by deposit_group desc, is_deposit_expired asc;