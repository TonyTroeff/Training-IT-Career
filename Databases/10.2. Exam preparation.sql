create schema exam_prep_2;
use exam_prep_2;

create table planets(
	id int not null auto_increment,
    name varchar(30) not null,
    primary key (id)
);

create table spaceports(
	id int not null auto_increment,
    name varchar(50) not null,
    planet_id int not null,
    primary key (id),
    foreign key (planet_id) references planets (id)
);

create table spaceships(
	id int not null auto_increment,
    name varchar(50) not null,
    manufacturer varchar(30) not null,
    light_speed_rate int default 0,
    primary key (id)
	# check (light_speed_rate >= 0)
);

create table colonists(
	id int not null auto_increment,
    first_name varchar(20) not null,
    last_name varchar(20) not null,
    ucn char(10) not null,
    birth_date date not null,
    primary key (id),
    unique (ucn)
);

create table journeys(
	id int not null auto_increment,
    journey_start datetime not null,
    journey_end datetime not null,
    purpose enum('Medical', 'Technical', 'Educational', 'Military') not null,
    destination_spaceport_id int not null,
    spaceship_id int not null,
    primary key (id),
    foreign key (destination_spaceport_id) references spaceports (id),
    foreign key (spaceship_id) references spaceships (id)
);

create table travel_cards(
	id int not null auto_increment,
    card_number char(10) not null,
    job_during_journey enum('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook') not null,
    colonist_id int not null,
    journey_id int not null,
    primary key (id),
    unique (card_number),
    foreign key (colonist_id) references colonists (id),
    foreign key (journey_id) references journeys (id)
);

# Exercise 2
insert into travel_cards (card_number, job_during_journey, colonist_id, journey_id)
values
	('1994191458', 'Pilot', 96, 1),
    ('1981222886', 'Engineer', 97, 2),
    ('197090435', 'Pilot', 98, 9),
    ('196318580', 'Cook', 99, 5),
    ('196715685', 'Pilot', 100, 1);

# Exercise 3
update journeys
set purpose = 'Military'
where mod(id, 7) = 0;

update journeys
set purpose = 'Educational'
where mod(id, 5) = 0;

update journeys
set purpose = 'Technical'
where mod(id, 3) = 0;

update journeys
set purpose = 'Medical'
where mod(id, 2) = 0;

# Exercise 4
delete from colonists
where id not in (select distinct colonist_id from travel_cards);

# Exercise 5
select card_number, job_during_journey
from travel_cards
order by card_number asc;

# Exercise 6
select id, concat(first_name, ' ', last_name) as `full_name`, ucn
from colonists
order by first_name asc, last_name asc, id asc;

# Exercise 7
select id, journey_start, journey_end
from journeys
where purpose = 'Military'
order by journey_start asc;

# Exercise 8
select c.id, concat(c.first_name, ' ', c.last_name) as `full_name`
from colonists as c
where c.id in (
	select distinct tc.colonist_id
    from travel_cards as tc
    where job_during_journey = 'Pilot'
)
order by c.id asc;

select distinct c.id, concat(c.first_name, ' ', c.last_name) as `full_name`
from colonists as c
join travel_cards as tc
	on tc.colonist_id = c.id
where tc.job_during_journey = 'Pilot'
order by c.id asc;

# Exercise 9
select s.name as `spaceship_name`, p.name as `spaceport_name`
from spaceships as s
join journeys as j
	on j.spaceship_id = s.id
join spaceports as p
	on j.destination_spaceport_id = p.id
where s.light_speed_rate is not null
order by s.light_speed_rate desc
limit 1;

# Exercise 10
select distinct p.name as `planet_name`, s.name as `spaceport_name`
from planets as p
join spaceports as s
	on s.planet_id = p.id
join journeys as j
	on j.destination_spaceport_id = s.id
where j.purpose = 'Educational'
order by s.name desc;

select distinct p.name as `planet_name`, s.name as `spaceport_name`
from planets as p
join spaceports as s
	on s.planet_id = p.id
where s.id in (select distinct j.destination_spaceport_id from journeys as j where j.purpose = 'Educational')
order by s.name desc;

# Exercise 11
select p.name as `planet_name`, count(*) as `journeys_count`
from planets as p
join spaceports as s
	on s.planet_id = p.id
join journeys as j
	on j.destination_spaceport_id = s.id
group by p.id
order by `journeys_count` desc, p.name asc;