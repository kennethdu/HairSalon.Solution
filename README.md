# _Hair Salon_

#### _Friday Independent Project for Epicdous, 9.21.2018/ 9.28.2018_

#### By _**Kenneth Du**_

## Description

_Hair Salon._

Create an app for a hair salon. The owner should be able to add a list of the stylists, and for each stylist, add clients who see that stylist, and specialties that each stylist may have. The stylists work independently, so each client only belongs to a single stylist; however, a stylist can have many specialties.
User Stories
    
    As a salon employee, I need to be able to see a list of all our stylists.
    As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
    As an employee, I need to add new stylists to our system when they are hired.
    As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

And here are the user stories that the salon owner would like you to add:

    As an employee, I need to be able to delete stylists (all and single).
    As an employee, I need to be able to delete clients (all and single).
    As an employee, I need to be able to view clients (all and single).
    As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
    As an employee, I need to be able to edit ALL of the information for a client.
    As an employee, I need to be able to add a specialty and view all specialties that have been added.
    As an employee, I need to be able to add a specialty to a stylist.
    As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
    As an employee, I need to see the stylist's specialties on the stylist's details page.
    As an employee, I need to be able to add a stylist to a specialty.

## Setup/Installation Requirements

* Clone this repository
* Navigate to the HairSolution.Solution/HairSolution directory
* In a c# compiler (I suggest mono) type 'dotnet run' to run a local host
* In a web browser, navigate to 'http://localhost:5000/'
* The program will allow the user to choose add and choose a stylists. Once the users adds a stylists, the user is allowed to add clients, and view each client that the stylists has.

* _Setup Database_

* Open terminal a terminal application(I suggest mono)
```
$ CREATE DATABASE kenneth_du;
```
```
$ USE kenneth_du;
```
```
$ CREATE TABLE employees (id serial PRIMARY KEY, name VARCHAR(255));
```
```
$ CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255));
```
```
$ CREATE TABLE specialties (id serial PRIMARY KEY, name VARCHAR(255));
```
```
$ CREATE TABLE employees_clients (id serial PRIMARY KEY, employee_id INT, client_id INT);
```
```
$ CREATE TABLE employees_specialties (id serial PRIMARY KEY, employee_id INT, specialty_id INT);
```

## Specifications

### Specs: Hair Salon
| Spec | Input | Output |
| :-------------     | :------------- | :------------- |
| **The program will allow the user to add a stylist** | Input: "Jane" | Output: "Jane" |
| **The program will allow the user to add clients** | Input: "Susan" | Output: "Susan"|
| **The program will allow the user to view the clients that a stylist has** | Input: "Employee: Jane, Client: Susan" | Output: "Susan" |

## Known Bugs

_No known bugs._

## Support and contact details

_kennethdu3@gmail.com_

## Technologies Used

_C#/.Net Core 1.1_
_Vs Code_
_Mono_
_Git_
_Github_
_HTML_

### License

This software is licensed under the MIT license.

Copyright (c) 2018 **_Kenneth_Du_**
