using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GSI_Manage_BackEnd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using BCryptNet = BCrypt.Net.BCrypt;

namespace GSI_Manage_BackEnd.Infrastructure.Data
{
    public static class DatabaseSeeder
    {
        public static async System.Threading.Tasks.Task SeedAsync(ApplicationDbContext context)
        {
            // Only seed if database is empty
            if (await context.Users.AnyAsync())
            {
                return;
            }

            // Seed Users
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "admin@gsi.com",
                    Password = BCryptNet.HashPassword("Admin123!"),
                    FirstName = "System",
                    LastName = "Administrator",
                    Role = "admin",
                    Permissions = new List<string> { "read", "write", "delete", "manage_users" },
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "manager@gsi.com",
                    Password = BCryptNet.HashPassword("Manager123!"),
                    FirstName = "Project",
                    LastName = "Manager",
                    Role = "manager",
                    Permissions = new List<string> { "read", "write", "manage_projects" },
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Email = "employee@gsi.com",
                    Password = BCryptNet.HashPassword("Employee123!"),
                    FirstName = "John",
                    LastName = "Doe",
                    Role = "employee",
                    Permissions = new List<string> { "read", "write" },
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();

            // Seed Employees
            var adminUser = users.First(u => u.Role == "admin");
            var managerUser = users.First(u => u.Role == "manager");
            var employeeUser = users.First(u => u.Role == "employee");

            var employees = new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP001",
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@gsi.com",
                    Phone = "+971501234567",
                    Position = "Software Developer",
                    Department = "IT",
                    HireDate = DateTime.UtcNow.AddMonths(-12),
                    Salary = 8000.00m,
                    Status = "active",
                    ManagerId = managerUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP002",
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@gsi.com",
                    Phone = "+971507654321",
                    Position = "Project Manager",
                    Department = "Operations",
                    HireDate = DateTime.UtcNow.AddMonths(-24),
                    Salary = 12000.00m,
                    Status = "active",
                    ManagerId = adminUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = "EMP003",
                    FirstName = "Ahmed",
                    LastName = "Al-Mansoori",
                    Email = "ahmed.al-mansoori@gsi.com",
                    Phone = "+971509876543",
                    Position = "Business Analyst",
                    Department = "Business",
                    HireDate = DateTime.UtcNow.AddMonths(-6),
                    Salary = 9000.00m,
                    Status = "active",
                    ManagerId = managerUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.Employees.AddRangeAsync(employees);
            await context.SaveChangesAsync();

            // Seed Projects
            var projects = new List<Project>
            {
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Digital Transformation Initiative",
                    Description = "Complete digital transformation of internal processes and systems",
                    Client = "Internal",
                    Status = "active",
                    StartDate = DateTime.UtcNow.AddMonths(-3),
                    EndDate = DateTime.UtcNow.AddMonths(9),
                    Budget = 500000.00m,
                    Progress = 65,
                    ManagerId = managerUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Mobile App Development",
                    Description = "Development of customer-facing mobile application",
                    Client = "TechCorp Solutions",
                    Status = "active",
                    StartDate = DateTime.UtcNow.AddMonths(-1),
                    EndDate = DateTime.UtcNow.AddMonths(5),
                    Budget = 150000.00m,
                    Progress = 30,
                    ManagerId = managerUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Project
                {
                    Id = Guid.NewGuid(),
                    Name = "Infrastructure Upgrade",
                    Description = "Server and network infrastructure modernization",
                    Client = "Internal",
                    Status = "completed",
                    StartDate = DateTime.UtcNow.AddMonths(-8),
                    EndDate = DateTime.UtcNow.AddMonths(-1),
                    Budget = 200000.00m,
                    Progress = 100,
                    ManagerId = adminUser.Id,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.Projects.AddRangeAsync(projects);
            await context.SaveChangesAsync();

            // Seed Tasks
            var activeProject = projects.First(p => p.Status == "active");
            var johnEmployee = employees.First(e => e.FirstName == "John");

            var tasks = new List<Domain.Entities.Task>
            {
                new Domain.Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Requirements Analysis",
                    Description = "Gather and analyze project requirements",
                    Status = "completed",
                    Priority = "high",
                    AssigneeId = johnEmployee.Id,
                    ProjectId = activeProject.Id,
                    CreatedById = adminUser.Id,
                    DueDate = DateTime.UtcNow.AddDays(7),
                    CompletedAt = DateTime.UtcNow.AddDays(-2),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Domain.Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Database Design",
                    Description = "Design database schema and relationships",
                    Status = "in_progress",
                    Priority = "high",
                    AssigneeId = johnEmployee.Id,
                    ProjectId = activeProject.Id,
                    CreatedById = adminUser.Id,
                    DueDate = DateTime.UtcNow.AddDays(14),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Domain.Entities.Task
                {
                    Id = Guid.NewGuid(),
                    Title = "API Development",
                    Description = "Develop REST API endpoints",
                    Status = "pending",
                    Priority = "medium",
                    AssigneeId = johnEmployee.Id,
                    ProjectId = activeProject.Id,
                    CreatedById = adminUser.Id,
                    DueDate = DateTime.UtcNow.AddDays(21),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.Tasks.AddRangeAsync(tasks);
            await context.SaveChangesAsync();

            // Seed KPIs
            var kpis = new List<KPI>
            {
                new KPI
                {
                    Id = Guid.NewGuid(),
                    Name = "Project Completion Rate",
                    Description = "Percentage of projects completed on time",
                    Category = "Project Management",
                    TargetValue = 85.0m,
                    CurrentValue = 78.5m,
                    Unit = "%",
                    Period = "monthly",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KPI
                {
                    Id = Guid.NewGuid(),
                    Name = "Employee Satisfaction",
                    Description = "Average employee satisfaction score",
                    Category = "HR",
                    TargetValue = 4.2m,
                    CurrentValue = 4.1m,
                    Unit = "/5",
                    Period = "quarterly",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new KPI
                {
                    Id = Guid.NewGuid(),
                    Name = "Revenue Growth",
                    Description = "Monthly revenue growth rate",
                    Category = "Finance",
                    TargetValue = 15.0m,
                    CurrentValue = 12.3m,
                    Unit = "%",
                    Period = "monthly",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.KPIs.AddRangeAsync(kpis);
            await context.SaveChangesAsync();

            // Seed Transactions
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Type = "income",
                    Amount = 50000.00m,
                    Description = "Project milestone payment",
                    Category = "Consulting",
                    ProjectId = activeProject.Id,
                    Date = DateTime.UtcNow.AddDays(-5),
                    CreatedBy = adminUser.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Type = "expense",
                    Amount = 15000.00m,
                    Description = "Software licenses",
                    Category = "IT",
                    Date = DateTime.UtcNow.AddDays(-10),
                    CreatedBy = adminUser.Id,
                    CreatedAt = DateTime.UtcNow
                },
                new Transaction
                {
                    Id = Guid.NewGuid(),
                    Type = "income",
                    Amount = 75000.00m,
                    Description = "Monthly retainer",
                    Category = "Consulting",
                    Date = DateTime.UtcNow.AddDays(-15),
                    CreatedBy = adminUser.Id,
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.Transactions.AddRangeAsync(transactions);
            await context.SaveChangesAsync();

            // Seed Payroll Records
            var payrollRecords = new List<PayrollRecord>
            {
                new PayrollRecord
                {
                    Id = Guid.NewGuid(),
                    EmployeeId = johnEmployee.Id,
                    Period = $"{DateTime.UtcNow.Year}-{DateTime.UtcNow.Month:00}",
                    BaseSalary = 8000.00m,
                    Allowances = 500.00m,
                    Deductions = 200.00m,
                    NetPay = 8300.00m,
                    Status = "approved",
                    ApprovedBy = adminUser.Id,
                    ApprovedAt = DateTime.UtcNow.AddDays(-1),
                    CreatedAt = DateTime.UtcNow
                }
            };

            await context.PayrollRecords.AddRangeAsync(payrollRecords);
            await context.SaveChangesAsync();

            // Seed Assets
            var assets = new List<Asset>
            {
                new Asset
                {
                    Id = Guid.NewGuid(),
                    Name = "Dell Laptop XPS 13",
                    Description = "Developer workstation",
                    Category = "IT Equipment",
                    SerialNumber = "DELL-XPS-001",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-6),
                    PurchaseValue = 2500.00m,
                    CurrentValue = 2000.00m,
                    Status = "active",
                    AssignedTo = johnEmployee.Id,
                    Location = "Office A-101",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                },
                new Asset
                {
                    Id = Guid.NewGuid(),
                    Name = "Projector Epson EB-S41",
                    Description = "Conference room projector",
                    Category = "AV Equipment",
                    SerialNumber = "EPSON-PRJ-001",
                    PurchaseDate = DateTime.UtcNow.AddMonths(-12),
                    PurchaseValue = 800.00m,
                    CurrentValue = 600.00m,
                    Status = "active",
                    Location = "Conference Room 1",
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            await context.Assets.AddRangeAsync(assets);
            await context.SaveChangesAsync();
        }
    }
}