# Employee Management System API  

## Overview  

This is a **RESTful API** built using **.NET 8**, designed to manage employee data in an organization. It supports CRUD operations, follows **SOLID** principles, and includes **JWT authentication** for secure access.  

## Features  

- **CRUD Operations**: Create, Read, Update, Delete employees.  
- **Authentication**: JWT-based authentication for securing endpoints.  
- **Entity Framework Core**: SQL database integration with EF Core.  
- **Dependency Injection**: Modular architecture for maintainability.  
- **SOLID Principles**: Ensures a scalable and maintainable codebase.  
- **Swagger Documentation**: Auto-generated API documentation.  

## Technologies Used  

- **.NET 8 Web API**  
- **C#**  
- **Entity Framework Core**  
- **SQL Server**  
- **JWT Authentication**  
- **Swagger (Swashbuckle)**  

## Project Structure

```
EmployeeManagementAPI/
│-- Controllers/        # API Controllers
│-- Models/             # Data Models
│-- DTOs/               # Data Transfer Objects
│-- Data/               # DbContext and Migrations
│-- Program.cs          # Application Entry Point
│-- appsettings.json    # Configuration Settings
```

## Installation

### Prerequisites

Ensure you have the following installed:

- .NET 8 SDK
- SQL Server 
- Entity Framework Core

### Setup Instructions

Clone the repository:

```sh
git clone https://github.com/Rohit-0310/Q3_Rest_API.NET.git
cd EmployeeManagement
```

Install required dependencies:

```sh
dotnet restore
```

Add EF Core design package:

```sh
dotnet add package Microsoft.EntityFrameworkCore.Design
```

Add JwtBearer package:

```sh
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.2
```

Add SqlServer package:

```sh
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.3
```

Add Tools package:

```sh
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 9.0.3
```

Add AspNetCore package:

```sh
dotnet add package Swashbuckle.AspNetCore --version 6.6.2
```

Add IdentityModel Tokens Jwt package:

```sh
dotnet add package System.IdentityModel.Tokens.Jwt --version 8.6.1
```

Apply Migrations:

```sh
dotnet ef migrations add InitialCreate
```

```sh
dotnet ef database update
```

Run the API:

```sh
dotnet run
```

Open Swagger UI at:

```
https://localhost:7229/swagger/index.html
```

## API Endpoints

### Authentication

- **POST** `/api/Auth/login` - Authenticate and get JWT token

### Employee Management

- **GET** `/api/Employees` - Get all Employees
- **GET** `/api/Employees/{id}` - GET employee By ID
- **POST** `/api/Employees` - Create a new employee
- **PUT** `/api/Employees/{id}` - Update an employee
- **DELETE** `/api/Employees/{id}` - Delete an employee

