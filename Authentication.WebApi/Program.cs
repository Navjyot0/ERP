using Authentication.WebApi.Data;
using Authentication.WebApi.Handlers;
using Authentication.WebApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Add ConfigureServices() here
//--------------For Json as default response for your Api controller--------
builder.Services.AddControllers()
    //Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson
    .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//--------------For Json as default response for your Api controller--------


//-----------For Basic Authentication --------------
//builder.Services.AddAuthentication("BasicAuthenticationHandler")
//    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthenticationHandler", null);
//-----------For Basic Authentication --------------


//-----------For JWT Authentication --------------
var jwtSection = builder.Configuration.GetSection("JWTSettings");
builder.Services.Configure<JWTSettings>(jwtSection);

//to validate the token which has been sent by clients
var appSettings = jwtSection.Get<JWTSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = true;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
    };
});

//-----------For JWT Authentication --------------


//--------------to configure databse connection string to your entity framework DbContext Class--------
var connectionString = builder.Configuration.GetConnectionString("EmployeeDb");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
//--------------to configure databse connection string to your entity framework DbContext Class--------
#endregion #region Add ConfigureServices() here

var app = builder.Build();


#region Add Configure() here
//app.MapGet("/", () => "Hello World!");
app.UseHttpsRedirection(); //Adds middleware for redirecting HTTP Requests to HTTPS.
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});
#endregion Add Configure() here

app.Run();
