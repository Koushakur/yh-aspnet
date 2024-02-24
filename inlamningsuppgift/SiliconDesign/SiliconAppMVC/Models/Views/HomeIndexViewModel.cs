using SiliconAppMVC.Models.Components;
using SiliconAppMVC.Models.Sections;

namespace SiliconAppMVC.Models.Views;
public class HomeIndexViewModel {
    public FeaturesViewModel FeaturesVM { get; set; } = null!;

    public HomeIndexViewModel() {
        FeaturesVM = new FeaturesViewModel {
            GridContent = [
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-chat.svg", AltText = "" },
                    Title = "Comments on Tasks",
                    Text = "Id mollis consectetur congue egestas egestas suspendisse blandit justo.",
                },
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-screen.svg", AltText = "" },
                    Title = "Tasks Analytics",
                    Text = "Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate.",
                },
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-people.svg", AltText = "" },
                    Title = "Multiple Assignees",
                    Text = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris.",
                },
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-bell.svg", AltText = "" },
                    Title = "Notifications",
                    Text = "Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra.",
                },
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-list.svg", AltText = "" },
                    Title = "Sections & Subtasks",
                    Text = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus.",
                },
                new() {
                    Image = new ImageViewModel { ImageURL = "images/icons/f-shield.svg", AltText = "" },
                    Title = "Data Security",
                    Text = "Aliquam malesuada neque eget elit nulla vestibulum nunc cras.",
                },
            ]
        };
    }
}
