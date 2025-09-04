# DataMgtCoreAPI

A comprehensive Data Management project using ASP.NET Core Web API and Dapper ORM with dependency injection, following clean architecture principles.

## Architecture

This project follows a layered architecture pattern:

- **Web API Layer** (`DataManagement.API`): Controllers and HTTP endpoints
- **Business Logic Layer** (`DataManagement.Business`): Business rules and logic
- **Repository Layer** (`DataManagement.Repository`): Data access using Dapper ORM
- **Entity Layer** (`DataManagement.Entities`): Domain models
- **Interface Layer** (`DataManagement.*.Interfaces`): Contracts and abstractions

## Features

- RESTful API endpoints for User and Customer management
- Repository pattern with generic interfaces
- Dependency injection for loose coupling
- Comprehensive input validation and error handling
- Proper HTTP status codes and error responses
- Clean separation of concerns

## Technologies Used

- **.NET Core 1.0** (Web API framework)
- **Dapper** (Lightweight ORM)
- **SQL Server** (Database)
- **Dependency Injection** (Built-in .NET Core DI)

## Project Structure

```
DataManagement/
├── src/
│   └── DataManagement.WebAPI/          # Web API controllers and configuration
├── DataManagement.Entities/            # Domain models (User, Customer, Product)
├── DataManagement.Business/            # Business logic implementations
├── DataManagement.Business.Interfaces/ # Business layer contracts
├── DataManagement.Repository/          # Data access implementations
├── DataManagement.Repository.Interfaces/ # Repository contracts
└── DataManagement.SQL/                 # SQL-related utilities
```

## API Endpoints

### Users
- `GET /api/user` - Get all users
- `GET /api/user/{id}` - Get user by ID
- `POST /api/user` - Create new user
- `PUT /api/user/{id}` - Update user
- `DELETE /api/user/{id}` - Delete user

### Customers
- `GET /api/customer` - Get all customers
- `GET /api/customer/{id}` - Get customer by ID
- `POST /api/customer` - Create new customer
- `PUT /api/customer/{id}` - Update customer
- `DELETE /api/customer/{id}` - Delete customer

## Getting Started

### Prerequisites
- .NET Core SDK 1.0 or later
- SQL Server
- Visual Studio 2017+ or VS Code

### Setup
1. Clone the repository
2. Update the connection string in `appsettings.json`
3. Build the solution: `dotnet build`
4. Run the API: `dotnet run`

### Configuration

Update the connection string in `src/DataManagement.WebAPI/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MyConnection": "Server=YOUR_SERVER;Initial Catalog=DataManagement;Integrated Security=True;"
  }
}
```

## Code Quality Improvements

This repository includes several enhancements:

- ✅ **Fixed Build Issues**: Resolved NETSDK1022 errors with duplicate compile items
- ✅ **Bug Fixes**: Fixed critical bug in CustomerRepository.Update() method
- ✅ **Error Handling**: Added comprehensive error handling and validation
- ✅ **HTTP Status Codes**: Proper status codes for all API responses
- ✅ **Input Validation**: Null checks and business rule validation
- ✅ **Resource Management**: Proper disposal patterns

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests if applicable
5. Submit a pull request

## License

This project is for demonstration purposes.
