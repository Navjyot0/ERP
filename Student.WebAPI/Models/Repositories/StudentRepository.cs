using Students.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Students.WebAPI.Models.Repositories
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly StudentDbContext dbContext;
        public StudentRepository(StudentDbContext studentDb) : base(studentDb)
        {
            dbContext = studentDb;
        }
        public IEnumerable<Student> GetAllStudentsWithAllDetails()
        {
            return dbContext.Students.AsQueryable().Include(s=>s.Grade).AsEnumerable();
        }
    }
}
