

namespace CourseDetailsApi.Models;

public class CourseDetail
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int LessonCount { get; set; }
    public string Duration { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<KeyPoint> KeyPoints { get; set; } = new();
}