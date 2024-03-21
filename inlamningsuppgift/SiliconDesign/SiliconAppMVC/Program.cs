using Infrastructure.Contexts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
