-- Create tables

use petshopdb;

create table Accommodation (
	Id int not null auto_increment,
    Number int not null,
    State tinyint default 1,
    
    primary key(Id)
);

create table Owner (
	Id int not null auto_increment,
    Name varchar(100) not null,
    Phone varchar(100),
    Address varchar(100),
    
    primary key(Id)
);

create table Pet (
	Id int not null auto_increment,
    AccommodationId int,
    OwnerId int,
    Name varchar(100) not null,
	ReasonForTreatment varchar(100),
    HealthState tinyint,
    
    primary key(Id),
    foreign key(AccommodationId) references Accommodation(Id),
    foreign key(OwnerId) references Owner(Id)
);

-- Populate database

insert into Accommodation (Number)
	values (1),(2),(3),(4),(5),(6),(7),(8),(9),(10);

insert Owner (Name, Phone, Address)
	values
        ('Luis Paulo', '85999999999', 'Fortaleza-CE'),
        ('Camila', '85999999999', 'Fortaleza-CE');

insert into Pet (AccommodationId, OwnerId, Name, ReasonForTreatment, HealthState) 
	values
        (1, 1, 'Jade', 'Pulgas', 1),
        (2, 2, 'Madona', 'Ferida na pata', 1);

update Accommodation
set State = 2
where Id in (1, 2);
