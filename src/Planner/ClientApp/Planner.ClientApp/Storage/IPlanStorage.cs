using Planner.Core;

namespace Planner.ClientApp.Storage;

public interface IPlanStorage {

	Task SavePlanAsync(
		Plan plan
	);

	Task<PlanSummary[]> GetPlansAsync();
}
