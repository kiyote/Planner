using Planner.Core;

namespace Planner.ClientApp.Pages.Plans.Models;

public class NewPlanAsset {
	public Guid Id = Guid.CreateVersion7();

	public string? Name { get; set; }

	public AssetTaxStatus? TaxStatus { get; set; }

	public decimal? InterestPercent { get; set; }

	public decimal? Amount { get; set; }
}
