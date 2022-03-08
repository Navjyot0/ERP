using Microsoft.EntityFrameworkCore;

namespace Students.WebAPI.Models
{
    public static class ModelBuilderExtention
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(new Models.Employee { EmployeeId = 1, FirstName = "Navjyot", LastName = "Gurhale", Age = 28 });
        }
    }
}
