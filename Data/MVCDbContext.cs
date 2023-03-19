using EmployeeManagementSystem.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeManagementSystem.Data
{
    public class MVCDbContext : DbContext
    {
       
public MVCDbContext(DbContextOptions options): base(options) { 
        
        }

        public DbSet<Employee> Employees { get; set; }
 
    }
}