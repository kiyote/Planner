using System;
using Microsoft.Extensions.DependencyInjection;

namespace Planner.Core.LifeExpectancies;

public static class ExtensionMethods {
	public static IServiceCollection AddHardcodedLifeExpectancyProvider(
		this IServiceCollection services
	) {
		_ = services.AddSingleton<ILifeExpectancyProvider, HardcodedLifeExpectancyProvider>();

		return services;
	}

}
