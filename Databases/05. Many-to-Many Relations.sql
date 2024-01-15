create schema if not exists demo;
use demo;

create table employees(
	id bigint unsigned not null auto_increment,
    first_name varchar(200) not null,
    last_name varchar(200) not null,
    job_position varchar(1000),
    primary key (id)
);

create table projects(
	id bigint unsigned not null auto_increment,
    name varchar(200) not null,
    budget decimal(25, 5),
    primary key (id)
);

# One `employee` can work within many `projects`.
# Within a single `project` can work many `employees`.
# This means that we need `many-to-many` relationship!
create table employees_projects(
	employee_id bigint unsigned not null,
    project_id bigint unsigned not null,
    primary key (employee_id, project_id),
    foreign key (employee_id) references employees (id),
    foreign key (project_id) references projects (id)
);