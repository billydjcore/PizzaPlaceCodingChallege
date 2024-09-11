This VS Solution is for our skill test coding challenge.

The Solution Contains the following projects:
1. PizzaPlace.Api - this project is a .net core api which do CRUD functions to tables(orders,order-details,pizza,pizza-types). It is written using c# and entityframework code.
2. PizzaPlaceImportTool - this project is web-app which enable to import data from CSF File to SQL Database. It is written in C#.Netcore MVC using a clean architecture for easy maintenance, scaling and testable.
   The project is broken down in 3 Projects mainly:
   a. PizzPlace.Core - Contains the business logic services, interfaces, data transfer objects, repository interface and entity classes.
   b. PizzaPlace.Infrastructure - Contains the database communication objects such as Db context, repositories, external API calls.
   c. PizzaPlaceImportTool.UI - This is the web app ui the functions as CSV Data import tool.


   

