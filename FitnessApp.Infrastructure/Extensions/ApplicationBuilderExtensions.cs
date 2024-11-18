namespace FitnessApp.Infrastructure.Extensions
{
	using FitnessApp.Data;
	using Microsoft.AspNetCore.Builder;
	using Microsoft.EntityFrameworkCore;
	using Microsoft.Extensions.DependencyInjection;

	public static class ApplicationBuilderExtensions
	{
		public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
		{
			using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

			FitnessDBContext dbContext = serviceScope
				.ServiceProvider
				.GetRequiredService<FitnessDBContext>()!;
			dbContext.Database.Migrate();

			return app;
		}
	}
}
