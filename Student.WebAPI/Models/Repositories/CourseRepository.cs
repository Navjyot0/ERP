using Students.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Students.WebAPI.Models.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(StudentDbContext studentDb):base(studentDb)
        {
        }
        public IEnumerable<Course> GetPopularCourses(int count)
        {
            throw new NotImplementedException();
        }
    }
}
