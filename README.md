# Hair Salon
##### Database for a hair salon

#### By Lan Dam, 07.13.2018

## Description

A database that stores list of stylists and their clients for a hair salon.

## Setup

Download HairSalon folder.
Import SQL file into database or create your own using the following SQL command:
* CREATE DATABASE hair_salon;
* USE hair_salon;
* CREATE TABLE stylists (id serial PRIMARY KEY, name VARCHAR(255));
* CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylist VARCHAR(255));

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
