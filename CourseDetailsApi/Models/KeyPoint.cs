namespace CourseDetailsApi.Models;

public class KeyPoint
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid CourseId { get; set; }
}