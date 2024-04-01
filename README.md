# dotnet-7-dapper-mysql-crud-api

.NET 7.0 + Dapper + MySQL - CRUD API Tutorial in ASP.NET Core

Documentation at https://jasonwatmore.com/net-7-dapper-mysql-crud-api-tutorial-in-aspnet-core

# Getting Started

## Prepare MySQL Database

Create a new MySQL database named `dotnet-7-dapper-crud-api1` and import the `dotnet-7-dapper-crud-api1.sql` file located in the root of the project to create the required table and seed some test data.


# Apis documentation

## OrderController

### Get all orders

```http
  GET /api/order
```

### Get order by id

```http
  GET /api/order/{id}
```

### Get order by user id

```http
  GET /api/order/user/{userId}
```

## ProductController

### Get all products

```http
  GET /api/product
```

### Get product by id

```http
  GET /api/product/{id}
```

### Get product by category id

```http
  GET /api/product/category/{categoryId}
```

### Get product by author id

```http
  GET /api/product/author/{authorId}
```

## UserController

### Get all users

```http
  GET /api/users
```

### Get user by id

```http
  GET /api/users/{id}
```
