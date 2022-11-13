namespace SourceControl.Web.Infrastructure;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);

        return app;
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
    }
}
