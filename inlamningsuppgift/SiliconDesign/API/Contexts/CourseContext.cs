using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Contexts;

public class CourseContext(DbContextOptions<CourseContext> options) : DbContext(options) {

    public DbSet<CourseEntity> Courses { get; set; }

    //public CourseContext() :this { }
}
