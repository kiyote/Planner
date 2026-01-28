using Microsoft.AspNetCore.Components;
using Planner.ClientApp.Storage;

namespace Planner.ClientApp.Pages.Plans;

public partial class LoadPlanPage {

	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	[Inject]
	public required IPlanStorage PlanStorage { get; set; }

	private PlanSummary[] _plans = [];

	protected override async Task OnInitializedAsync() {

		_plans = await PlanStorage.GetPlansAsync();
	}
}
