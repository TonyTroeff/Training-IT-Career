use gringotts;

# Exercise 1
select w.deposit_group, max(w.magic_wand_size) as `longest_magic_wand`
from wizzard_deposits as w
group by w.deposit_group
order by `longest_magic_wand` asc, w.deposit_group asc;

# Exercise 2
select w.deposit_group
from wizzard_deposits as w
group by w.deposit_group
order by avg(w.magic_wand_size) asc
limit 1;

# Exercise 3
select w.deposit_group, sum(w.deposit_amount) as `total_sum`
from wizzard_deposits as w
group by w.deposit_group
having `total_sum` > 1000000
order by `total_sum` asc;