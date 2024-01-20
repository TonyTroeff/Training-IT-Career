create schema exam_prep_3;
use exam_prep_3;

# Exercise 1
create table characteristics(
	characteristic_id int not null auto_increment,
    title varchar(255) not null,
    primary key (characteristic_id)
);

create table users(
	user_id int not null auto_increment,
    username varchar(50) not null,
    email varchar(255) not null,
    password varchar(255) not null,
    first_name varchar(255) not null,
    last_name varchar(255) not null,
    birthdate date not null,
    gender enum('m', 'f') not null,
    bio text,
    latitude double not null,
    longitude double not null,
    profile_picture varchar(50),
    primary key (user_id)
);

create table characteristics_users(
	characteristic_id int not null,
    user_id int not null,
    value varchar(255) not null,
    primary key (characteristic_id, user_id),
    foreign key (characteristic_id) references characteristics (characteristic_id),
    foreign key (user_id) references users (user_id)
);

create table likes(
	liked_by_user_id int not null,
    liked_user_id int not null,
    primary key (liked_by_user_id, liked_user_id),
    foreign key (liked_by_user_id) references users (user_id),
    foreign key (liked_user_id) references users (user_id)
);

create table connections(
	connection_id int not null auto_increment,
    from_user_id int not null,
    to_user_id int not null,
    accepted bool not null default 0,
    primary key (connection_id),
    foreign key (from_user_id) references users (user_id),
    foreign key (to_user_id) references users (user_id)
);

# Exercise 2
select title
from characteristics
order by title asc
limit 5;

# Exercise 3
select from_user_id, to_user_id, accepted
from connections
where from_user_id = 481 && accepted = 1
order by to_user_id desc;

# Exercise 4
select u.username
from users as u
order by (select count(*) from likes as l where l.liked_user_id = u.user_id) desc, u.user_id desc
limit 3;

select u.username
from users as u
join likes as l
	on l.liked_user_id = u.user_id
group by u.user_id
order by count(*) desc, u.user_id desc
limit 3;

# Exercise 5
select u.user_id, u.username, u.first_name, u.last_name
from users as u
where u.user_id not in (select distinct l.liked_user_id from likes as l)
order by u.first_name asc, u.last_name asc
limit 10;

select u.user_id, u.username, u.first_name, u.last_name
from users as u
left join likes as l
	on l.liked_user_id = u.user_id
where l.liked_user_id is null
order by u.first_name asc, u.last_name asc
limit 10;

# Exercise 6
select u.username
from users as u
where u.gender = 'f' && birthdate >= '1990-01-01' && birthdate <= '1999-12-31'
	&& exists (select * from characteristics_users as cu where cu.characteristic_id = 3 && cu.user_id = u.user_id && value = 'blue')
order by u.username desc;

select u.username
from users as u
where u.gender = 'f' && birthdate >= '1990-01-01' && birthdate <= '1999-12-31'
	&& u.user_id in (select distinct cu.user_id from characteristics_users as cu where cu.characteristic_id = 3 && value = 'blue')
order by u.username desc;

select u.username
from users as u
join characteristics_users as cu
	on cu.user_id = u.user_id
where u.gender = 'f' && birthdate >= '1990-01-01' && birthdate <= '1999-12-31' && cu.characteristic_id = 3 && cu.value = 'blue'
order by u.username desc;

# Exercise 7
select 175.89 as `average_height`;

select round(avg(value), 2) as `average_height`
from characteristics_users
where characteristic_id = 1;

# Exercise 7
select u1.username as `liked_by`, u2.username as `liked`, cu1.value as `liked_by_eye_color`, cu2.value as `liked_eye_color`
from likes as l
join users as u1
	on l.liked_by_user_id = u1.user_id
join characteristics_users as cu1
	on cu1.user_id = u1.user_id && cu1.characteristic_id = 3
join users as u2
	on l.liked_user_id = u2.user_id
join characteristics_users as cu2
	on cu2.user_id = u2.user_id && cu2.characteristic_id = 3
order by u1.username asc, u2.username asc
limit 5;