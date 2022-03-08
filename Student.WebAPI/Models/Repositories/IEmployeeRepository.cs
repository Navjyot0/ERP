namespace Students.WebAPI.Models.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int id);
        List<Employee> GetEmployees();
    }
}
