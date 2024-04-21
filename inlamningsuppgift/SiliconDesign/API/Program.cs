using API.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CourseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CourseServer")));
builder.Services.AddDbContext<SubscriberContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SubscriberServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
