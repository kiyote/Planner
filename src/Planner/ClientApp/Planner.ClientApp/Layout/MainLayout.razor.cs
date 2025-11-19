using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Planner.ClientApp.Layout;

public class MainLayoutBase : LayoutComponentBase {

	public required MudThemeProvider ThemeProvider { get; set; }
	public bool IsDarkMode { get; set; }
	public bool IsDrawerOpen { get; set; }

	protected override async Task OnAfterRenderAsync(
		bool firstRender
	) {
		if( firstRender ) {
			await ThemeProvider.WatchSystemDarkModeAsync( OnSystemDarkModeChanged );
			IsDarkMode = await ThemeProvider.GetSystemDarkModeAsync();

			StateHasChanged();
		}
	}

	protected void DrawerToggle() {
		IsDrawerOpen = !IsDrawerOpen;
	}

	private Task OnSystemDarkModeChanged(
		bool newValue
	) {
		IsDarkMode = newValue;
		return Task.CompletedTask;
	}
}
