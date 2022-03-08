using Students.WebAPI.Data;
using Students.WebAPI.Models.Repositories;

namespace Students.WebAPI.Models.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly StudentDbContext _dbContext;

        public UnitOfWork(StudentDbContext dbContext)
        {
            this._dbContext = dbContext;
            Courses = new CourseRepository(this._dbContext);
            Students = new StudentRepository(this._dbContext);
        }

        public ICourseRepository Courses { get; private set; }
        public IStudentRepository Students { get; private set; }

        public int Complete()
        {
            return this._dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
