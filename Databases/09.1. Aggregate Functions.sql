use gringotts;

# Exercise 1
select count(*) as `Count` from wizzard_deposits;

# Exercise 2
select max(magic_wand_size) as `longest_magic_wand` from wizzard_deposits;