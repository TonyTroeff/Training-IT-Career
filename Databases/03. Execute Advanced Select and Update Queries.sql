# Part 1
use softuni;

select *
from departments;

select distinct name
from departments;

select first_name, last_name, salary
from employees;

select first_name, middle_name, last_name
from employees;

select concat(first_name, '.', last_name, '@softuni.bg') AS `full_email_address`
from employees;

# Exercise 6
select distinct salary
from employees
order by salary asc;

# Exercise 7
select *
from employees
where job_title = 'Sales Representative';

# Exercise 8
select first_name, last_name, job_title
from employees
where salary >= 20000 && salary <= 30000;
# where salary between 20000 and 30000;

# Exercise 9
select concat(first_name, ' ', coalesce(middle_name, '?'), ' ', last_name) as `full_name`
from employees
# where salary = 25000 || salary = 14000 || salary = 12500 || salary = 23600;
where salary in (25000, 14000, 12500, 23600);

# Exercise 10
select first_name, last_name
from employees
where manager_id is null;

# Exercise 11
select e.first_name, e.last_name, e.salary
from employees as e
where e.salary > 50000
order by e.salary desc;

# The previous query is equivalent (in this particular case) to:
select first_name, last_name, salary
from employees
where salary > 50000
order by salary desc;

# Exercise 12
select first_name, last_name
from employees
order by salary desc
limit 5;

# Exercise 13
select first_name, last_name
from employees
where department_id != 4;

# Exercise 14
select distinct job_title
from employees
order by job_title asc;

# Exercise 15
select *
from projects
order by start_date asc, name asc
limit 10;

# Exercise 16
select first_name, last_name, hire_date
from employees
order by hire_date desc
limit 7;

# Exercise 17
# Engineering - 1; Tool Design - 2; Marketing - 4; Information Services - 11;
update employees
set salary = salary + 0.12 * salary
where department_id in (1, 2, 4, 11);

select salary
from employees;

# Part 2
use geography;

# Exercise 18
select peak_name
from peaks
order by peak_name asc;

# Exercise 19
select country_name, population
from countries
where continent_code = 'EU'
order by population desc, country_name asc;

# Exercise 20
select country_name, country_code, if(currency_code = 'EUR', 'Euro', 'Not Euro') as `currency`
from countries
order by country_name asc;

# Part 3
use diablo;

# Exercise 21
select name
from characters
order by name asc;