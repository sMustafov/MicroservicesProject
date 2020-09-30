# Microservices Project

Microservices are architectural style that structures an application as a collection of small autonomous services, modeled around a business domain. They are loosely coupled services which can be developed, deployed, and maintained independently. Each of these services is responsible for discrete task and can communicate with other services through simple APIs to solve a larger complex business problem. 

This application offers operations to read, create, and update customers and orders. Implemented a Customer API with create and update customer methods. Implemented an Order API with create, pay and get all orders methods. Communication between microservices is implemented through some RabbitMQ. Use DDD and CQRS approaches with the Mediator and Repository Pattern. Used an in-memory database.

## Technologies 
* ASP.NET Core 3.1 
* RabbitMQ
* MediatR 
* CQRS
* AutoMapper
* FluentValidation
* Docker
