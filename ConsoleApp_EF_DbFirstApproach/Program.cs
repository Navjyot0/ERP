// See https://aka.ms/new-console-template for more information
using ConsoleApp_EF_DbFirstApproach;

using (SchoolCRUD sc = new SchoolCRUD())
{
    sc.AddNewStudents();
    sc.GetStudents();
    sc.DeleteStudent();
    sc.GetStudentBySqlQuery();
    sc.GetStudentByIdFromSqlStoredProcedure(1);
}

EmployeeCRUD.DisplayList();
bool continueLoop = true;
while (continueLoop)
{
    Console.WriteLine(@"
You can choose from below:\n
0: exit\n
1: Add New\n
2: Update\n
3: Delete\n
4: Display\n
5.:Clear Screen
");
    switch (Console.ReadLine())
    {
        case "0": continueLoop = false; break;
        case "1": EmployeeCRUD.AddEmployee(); break;
        case "2": EmployeeCRUD.UpdateEmployeeName(); break;
        case "3": EmployeeCRUD.DeleteEmployee(); break;
        case "4": EmployeeCRUD.DisplayList(); break;
        case "5": Console.Clear(); break;
        default: Console.WriteLine("Invalid!!"); continue;
    }
}
