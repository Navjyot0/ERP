using Students.WebAPI.Models;
using Students.WebAPI.Models.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace Students.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        public CoursesController(IUnitOfWork db)
        {
            this._db=db;
        }

        [HttpGet]
        public IEnumerable<Course> GetAllCourses()
        {
            return this._db.Courses.GetAll();
        }

        [HttpGet]
        public Course GetCourseById(int Id)
        {
            return this._db.Courses.GetById(Id);
        }

        [HttpPost]
        public void PostCourse(Course course)
        {  
            this._db.Courses.Add(course);
            this._db.Complete();
        }

        //[HttpPut]
        //public void UpdateCourse(Course course, int id)
        //{
        //    this._db.Courses.GetAll();
        //}
    }
}
