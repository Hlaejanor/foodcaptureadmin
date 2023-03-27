using Microsoft.EntityFrameworkCore;
using Volo.Abp.DependencyInjection;

namespace FoodcaptureAdmin.Data;

public class FoodcaptureAdminEFCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public FoodcaptureAdminEFCoreDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the FoodcaptureAdminDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<FoodcaptureAdminDbContext>()
            .Database
            .MigrateAsync();
    }
}
