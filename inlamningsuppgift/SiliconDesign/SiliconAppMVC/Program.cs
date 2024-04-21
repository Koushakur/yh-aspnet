using Infrastructure.Contexts;
using Infrastructure.Models.Identity;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

//Identity
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityServer")));
builder.Services.AddDefaultIdentity<AppUser>(x => {
    x.User.RequireUniqueEmail = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireNonAlphanumeric = false;
}).AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AddressService>();

var app = builder.Build();

app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.UseStatusCodePagesWithReExecute("/error", "?statuscode={0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
