# Hair Salon
##### Database for a hair salon

#### By Lan Dam, 07.13.2018

## Description

A database that stores list of stylists and their clients for a hair salon.

## Setup

Clone HairSalon folder.
Import SQL file into database or create your own using the following SQL command:
Main Database:
* CREATE DATABASE hair_salon;
* USE hair_salon;
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
* CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist_id INT);
* CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));
* CREATE TABLE stylists_specialties (id serial PRIMARY KEY, stylist_id INT, specialty_id INT);

For test database, follow the previous instruction but use the name hair_salon_test
Or if using MAMP phpMyAdmin, go to the main database, click on operations tab, in the copy database to box, enter hair_salon_test for the name, click on structure only, and make sure "CREATE DATABASE before copying" box and "Add AUTO_INCREMENT" box are checked.

To run the application:
* Open command prompt and navigate to the ../HairSalon.Solution/HairSalon folder
* Type dotnet restore
* Type dotnet run
* Open browser and enter http://localhost:5000

To test the application:
* Open command prompt and navigate to the ../HairSalon.Solution/HairSalon.Tests folder
* Type dotnet restore
* Type dotnet test

## Technologies Used

Application: CSharp, netcoreapp1.1, Razor, MAMP, MySQL

## Support and Contact

For any questions or support details, please email:
ldam77@yahoo.com

## Spec

* Let user see a list of all stylists
* Let user select a stylist, see their details, and see a list of all clients that belong to that stylist
* Let user add new stylists
* Let the user add new clients to a specific stylist. User should not be able to add a client if no stylist have been added.

### Legal

Copyright (c) 2018 **Lan Dam**

This software is licensed under the MIT license.
