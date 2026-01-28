namespace Planner.ClientApp.Storage;

public record PlanSummary(
	Guid Id,
	string Name,
	DateTime LastUpdated
);
