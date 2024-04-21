using API.Models;

namespace SiliconAppMVC.Models.Views;

public class CoursesViewModel {
    public IEnumerable<CourseModel> Courses { get; set; } = [];
}
