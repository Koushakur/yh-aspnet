using Infrastructure.Contexts;
using Infrastructure.Models.Identity;
//using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
//using Shared.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

//Identity
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityServer")));
builder.Services.AddDefaultIdentity<AppUser>(x => {
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<IdentityContext>();
//
//builder.Services.AddScoped<AddressRepository>();
//builder.Services.AddScoped<AddressService>();
//builder.Services.AddScoped<UserRepository>();
//builder.Services.AddScoped<UserService>();

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
