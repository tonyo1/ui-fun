using monkey.api.Services;
using monkey.api.Repsoitories;
 
using monkey.api.Models;
using Microsoft.OpenApi.Models;
using monkey.api;

var _builder = WebApplication.CreateBuilder(args);
 
_builder.Logging.ClearProviders();
_builder.Logging.AddConsole();

var _services = _builder.Services;

{
    // Add services to the container.

    _services.AddControllers()
        .AddJsonOptions(x => 
        {
            x.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.Never;
       
            x.JsonSerializerOptions.PropertyNamingPolicy = null; 
            x.JsonSerializerOptions.WriteIndented = true;
        });
   

    _services.AddControllersWithViews();
    _services.AddLocalization();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    _services.AddEndpointsApiExplorer();
    _services.AddSwaggerGen((c) =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test01", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."

        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
     });
       _services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200",
                                            "http://localhost:7296");
                    });

                    options.AddPolicy("Policy1",
                        builder =>
                        {
                            builder.WithOrigins("http://localhost:4200",
                                            "http://localhost:7296")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                        });
            });


  
    _services.AddDbContext<MyContext>(ServiceLifetime.Scoped);

    //_services.AddScoped<IUserService, UserService>();
    _services.AddSingleton<AppSettings, AppSettings>();
    _services.AddScoped<IAppUserService, AppUserService>();
}

var app = _builder.Build();
IConfiguration _configuration = app.Configuration;
IWebHostEnvironment _environment = app.Environment;

// Configure the HTTP request pipeline.
if (_environment.IsDevelopment())
{
    app.UseSwagger(c =>
                {

                });
    app.UseSwaggerUI((c) =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                    c.RoutePrefix = string.Empty;


                });

}

{
    app.UseMiddleware<JwtMiddleware>();
 
  
    app.UseRouting();
    app.UseCors();
    app.UseAuthorization();
    
    app.MapControllers()
        .RequireCors("Policy1");

    app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Users}/{action=Index}/{id?}");
        });

    //app.UseHttpsRedirection();

    

} 

app.Run();


