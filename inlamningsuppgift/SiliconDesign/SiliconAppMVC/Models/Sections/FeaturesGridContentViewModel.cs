using SiliconAppMVC.Models.Components;

namespace SiliconAppMVC.Models.Sections;

public class FeaturesGridContentViewModel {
    public ImageViewModel Image { get; set; } = null!;
    public string Title { get; set; } = "";
    public string Text { get; set; } = "";
}
