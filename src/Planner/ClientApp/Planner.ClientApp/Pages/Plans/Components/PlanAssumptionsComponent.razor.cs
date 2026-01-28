using Microsoft.AspNetCore.Components;

namespace Planner.ClientApp.Pages.Plans.Components;

public partial class PlanAssumptionsComponent {

	[Parameter]
	public decimal InflationPercent { get; set; }

	[Parameter]
	public EventCallback<decimal> InflationPercentChanged { get; set; }

	[Parameter]
	public decimal InterestPercent { get; set; }

	[Parameter]
	public EventCallback<decimal> InterestPercentChanged { get; set; }
}
