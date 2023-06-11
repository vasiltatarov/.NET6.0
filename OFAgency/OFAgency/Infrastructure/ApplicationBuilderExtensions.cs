using Microsoft.EntityFrameworkCore;
using OFAgency.Data;

namespace OFAgency.Infrastructure
{
	public static class ApplicationBuilderExtensions 
	{
		public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
		{
			using var serviceScope = app.ApplicationServices.CreateScope();
			var services = serviceScope.ServiceProvider;

			MigradeDatabase(services);

			return app;
		}

		private static void MigradeDatabase(IServiceProvider services)
			=> services.GetRequiredService<ApplicationDbContext>().Database.Migrate();
	}
}
