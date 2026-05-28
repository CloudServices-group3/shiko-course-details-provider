using CourseDetailsApi.Data;
using CourseDetailsApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CourseDetailsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CourseDetailsController : ControllerBase
{
    private readonly CourseDetailsDbContext _db;

    public CourseDetailsController(CourseDetailsDbContext db)
    {
        _db = db;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var course = await _db.CourseDetails
            .Include(c => c.KeyPoints)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (course is null) return NotFound();

        var dto = new CourseDetailDto
        {
            Id = course.Id,
            Title = course.Title,
            ImageUrl = course.ImageUrl,
            LessonCount = course.LessonCount,
            Duration = course.Duration,
            Description = course.Description,
            KeyPoints = course.KeyPoints.Select(kp => new KeyPointDto
            {
                Id = kp.Id,
                Text = kp.Text
            }).ToList()
        };

        return Ok(dto);
    }
}