using DMS.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EFCtx>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("abc")));

builder.Services.AddControllersWithViews();

var app = builder.Build();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=account}/{action=login}/{id?}");


app.UseStaticFiles();

app.Run();
