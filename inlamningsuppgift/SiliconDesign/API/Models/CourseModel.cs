namespace API.Models;

public class CourseModel {
    public string Id { get; set; }
    public string ImageURL { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal PriceOriginal { get; set; }
    public decimal? PriceDiscounted { get; set; }
    public int Hours { get; set; }
    public int Likes { get; set; }
    public decimal LikePercentage { get; set; }
    public bool? BestSeller { get; set; }
}
