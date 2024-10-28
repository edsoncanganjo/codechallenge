# CodeChallenge.API

a) Implement a basic RESTful API in C# that performs CRUD (Create, Read, Update, Delete) operations on an entity Product with properties Id, Name, and Price. Provide the code and briefly explain the solution structure. (20 points)
answer: the implementation can be founded inside CodeChallenge.Api project, in real application I would not process data inside controller, the repository was created because of the testing.

b) Create a data model in C# using Entity Framework that represents a one-to-many relationship between Customer and Order entities. Write a method that, given a customer ID, returns all their orders. (15 points)
answer: The data model was created in the same project and there's also endpoint to create Customer and Order, them test them

c) Write a set of unit tests using xUnit to test the RESTful API created above. Make sure to cover the creation and deletion operations. (15 points)
answer: The tests can be founded inside project **CodeChallenge.Api.Tests**