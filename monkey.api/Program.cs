using monkey.api.Services;
using monkey.api.Repsoitories;

var builder = WebApplication.CreateBuilder(args);
 
// Add services to the container.
builder.Services.AddScoped<AppUserService, AppUserService>();
 
builder.Services.AddControllers();

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 
 
 


var app = builder.Build();


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
 



 