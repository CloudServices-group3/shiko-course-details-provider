using CourseDetailsApi.Data;
using CourseDetailsApi.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CourseDetailsDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null
        )
    ));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<CourseDetailsDbContext>();
        db.Database.Migrate();

        if (!db.CourseDetails.Any())
        {
            db.CourseDetails.AddRange(
                new CourseDetail
                {
                    Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                    Title = "Artificial Intelligence",
                    ImageUrl = "/images/ai.png",
                    LessonCount = 15,
                    Duration = "13 hr 35 min",
                    Description = "An introduction to artificial intelligence and machine learning.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Understand AI fundamentals" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Build ML models" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Work with neural networks" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Apply AI to real problems" }
                    }
                },
                new CourseDetail
                {
                    Id = Guid.Parse("882d1c96-b77f-46cc-994c-d12bbd16a0de"),
                    Title = "Data Science & Analytics",
                    ImageUrl = "/images/data-science.png",
                    LessonCount = 25,
                    Duration = "20 hr 40 min",
                    Description = "Learn how to analyse and work with large sets of data.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Data cleaning and preparation" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Statistical analysis" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Data visualisation" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Predictive modelling" }
                    }
                },
                new CourseDetail
                {
                    Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                    Title = "Digital Marketing",
                    ImageUrl = "/images/digital-marketing.png",
                    LessonCount = 5,
                    Duration = "1 hr 18 min",
                    Description = "Understand the basics of marketing in a digital world.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Set your marketing goals" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Identify your target audience" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Choose the right platform" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Create compelling content" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Launch and monitor your campaign" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Track performance in real-time" }
                    }
                },
                new CourseDetail
                {
                    Id = Guid.Parse("d9da7d05-0605-4ef3-8fc2-ec0a1ff90cc1"),
                    Title = "UI/UX Design for Beginner",
                    ImageUrl = "/images/uiux.png",
                    LessonCount = 34,
                    Duration = "27 hr 55 min",
                    Description = "Learn how to design user friendly interfaces from scratch.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Understand user needs" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Create wireframes" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Build prototypes" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Test with real users" }
                    }
                },
                new CourseDetail
                {
                    Id = Guid.Parse("7a875d05-b4fb-4b27-bc50-b776aaef14d4"),
                    Title = "Full stack Developer",
                    ImageUrl = "/images/fullstack.png",
                    LessonCount = 30,
                    Duration = "24 hr 45 min",
                    Description = "Build complete web applications with both frontend and backend.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Frontend with React/Next.js" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Backend with ASP.NET Core" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Database design" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Deploy to the cloud" }
                    }
                },
                new CourseDetail
                {
                    Id = Guid.Parse("0be85b35-ba14-417b-ba04-2a1c0bd0d509"),
                    Title = "Sketch for Designer",
                    ImageUrl = "/images/sketch.png",
                    LessonCount = 18,
                    Duration = "14 hr 25 min",
                    Description = "Get started with Sketch and learn the basics of digital design.",
                    KeyPoints = new()
                    {
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Navigate the Sketch interface" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Create reusable symbols" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Design with grids" },
                        new KeyPoint { Id = Guid.NewGuid(), Text = "Export assets correctly" }
                    }
                }
            );
            db.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Seed error: {ex.Message}");
    }
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();