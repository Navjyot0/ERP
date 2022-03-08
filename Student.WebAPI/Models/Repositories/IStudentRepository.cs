namespace Students.WebAPI.Models.Repositories
{
    public interface IStudentRepository: IRepository<Student>
    {
        IEnumerable<Student> GetAllStudentsWithAllDetails();
    }
}
