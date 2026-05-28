using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CourseDetailsApi.Data;

public class CourseDetailsDbContextFactory : IDesignTimeDbContextFactory<CourseDetailsDbContext>
{
    public CourseDetailsDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CourseDetailsDbContext>();
        optionsBuilder.UseSqlServer("Server=tcp:shiko-lms-sql.database.windows.net,1433;Initial Catalog=ShikoAuthDb;Persist Security Info=False;User ID=CloudSA60d426fe;Password=Shiko123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        return new CourseDetailsDbContext(optionsBuilder.Options);
    }
}