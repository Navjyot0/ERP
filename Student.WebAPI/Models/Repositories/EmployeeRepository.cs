namespace Students.WebAPI.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e=>e.EmployeeId==id);
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        private List<Employee> _employees = new List<Employee>()
        {
            new Employee(){ EmployeeId = 101, FirstName = "ABC_101", LastName = "XYZ_101", Age = 31 },
            new Employee(){ EmployeeId = 102, FirstName = "ABC_102", LastName = "XYZ_102", Age = 31 },
            new Employee(){ EmployeeId = 103, FirstName = "ABC_103", LastName = "XYZ_103", Age = 31 },
            new Employee(){ EmployeeId = 104, FirstName = "ABC_104", LastName = "XYZ_104", Age = 31 },
            new Employee(){ EmployeeId = 105, FirstName = "ABC_105", LastName = "XYZ_105", Age = 31 },
            new Employee(){ EmployeeId = 106, FirstName = "ABC_106", LastName = "XYZ_106", Age = 31 },
            new Employee(){ EmployeeId = 107, FirstName = "ABC_107", LastName = "XYZ_107", Age = 31 }
        };
    }
}
