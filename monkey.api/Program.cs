using monkey.api.Services;
using monkey.api.Repsoitories;
using Microsoft.EntityFrameworkCore;

 
var _builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    ApplicationName = typeof(Program).Assembly.FullName,
    ContentRootPath = Directory.GetCurrentDirectory(),
    EnvironmentName = Environments.Development
});
 
IConfiguration _configuration = _builder.Configuration;
IWebHostEnvironment _environment = _builder.Environment;
var tmp99 = _configuration["ConfigName"];



var _services = _builder.Services;

// Add services to the container.

_services.AddControllers();

_services.AddControllersWithViews();
_services.AddLocalization();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
_services.AddEndpointsApiExplorer();
_services.AddSwaggerGen();
 
_services.AddDbContext<MyContext>(options =>
   {
       options
     .UseSqlServer(_configuration["ConnString"]);

   }); 

_services.AddScoped<AppUserService, AppUserService>();



var app = _builder.Build(); 




app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (_environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.MapControllers();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Users}/{action=Index}/{id?}");
    });

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();


