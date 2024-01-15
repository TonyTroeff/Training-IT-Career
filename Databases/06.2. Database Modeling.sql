create schema university;
use university;

create table subjects(
	subject_id int(11) not null auto_increment,
    subject_name varchar(50) not null,
    primary key (subject_id)
);

create table majors(
	major_id int(11) not null auto_increment,
    name varchar(50) not null,
    primary key (major_id)
);

create table students(
	student_id int(11) not null auto_increment,
    student_number varchar(12) not null,
    student_name varchar(50) not null,
    major_id int(11) not null,
    primary key (student_id),
    foreign key (major_id) references majors (major_id)
);

create table payments(
	payment_id int(11) not null auto_increment,
    payment_date date not null,
    payment_amount decimal(8, 2) not null,
    student_id int(11) not null,
    primary key (payment_id),
    foreign key (student_id) references students (student_id)
);

create table agenda(
	student_id int(11) not null,
    subject_id int(11) not null,
    primary key (student_id, subject_id),
    foreign key (student_id) references students (student_id),
    foreign key (subject_id) references subjects (subject_id)
);