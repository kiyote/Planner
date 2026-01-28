namespace Planner.ClientApp.Storage;

public static class ExtensionMethods {

	public static IServiceCollection AddLocalStoragePlanStorage(
		this IServiceCollection services
	) {
		_ = services.AddScoped<IPlanStorage, LocalStoragePlanStorage>();

		return services;
	}
}
