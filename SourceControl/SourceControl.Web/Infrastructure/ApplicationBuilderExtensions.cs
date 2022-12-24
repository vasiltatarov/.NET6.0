namespace SourceControl.Web.Infrastructure;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        var services = serviceScope.ServiceProvider;

        MigrateDatabase(services);
        SeedAdministartor(services);

        return app;
    }

    private static void SeedAdministartor(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        Task.Run(async () =>
        {
            if (await roleManager.RoleExistsAsync(WebConstants.AdminRoleName))
            {
                return;
            }

            var role = new IdentityRole { Name = WebConstants.AdminRoleName };
            await roleManager.CreateAsync(role);

            var user = new IdentityUser
            {
                Email = WebConstants.AdminEmail,
                UserName = WebConstants.AdminUserName
            };

            await userManager.CreateAsync(user, WebConstants.AdminPassword);
            await userManager.AddToRoleAsync(user, WebConstants.AdminRoleName);
        })
        .GetAwaiter()
        .GetResult();
    }

    private static void MigrateDatabase(IServiceProvider services)
    {
        services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
    }
}
