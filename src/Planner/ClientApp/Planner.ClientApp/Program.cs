using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using Planner.Core.LifeExpectancies;

namespace Planner.ClientApp;

public class Program {
	public static async Task Main( string[] args ) {
		var builder = WebAssemblyHostBuilder.CreateDefault( args );
		builder.RootComponents.Add<App>( "#app" );
		builder.RootComponents.Add<HeadOutlet>( "head::after" );

		_ = builder.Services
			.AddScoped( sp => new HttpClient { BaseAddress = new Uri( builder.HostEnvironment.BaseAddress ) } )
			.AddMudServices()
			.AddHardcodedLifeExpectancyProvider();

		await builder.Build().RunAsync();
	}
}
