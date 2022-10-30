namespace Travel.Web.Infrastructure
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using Travel.Data;

    using static Travel.Web.Constants.WebConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var services = serviceScope.ServiceProvider;

            MigrateDatabase(services);
            SeedAdministrator(services);

            return app;
        }

        private static void SeedAdministrator(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync(AdminRoleName))
                    {
                        return;
                    }

                    var role = new IdentityRole { Name = AdminRoleName };
                    await roleManager.CreateAsync(role);

                    var user = new IdentityUser
                    {
                        Email = "Admin@gmail.com",
                        UserName = "Admin@gmail.com"
                    };

                    await userManager.CreateAsync(user, "admin123");
                    await userManager.AddToRoleAsync(user, role.Name);
                })
                .GetAwaiter()
                .GetResult();
        }

        private static void MigrateDatabase(IServiceProvider services)
        {
            services.GetRequiredService<ApplicationDbContext>()
                .Database
                .Migrate();
        }
    }
}
