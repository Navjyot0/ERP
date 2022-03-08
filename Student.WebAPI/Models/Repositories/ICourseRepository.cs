namespace Students.WebAPI.Models.Repositories
{
    public interface ICourseRepository:IRepository<Course>
    {
        IEnumerable<Course> GetPopularCourses(int count);
    }
}
