using AutoMapper;
using employee_test.Presistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper();
builder.Services.AddCors(options =>
            {
                options.AddPolicy("ClientPermission", policy =>
                {
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed(_ => true)
                        .AllowCredentials();
                });
            });
var configuration = new ConfigurationBuilder().AddJsonFile(
                                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json"))
                            .Build();
builder.Services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    //app.UseDeveloperExceptionPage();

}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;
app.UseCors("ClientPermission");
app.Run();
