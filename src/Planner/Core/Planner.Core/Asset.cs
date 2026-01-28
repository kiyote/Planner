namespace Planner.Core;

public record Asset(
	Guid Id,
	string Name,
	decimal InterestPercent,
	AssetTaxStatus TaxStatus,
	decimal Amount
);
