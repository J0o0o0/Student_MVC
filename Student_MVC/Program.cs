using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Student_MVC.Models;
using Student_MVC.Services;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddScoped<IStudentRepository, StudentRepoService>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepoService>();



builder.Services.AddDbContext<StdContext>(OptionsBuilder =>
    OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("myConn")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



/*app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("myRout",
        "{controller=Student}/{action=Index}/{id?}");
});*/



app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
