# 📌 Appointment Management System

## 🛠 Tech Stack
- **Framework:** ASP.NET Core 8.0 (MVC)
- **Database:** SQL Server + Entity Framework Core
- **Authentication:** ASP.NET Core Identity
- **Frontend:** Razor Pages + Bootstrap 5
- **Authorization:** Role-Based Access Control (RBAC)
- **Security:** Google reCAPTCHA v2
- **Hosting:** Local Development (Deployment Instructions Included)
- **Version Control:** Git & GitHub

## 🚀 Project Setup Instructions
### **Prerequisites**
- Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Install [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Install [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with ASP.NET and Web Development workload
- Clone the repository:
  ```sh
  git clone https://github.com/yourusername/AppointmentManagementSystem.git
  cd AppointmentManagementSystem
  ```

### **Database Setup**
1. **Update `appsettings.json` with your SQL Server connection string:**
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=AppointmentDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true"
   }
   ```
2. **Apply migrations & seed database:**
   ```sh
   Update-Database
   ```

### **Run the Application**
```sh
   dotnet run
```
Navigate to `https://localhost:5001/` in your browser.

---

## 🎯 Features Implemented
✅ **Authentication & Authorization:**
- Patients can register & book appointments.
- Doctors can log in & manage appointments.
- Admins can manage users & appointments.

✅ **Appointment Management:**
- Patients can schedule an appointment with a doctor.
- Doctors can view & update appointment status.
- Admins can view & delete appointments.

✅ **Security Enhancements:**
- **Google reCAPTCHA v2** added to registration & login.
- **Role-based authorization** for Admin, Doctor, and Patient.

✅ **Admin Dashboard:**
- View & manage Doctors, Patients, and Appointments.

---

## 💡 My Approach
I structured the project following **Clean Architecture** principles:
- **Controllers:** Handle requests and return responses.
- **Services:** Business logic layer for handling operations.
- **Repositories:** Data access layer for interaction with the database.
- **Identity Setup:** Secure authentication & role-based authorization.

**Challenges Faced:**
- Integrating Google reCAPTCHA took some debugging due to key mismatches.
- Handling FK constraints in EF Core while managing appointment relations.

**What I Liked:**
- Implementing Identity-based role management.
- Using EF Core migrations to keep the database up-to-date.

---

## 🚧 Pending Tasks
- ✅ **Main functionalities are completed.**
- 🔜 UI Enhancements: Improving form styling.
- 🔜 Hosting: Deploying to an online server.

---
 Looking forward to your feedback. 🚀

