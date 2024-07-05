# Exercise

I would like you to create an application that is able to connect to a SQL Server Instance and get information about your MonitoredEntities.

You will need to create your Database and create a table with the following properties:
```
ID: uniqueidentifier
Name: nvarchar(255)
Value: nvarchar(255)
```
Then you'll need to pass the connection string to your application.

The Monitored Entity Object is already represented in the Repository and you should use the same SHAPE of the object.

In particular should be implemented basic CRUD Operations:
- One endpoint to get All the Monitored Entity
- One endpoint to store a Monitored Entity
- One endpoint to Delete a Monitored Entity given an Id,
- One endpoint to Update an Existing Monitored Entity given an Id and the updated object passed in the body of the HTTP request.

Try to implement this application like it should be in production following the best coding standards(Separate the business logic from the presentation layer)
