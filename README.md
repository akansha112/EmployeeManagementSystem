📌 Mini HR Management System

A lightweight HR management system built with ASP.NET Core (.NET 8) designed to manage employee and department data with a clean, scalable architecture. The project focuses on maintainability, separation of concerns, and real-world backend design practices.


🚀 Features

- Employee CRUD operations
- Department management with seeded data
- Dynamic filtering (name, department, active status)
- Sorting by employee name and salary
- Clean repository pattern architecture
- DTO-based data transfer
- AutoMapper integration
- EF Core migrations & database seeding
- Self-referencing employee manager structure
- Modular design ready for authentication & payroll expansion


🏗 Architecture

- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- Repository pattern
- AutoMapper for object mapping
- SQL Server (LocalDB)
- Layered architecture (Domain → Repository → Controller)


🔍 Filtering & Sorting

Employees can be filtered by:

- Name
- Department
- Active status

Sorting supported by:

- Name
- Salary (ascending / descending)

Example API call:

GET /api/employees/search?name=rahul&sortBy=salary&isDescending=true

- JWT authentication
- Role-based authorization


🧱 Database Design

- Employees table
- Departments table (seeded)
- Manager-subordinate relationship
- Payroll-ready salary structure
- Extensible for authentication DB


📈 Future Enhancements
- Payroll module
- Leave management
- Pagination
- Soft delete
- Audit logging
- Validation middleware


▶️ Running the Project

Update-Database
dotnet run

Open Swagger:
https://localhost:<port>/swagger
