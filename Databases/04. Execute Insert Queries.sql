use softuni;

insert into towns(name) values ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas');

select *
from towns;

insert into departments(name, manager_id) values ('Software Development', 292);

select *
from departments;

insert into employees(first_name, last_name, middle_name, job_title, department_id, hire_date, salary)
values 
	('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 17, '2013-02-01', 3500),
	('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004-03-02', 4000);

select *
from employees;