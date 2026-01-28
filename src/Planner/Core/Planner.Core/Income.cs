namespace Planner.Core;

public record Income(
	Guid Id,
	string Name,
	IncomeFrequency Frequency,
	decimal Amount,
	Guid TargetAsset
);
