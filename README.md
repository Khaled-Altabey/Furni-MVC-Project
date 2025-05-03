
---

## 🧱 Architecture Overview

### 3-Tier Layers

- **Presentation Layer**  
  Handles UI and user interaction via Controllers and Razor Views.

- **Business Layer**  
  Contains core logic, DTOs, and services that act as a bridge between the UI and DAL.

- **Data Access Layer (DAL)**  
  Contains `AppDbContext`, entity configurations, and repository implementations.

---

## 📚 Technologies Used

- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server  
- LINQ  
- Repository Pattern  
- Dependency Injection  
- AutoMapper *(optional)*

---

## 🧩 Features

- Clean separation of concerns via 3-tier architecture  
- Generic repository pattern for data access abstraction  
- Fully functional CRUD operations  
- Scalable and testable service layer  
- Error handling and validation


