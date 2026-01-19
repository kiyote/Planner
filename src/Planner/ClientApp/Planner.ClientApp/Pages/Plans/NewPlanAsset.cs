using Planner.Core;

namespace Planner.ClientApp.Pages.Plans;

public class NewPlanAsset {
	public Guid Id = Guid.NewGuid();

	public string? Name { get; set; }

	public AssetTaxStatus? TaxStatus { get; set; }

	public float? InterestRate { get; set; }

	public decimal? Amount { get; set; }
}
