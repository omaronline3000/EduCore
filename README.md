# EduCore — Training & Student Management System

EduCore is an ASP.NET Core MVC web application designed to manage training centers, courses, instructors, trainees, and trainee results.

The project was built to practice and apply backend development concepts using **C#, ASP.NET Core MVC, Entity Framework Core, SQL Server, and ASP.NET Core Identity**.

---

## Features

### Authentication & Authorization

- User registration and login
- ASP.NET Core Identity
- Role-based authorization
- Separate functionality for:
  - Admin
  - Instructor
  - Trainee
- Protected actions based on user roles
- User accounts linked to their corresponding Instructor or Trainee records

### Admin

Administrators can manage the main entities of the system:

- Departments
- Courses
- Instructors
- Trainees
- Instructor assignments
- Trainee results
- Users and roles

### Instructor

Instructors can:

- View their dashboard
- View assigned courses
- View trainees related to their courses
- View and manage trainee results

### Trainee

Trainees can:

- View their dashboard
- View their courses
- View their results
- Access their own information

### Course & Trainee Management

- Department → Course relationships
- Instructor → Course assignment
- Trainee → Course relationships
- Trainee result management
- Course-specific trainee results

### Additional Features

- Server-side validation
- Custom validation attributes
- Pagination
- LINQ queries
- AJAX-based course loading
- Soft delete / query filtering
- Entity relationships and navigation properties
- EF Core migrations
- SQL Server database integration

---

## Technologies

| Technology | Usage |
|---|---|
| C# | Main programming language |
| ASP.NET Core MVC | Web application framework |
| Entity Framework Core | ORM / data access |
| SQL Server | Database |
| ASP.NET Core Identity | Authentication & authorization |
| LINQ | Data querying |
| Bootstrap | UI styling |
| JavaScript / jQuery | Client-side interactions and AJAX |
| Git & GitHub | Version control |

---

## Architecture

The project follows a layered approach using Controllers, Services, and Repositories.

```text
                    ┌──────────────────┐
                    │      Views       │
                    │ Razor / Bootstrap│
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │   Controllers    │
                    │   HTTP / MVC      │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │    Services      │
                    │ Business Logic   │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │   Repositories   │
                    │   Data Access    │
                    └────────┬─────────┘
                             │
                             ▼
                    ┌──────────────────┐
                    │    EF Core       │
                    │   SQL Server     │
                    └──────────────────┘
