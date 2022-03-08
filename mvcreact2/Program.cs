var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseStaticFiles();

app.UseRouting();

//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
//options.RoutePrefix = string.Empty;
//});

app.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.Run();
