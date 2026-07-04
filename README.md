# 🏢 HR Management System

A simple Human Resource Management System built using **ASP.NET Core MVC**, designed to manage employees, departments, attendance, and leave requests.

![.NET](https://img.shields.io/badge/.NET-8.0-purple?logo=dotnet)
![ASP.NET MVC](https://img.shields.io/badge/ASP.NET-MVC-blue)
![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-red?logo=microsoftsqlserver)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3-purple?logo=bootstrap)

---

## 📌 About The Project

This project is a Human Resource Management System developed using ASP.NET Core MVC. The goal of the project is to provide a simple and organized system for managing employees and HR operations while applying software engineering best practices.

---

## ✨ Current Features

* Employee Management
* Department Management
* Role-Based Authentication & Authorization
* Attendance Management
* Leave Requests
* Dashboard Overview
* CRUD Operations
* Form Validation

> More features will be added in future updates.

---

## 🏗️ Project Structure

The project follows the standard ASP.NET Core MVC architecture:

```text
HRManagementSystem/
│
├── Controllers/
├── Models/
├── Views/
├── Services/
├── Data/
├── wwwroot/
└── Program.cs
```

---

## 🛠️ Technologies Used

| Technology            | Version |
| --------------------- | ------- |
| ASP.NET Core MVC      | 8.0     |
| Entity Framework Core | 8.0     |
| SQL Server            | 2022    |
| Bootstrap             | 5.3     |
| ASP.NET Identity      | -       |

---

## 🚀 Getting Started

### Prerequisites

* .NET 8 SDK
* SQL Server
* Visual Studio 2022

### Installation

```bash
git clone <repository-url>

cd HRManagementSystem

dotnet restore

dotnet ef database update

dotnet run
```

The application will run locally on:

```text
https://localhost:xxxx
```

---

## 🔐 Authentication

The application uses ASP.NET Identity for authentication and authorization.

Available roles:

* Admin
* HR
* Employee

---

## 📋 Future Improvements

* Payroll Management
* Performance Reviews
* Notifications
* Reports & Analytics
* Employee Self-Service Portal

---

## 👨‍💻 Development Team

This project is developed as part of a learning and training journey in ASP.NET Core MVC development.

---

## 📄 License

This project is intended for educational purposes.

