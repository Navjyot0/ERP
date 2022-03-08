using Students.WebAPI.Middleware;
using Students.WebAPI.Models;
using Students.WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Students.WebAPI.Models.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
//ConfigureServices
builder.Services.AddDbContext<StudentDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
//builder.Services.AddControllers();
builder.Services.AddControllers()//.AddNewtonsoftJson();
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddTransient<CustomMiddleware>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Configure
//app.MapGet("/", () => "Hello World!");
//app.UseMiddleware<CustomMiddleware>();
app.MapDefaultControllerRoute();
app.Run();


/*
SELECT * FROM Student
SELECT * FROM Grades
SELECT * FROM StudentAddresses
SELECT * FROM Courses
SELECT * FROM StudentCourses
 */