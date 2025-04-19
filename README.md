# DemoDotNet9API

This is a sample project built with **.NET 9**, designed as a portfolio for job interviews.

## Project Purpose
To demonstrate clean and practical backend development practices, including:
- Authentication using JWT tokens.
- Accessing customer data via secured APIs.
- Integration with **MSSQL** using **Entity Framework Core**.
- Unit testing with **100% code coverage**.
- Docker containerization and GitHub Actions for building images.

## Features
- **Authentication API**: 
  - Verifies username and password.
  - Generates a JWT token upon successful login.
- **Customer API**:
  - Returns customer information after authentication.
- **Unit Testing**:
  - Complete test coverage for service layer.
- **Docker Deployment**:
  - Manual deployment using `docker-compose up` after GitHub build process.

## Tech Stack
- ASP.NET Core 9
- Entity Framework Core
- xUnit
- Moq
- MSSQL Server
- Docker
- GitHub Actions (CI)

## How to Run
1. Clone the repository.
2. Create an MSSQL database and update the connection string in `appsettings.json`.
3. Run the following command:
   ```bash
   docker-compose up
