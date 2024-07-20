using TripLog.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//  options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
//      new MySqlServerVersion(new Version(8, 0, 28)))); // Adjust version as per your MySQL server version

builder.Services.AddDbContext<TripContext>(options =>
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "trip_add",
    pattern: "/Trip/Add",
    defaults: new { controller = "Trip", action = "Add" }
);

app.MapControllerRoute(
    name: "trip_add_page2",
    pattern: "/Trip/Add/Page2",
    defaults: new { controller = "Trip", action = "AddPage2" }
);

app.MapControllerRoute(
    name: "trip_add_page3",
    pattern: "/Trip/Add/Page3",
    defaults: new { controller = "Trip", action = "AddPage3" }
);


app.Run();
