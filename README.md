# Vehicle Rental System

A console application for managing vehicle rentals. This system is given a demo data and it calculates rental and insurance costs and print out the invoice for the customer.

## Class Structure

### 1. `Vehicle`

Abstract parent class for the different types of vehicles in the system. It gives to its childred 3 abstract methods:
  - Calculate the daily rental cost of the vehicle
  - Calculate the daily insurance cost after all the additions or discounts
  - Print its insurance details (in the invoice)

### 2. `Car`

Child class of Vehicle. It have insurance discount if the car have a safety rating of 4 or 5.

### 3. `Motorcycle`

Derived class of Vehicle. It have insurance addition if the driver is under 25 years old.

### 4. `Cargo Van`

Child class of Vehicle. It have insurance discount if the driver has more than 5 years experiance.

### 5. `Customer`

Represents a customer who rents vehicles.

### 6. `Invoice`

Handles the generation and printing of invoices for reservations.

## Application screenshots
![s4](https://github.com/m-georgiev01/Vehicle-Rental-System/assets/83757143/b460a45b-8e97-4ac2-85a8-2c65d93d1dae)

![s5](https://github.com/m-georgiev01/Vehicle-Rental-System/assets/83757143/f923f13d-8923-4da9-b381-59b5514a3312)

![s3](https://github.com/m-georgiev01/Vehicle-Rental-System/assets/83757143/706778f5-2d45-4496-86de-f35c592f4b31)
