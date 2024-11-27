namespace FitnessApp.Infrastructure.Extensions
{
	using System.Reflection;
	using FitnessApp.Data.Models;
	using FitnessApp.Data.Repository;
	using FitnessApp.Data.Repository.Contracts;
	using FitnessApp.Services;
	using FitnessApp.Services.ServiceContracts;
    using FitnessApp.Services.ServiceContracts.FitnessApp.Services.ServiceContracts;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

	public static class ServiceCollectionExtensions
	{
		public static void RegisterRepositories(this IServiceCollection services, Assembly modelsAssembly)
		{
			Type[] typesToExclude = { typeof(ApplicationUser) };
			Type[] modelTypes = modelsAssembly
				.GetTypes()
				.Where(t => !t.IsAbstract && !t.IsInterface &&
							!t.Name.ToLower().EndsWith("attribute"))
				.ToArray();

			foreach (Type type in modelTypes)
			{
				if (!typesToExclude.Contains(type))
				{
					Type repositoryInterface = typeof(IRepository<,>);
					Type repositoryInstanceType = typeof(BaseRepository<,>);
					PropertyInfo? idPropInfo = type
						.GetProperties()
						.Where(p => p.Name.ToLower() == "id")
						.SingleOrDefault();

					Type[] constructArgs = new Type[2];
					constructArgs[0] = type;

					if (idPropInfo == null)
					{
						constructArgs[1] = typeof(object);
					}
					else
					{
						constructArgs[1] = idPropInfo.PropertyType;
					}

					repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
					repositoryInstanceType = repositoryInstanceType.MakeGenericType(constructArgs);

					services.AddScoped(repositoryInterface, repositoryInstanceType);
				}
			}
		}
        public static void RegisterUserDefinedServices(this IServiceCollection services)
		{
			services.AddScoped<IDietService, DietService>();
			services.AddScoped<IExerciseService, ExerciseService>();
			services.AddScoped<IProgressService, ProgressService>();
			services.AddScoped<IRecipeService, RecipeService>();
			services.AddScoped<IWorkoutService, WorkoutService>();
			services.AddScoped<IBaseService, BaseService>();
			services.AddScoped<IUserRoleService, UserRoleService>();
		}
	}
}
