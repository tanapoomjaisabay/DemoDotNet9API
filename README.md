# DemoDotNet9API

This is a sample project built with **.NET 9**, designed as a portfolio for job interviews.

---

## 📦 Project Purpose

To demonstrate clean and practical backend development practices, including:
- Authentication using JWT tokens.
- Accessing customer data via secured APIs.
- Integration with **MSSQL** using **Entity Framework Core**.
- Unit testing with **100% code coverage**.
- Docker containerization and GitHub Actions for building images.
- Logging system integration using **Serilog**.

## 📤 Features

- **Authentication API**: 
  - Verifies username and password.
  - Generates a JWT token upon successful login.
- **Customer API**:
  - Returns customer information after authentication.
- **Unit Testing**:
  - Complete test coverage for service layer.
- **Docker Deployment**:
  - Manual deployment using `docker-compose up` after GitHub build process.
- **Logging with Serilog**:
  - Structured logging outputs to the console.

## 🚀 Tech Stack

- ASP.NET Core 9
- Entity Framework Core
- xUnit
- Stub
- MSSQL Server
- Docker
- GitHub Actions (CI/CD)
- Serilog (Console Logging)

## 🛠️ How to Run

1. Clone the repository.
2. Create an MSSQL database and update the connection string in `appsettings.json`.
3. Run the following command:
   ```bash
   docker-compose up
   ```
4. Access the API endpoints via Swagger UI at `https://localhost:5001/swagger`.

## 🗂️ Folder Structure

- `src/` - Source code of the application
- `tests/` - Unit tests
- `docker/` - Docker Compose and related files (deployment)

## 📌 Notes

- Deployment workflow automatically builds Docker images on GitHub Push.
- Manual execution of Docker Compose for deployment.
- All API activities are logged using Serilog to the console.

---

## 👨‍💻 Author

Created by [Tanapoom Jaisabay](https://github.com/tanapoomjaisabay)  
Feel free to contribute or fork!
