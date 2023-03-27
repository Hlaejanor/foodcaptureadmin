using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FoodcaptureAdmin.Data;

public class FoodcaptureAdminDbContextFactory : IDesignTimeDbContextFactory<FoodcaptureAdminDbContext>
{
    public FoodcaptureAdminDbContext CreateDbContext(string[] args)
    {
        // https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<FoodcaptureAdminDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new FoodcaptureAdminDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
