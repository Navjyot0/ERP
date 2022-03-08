using Students.WebAPI.Models.Repositories;

namespace Students.WebAPI.Models.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IStudentRepository Students { get; }
        int Complete();
    }
}
