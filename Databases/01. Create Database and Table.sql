create schema softuni;
use softuni;

create table towns(
	id bigint unsigned not null auto_increment,
    name varchar(1000),
    primary key (id)
);

alter table towns
	modify column name varchar(1000) not null;

create table addresses(
	id bigint unsigned not null auto_increment,
    address_text text not null,
    town_id bigint unsigned not null,
	primary key (id),
    foreign key (town_id) references towns (id)
);

create table departments(
	id bigint unsigned not null auto_increment,
    name varchar(1000) not null,
    primary key (id)
);

create table employees(
	id bigint unsigned not null auto_increment,
    first_name varchar(200) not null,
    middle_name varchar(200) null,
    last_name varchar(200) not null,
    job_title varchar(1000) not null,
    department_id bigint unsigned not null,
    hire_date date not null,
    salary decimal(20, 5) not null,
    address_id bigint unsigned not null,
    primary key (id),
    foreign key (department_id) references departments (id),
    foreign key (address_id) references addresses (id)
);