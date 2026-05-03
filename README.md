# User Management API

Final project for the Backend Developer with .NET course on Coursera.

This project is a back-end API developed as part of the final project for the Backend Developer with .NET course. The goal of the project is to demonstrate practical skills in ASP.NET Core, REST API development, CRUD operations, validation, debugging, middleware implementation, and the use of Microsoft Copilot as a development assistant.

The scenario for this project is based on a company called TechHive Solutions, which needs a User Management API for internal tools used by HR and IT departments. The API allows users to be created, listed, updated, retrieved by ID, and deleted.

## Project Overview

The User Management API was built using ASP.NET Core and C#. It provides a simple and functional REST API for managing user records.

The project includes:

* CRUD endpoints for user management
* Input validation for user data
* Error handling middleware
* Token-based authentication middleware
* Request and response logging middleware
* In-memory user storage for learning purposes
* Documentation of Microsoft Copilot usage

## Course Information

Course: Backend Developer with .NET

Platform: Coursera

Project type: Final project

Main focus:

* Back-end API development
* ASP.NET Core
* RESTful services
* Middleware pipeline
* Debugging and validation
* Secure API design basics
* Generative AI assistance with Microsoft Copilot

## Scenario

TechHive Solutions needs an internal User Management API to help HR and IT departments manage employee user records efficiently.

The API must allow the company to:

* Retrieve all users
* Retrieve a specific user by ID
* Add a new user
* Update an existing user
* Delete a user
* Validate user input
* Handle errors consistently
* Protect endpoints using token-based authentication
* Log incoming requests and outgoing responses

## Technologies Used

* C#
* ASP.NET Core
* .NET
* Minimal API
* REST API
* Middleware
* Microsoft Copilot
* Visual Studio Code
* Git
* GitHub
* Postman or PowerShell for testing

## Project Structure

```txt
UserManagementAPI/
├── DTOs/
│   ├── UserCreateRequest.cs
│   └── UserUpdateRequest.cs
├── Middleware/
│   ├── ErrorHandlingMiddleware.cs
│   ├── RequestLoggingMiddleware.cs
│   └── TokenAuthenticationMiddleware.cs
├── Models/
│   └── User.cs
├── Services/
│   └── UserService.cs
├── Program.cs
├── appsettings.json
├── UserManagementAPI.csproj
├── .gitignore
└── README.md
```

## Features

## CRUD Operations

The API includes all basic CRUD operations required for managing users.

| Method | Endpoint        | Description                     |
| ------ | --------------- | ------------------------------- |
| GET    | /api/users      | Retrieves all users             |
| GET    | /api/users/{id} | Retrieves a specific user by ID |
| POST   | /api/users      | Creates a new user              |
| PUT    | /api/users/{id} | Updates an existing user        |
| DELETE | /api/users/{id} | Deletes a user by ID            |

## Validation

The API validates user data before creating or updating records.

Validation rules include:

* Name is required
* Name must have at least 2 characters
* Email is required
* Email must follow a valid email format
* Department is required

If invalid data is submitted, the API returns a Bad Request response with a clear error message.

Example validation error:

```json
{
  "error": "Email format is invalid."
}
```

## Error Handling Middleware

The project includes centralized error handling middleware.

This middleware catches unhandled exceptions and returns a consistent JSON error response.

Example error response:

```json
{
  "error": "Internal server error."
}
```

This improves reliability and prevents raw exception details from being exposed to API consumers.

## Authentication Middleware

The API includes token-based authentication middleware.

Protected endpoints require an Authorization header with a valid bearer token.

Required header:

```txt
Authorization: Bearer techhive-token
```

If the token is missing or invalid, the API returns:

```json
{
  "error": "Unauthorized. Invalid or missing token."
}
```

## Logging Middleware

The project includes middleware for logging incoming requests and outgoing responses.

The logging middleware records:

* HTTP method
* Request path
* Response status code

Example log information:

```txt
Incoming request: GET /api/users
Outgoing response: 200
```

This supports auditing and debugging.

## Middleware Pipeline

The middleware pipeline is configured in the following order:

1. Error handling middleware
2. Token authentication middleware
3. Request and response logging middleware

This order helps ensure that errors are handled consistently, protected routes are secured, and request activity is logged.

## API Endpoints

## Root Endpoint

```http
GET /
```

Description:

Checks whether the API is running.

Example response:

```json
{
  "message": "User Management API is running.",
  "project": "TechHive Solutions - User Management API"
}
```

## Get All Users

```http
GET /api/users
```

Required header:

```txt
Authorization: Bearer techhive-token
```

Example response:

```json
{
  "count": 2,
  "users": [
    {
      "id": 1,
      "name": "John Doe",
      "email": "john.doe@techhive.com",
      "department": "IT",
      "createdAt": "2026-01-01T00:00:00Z",
      "updatedAt": null
    }
  ]
}
```

## Get User by ID

```http
GET /api/users/{id}
```

Example:

```http
GET /api/users/1
```

If the user exists, the API returns the user data.

If the user does not exist, the API returns:

```json
{
  "error": "User not found."
}
```

## Create User

```http
POST /api/users
```

Required header:

```txt
Authorization: Bearer techhive-token
```

Example request body:

```json
{
  "name": "Arthur Albefaro",
  "email": "arthur@example.com",
  "department": "IT"
}
```

Example response:

```json
{
  "id": 3,
  "name": "Arthur Albefaro",
  "email": "arthur@example.com",
  "department": "IT",
  "createdAt": "2026-01-01T00:00:00Z",
  "updatedAt": null
}
```

## Update User

```http
PUT /api/users/{id}
```

Example:

```http
PUT /api/users/1
```

Example request body:

```json
{
  "name": "Arthur Albefaro",
  "email": "arthur.albefaro@example.com",
  "department": "Automation"
}
```

If the user exists, the API returns the updated user.

If the user does not exist, the API returns:

```json
{
  "error": "User not found."
}
```

## Delete User

```http
DELETE /api/users/{id}
```

Example:

```http
DELETE /api/users/1
```

Example response:

```json
{
  "message": "User deleted successfully."
}
```

If the user does not exist, the API returns:

```json
{
  "error": "User not found."
}
```

## Running the Project

## Prerequisites

Make sure you have installed:

* .NET SDK
* Visual Studio Code
* Git
* Postman or another API testing tool

## Clone the Repository

```bash
git clone https://github.com/your-username/UserManagementAPI.git
cd UserManagementAPI
```

## Restore Dependencies

```bash
dotnet restore
```

## Build the Project

```bash
dotnet build
```

## Run the API

```bash
dotnet run --urls "http://localhost:5000"
```

The API will be available at:

```txt
http://localhost:5000
```

## Testing the API

You can test the API using Postman, curl, or PowerShell.

## PowerShell Examples

Create the authorization header:

```powershell
$headers = @{
  Authorization = "Bearer techhive-token"
}
```

Get all users:

```powershell
Invoke-RestMethod -Uri "http://localhost:5000/api/users" -Headers $headers
```

Get user by ID:

```powershell
Invoke-RestMethod -Uri "http://localhost:5000/api/users/1" -Headers $headers
```

Create a new user:

```powershell
$body = @{
  name = "Arthur Albefaro"
  email = "arthur@example.com"
  department = "IT"
} | ConvertTo-Json

Invoke-RestMethod `
  -Uri "http://localhost:5000/api/users" `
  -Method Post `
  -Headers $headers `
  -ContentType "application/json" `
  -Body $body
```

Update a user:

```powershell
$body = @{
  name = "Arthur Albefaro"
  email = "arthur.albefaro@example.com"
  department = "Automation"
} | ConvertTo-Json

Invoke-RestMethod `
  -Uri "http://localhost:5000/api/users/1" `
  -Method Put `
  -Headers $headers `
  -ContentType "application/json" `
  -Body $body
```

Delete a user:

```powershell
Invoke-RestMethod `
  -Uri "http://localhost:5000/api/users/1" `
  -Method Delete `
  -Headers $headers
```

Test invalid authentication:

```powershell
Invoke-RestMethod -Uri "http://localhost:5000/api/users"
```

Expected result:

```json
{
  "error": "Unauthorized. Invalid or missing token."
}
```

Test invalid email validation:

```powershell
$body = @{
  name = "Invalid User"
  email = "invalid-email"
  department = "IT"
} | ConvertTo-Json

Invoke-RestMethod `
  -Uri "http://localhost:5000/api/users" `
  -Method Post `
  -Headers $headers `
  -ContentType "application/json" `
  -Body $body
```

Expected result:

```json
{
  "error": "Email format is invalid."
}
```

## Microsoft Copilot Usage

Microsoft Copilot was used throughout the project to support development, debugging, and middleware implementation.

Copilot helped with:

* Scaffolding the initial API structure
* Generating CRUD endpoint ideas
* Reviewing validation logic
* Identifying possible bugs
* Improving error handling
* Suggesting middleware structure
* Assisting with token-based authentication
* Improving request and response logging
* Supporting testing scenarios for valid and invalid requests

The final code was reviewed and adjusted manually to ensure correctness, security, and alignment with the course requirements.

## Project Requirements Checklist

| Requirement                        | Status    |
| ---------------------------------- | --------- |
| GitHub repository created          | Completed |
| CRUD endpoints implemented         | Completed |
| GET endpoint included              | Completed |
| POST endpoint included             | Completed |
| PUT endpoint included              | Completed |
| DELETE endpoint included           | Completed |
| Copilot used for debugging         | Completed |
| User data validation implemented   | Completed |
| Middleware implemented             | Completed |
| Logging middleware included        | Completed |
| Authentication middleware included | Completed |
| Error handling middleware included | Completed |

## Learning Outcomes

This project demonstrates the ability to:

* Build a REST API using ASP.NET Core
* Implement CRUD operations
* Organize a back-end project using models, DTOs, services, and middleware
* Validate API input data
* Handle errors consistently
* Secure endpoints using token-based authentication
* Log requests and responses
* Use Microsoft Copilot as a development assistant
* Test API endpoints using external tools
* Publish a project to GitHub for review

## Notes

This project uses in-memory storage for educational purposes. Data will be reset when the application restarts.

In a production environment, this API could be improved by adding:

* A database such as SQL Server or PostgreSQL
* Entity Framework Core
* JWT authentication
* Role-based authorization
* Unit and integration tests
* Swagger/OpenAPI documentation
* Docker support
* CI/CD pipeline

## Author

Arthur Albefaro

Final project for the Backend Developer with .NET course on Coursera.