using ConsoleApp_EF_DbFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_EF_DbFirstApproach
{
    internal class EmployeeCRUD: IDisposable
    {
        public EmployeeCRUD()//(Employee_DbFirstApproachContext db)
        {
            this.Db = new Employee_DbFirstApproachContext();
        }

        public Employee_DbFirstApproachContext Db { get; }

        public List<Employee> GetAllEmployee()
        {
            return Db.Employees.ToList();
        }

        public void AddEmployee(Employee emp)
        {
            Db.Employees.Add(emp);
            Db.SaveChanges();
        }

        public void UpdateEmployee(Employee emp)
        {
            Db.Employees.Update(emp);
            Db.SaveChanges();
        }

        public void DeleteEmployee(Employee emp)
        {
            Db.Employees.Remove(emp);
            Db.SaveChanges();
        }

        void IDisposable.Dispose()
        {
            this.Db.Dispose();
        }

        public static void DisplayList()
        {
            using (EmployeeCRUD employeeCRUD = new EmployeeCRUD())
            {
                Console.WriteLine("EmpId | Employee Name");
                Console.WriteLine("----------------------------------------");
                foreach (Employee employee in employeeCRUD.GetAllEmployee())
                {
                    Console.WriteLine($"{ employee.EmployeeId.ToString("00000") } | {employee.FirstName}, {employee.LastName}");
                    //Console.WriteLine($"{employee.FirstName} {employee.LastName} ({ employee.EmployeeId }) | Salary: {employee.Salary} | DOB:  { employee.DateOfBirth }");
                }
                Console.WriteLine("----------------------------------------");
            }
        }

        public static void AddEmployee()
        {
            Employee employee = new Employee();
            Console.Write("FirstName: ");
            employee.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            employee.LastName = Console.ReadLine();
            Console.Write("Salary: ");
            employee.Salary = Convert.ToDecimal(Console.ReadLine());
            Console.Write("DateOfBirth: ");
            employee.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

            using (EmployeeCRUD employeeCRUD = new EmployeeCRUD())
            {
                employeeCRUD.AddEmployee(employee);
            }
        }

        public static void UpdateEmployeeName()
        {
            Employee employee = new Employee();
            Console.Write("Employee Id: ");
            employee.EmployeeId = Convert.ToInt32(Console.ReadLine());
            Console.Write("FirstName: ");
            employee.FirstName = Console.ReadLine();
            Console.Write("LastName: ");
            employee.LastName = Console.ReadLine();

            using (EmployeeCRUD employeeCRUD = new EmployeeCRUD())
            {
                employeeCRUD.UpdateEmployee(employee);
            }
        }

        public static void DeleteEmployee()
        {
            Employee employee = new Employee();
            Console.Write("Employee Id: ");
            employee.EmployeeId = Convert.ToInt32(Console.ReadLine());

            using (EmployeeCRUD employeeCRUD = new EmployeeCRUD())
            {
                employeeCRUD.DeleteEmployee(employee);
            }
        }
    }
}
