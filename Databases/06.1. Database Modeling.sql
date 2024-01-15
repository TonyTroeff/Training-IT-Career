create schema online_store;
use online_store;

create table item_types(
	item_type_id int(11) not null auto_increment,
    name varchar(50) not null,
    primary key (item_type_id)
);

create table cities(
	city_id int(11) not null auto_increment,
    name varchar(50) not null,
    primary key (city_id)
);

create table items(
	item_id int(11) not null auto_increment,
    name varchar(50) not null,
    item_type_id int(11) not null,
    primary key (item_id),
    foreign key (item_type_id) references item_types (item_type_id)
);

create table customers(
	customer_id int(11) not null auto_increment,
    name varchar(50) not null,
    birthday date,
    city_id int(11) not null,
    primary key (customer_id),
    foreign key (city_id) references cities (city_id)
);

create table orders(
	order_id int(11) not null auto_increment,
    customer_id int(11) not null,
    primary key (order_id),
    foreign key (customer_id) references customers (customer_id)
);

create table order_items(
	order_id int(11) not null,
    item_id int(11) not null,
    primary key (order_id, item_id),
    foreign key (order_id) references orders (order_id),
    foreign key (item_id) references items (item_id)
);