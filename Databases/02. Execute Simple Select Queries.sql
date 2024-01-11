use world;

# Give me all the information for all the records (rows) in the table `city`.
select * from city;

select ID, upper(Name) as `Name`, CountryCode as `Country Code` from city;

# When we want to check for equality, we use the `=` operator.
# There is one exception! If we want to check if a value is null, we use the `is null` syntax. If we want to check if a value is not null, we use the `is not null` syntax.
select ID, Name from city where CountryCode = 'ARG';
select * from country where IndepYear is null;

# If we want to check for inequality, we use the `!=` or `<>` operator.
select * from country where LifeExpectancy < 50 and Continent <> 'Africa';

select * from country where !(SurfaceArea > 10000000 || Population > 100000000) && GNP != 0;

select * from country where LifeExpectancy between 50 and 55;
select * from country where LifeExpectancy > 50 && LifeExpectancy < 55;

select * from country where IndepYear not in (1910, 1960);

# Concatenation in C#
# string result = "Hello" + " " + "World!";
#
# Concatenation in SQL
# concat("Hello", " ", "World!")
select * from countrylanguage;
select concat(Language, ' (', CountryCode, '), ', Percentage, '%') as `Language Info` from countrylanguage;

# `select distinct` means - get all unique values (according to the selected projection)
select distinct Language, CountryCode from countrylanguage;
select count(*) from countrylanguage where Language = 'English';

select count(*) from countrylanguage;
select count(*) from (select distinct Language from countrylanguage) as t;
