using Students.WebAPI.Models;
using Students.WebAPI.Models.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Students.WebAPI.Extentions;
using Students.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace Students.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IUnitOfWork _db;
        private readonly StudentDbContext _StudentDbContext;

        public StudentsController(IUnitOfWork db, StudentDbContext StudentDbContext)
        {
            this._db = db;
            this._StudentDbContext = StudentDbContext;
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudentsWithAllDetails()
        {
            return this._StudentDbContext.Students.Include(s=>s.Address).Include(s=>s.Grade);
        }

        [HttpGet]
        public IEnumerable<Student> GetAllStudents()
        {
            return this._db.Students.GetAll().ToList().AsQueryable().IncludeMultiple(s=>s.Grade, s => s.Grade);
        }

        [HttpGet]
        public Student GetStudentById(int id)
        {
            return this._db.Students.GetById(id);
        }

        [HttpGet]
        public IEnumerable<Student> SearchStudentsByName(string name)
        {
            return this._db.Students.Find(s => s.Name.Contains(name));
        }

        [HttpPost]
        public void AddStudent(Student student)
        {
            this._db.Students.Add(student);
            this._db.Complete();
        }
    }
}
