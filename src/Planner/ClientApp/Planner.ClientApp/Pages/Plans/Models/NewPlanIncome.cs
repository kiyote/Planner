using Planner.Core;

namespace Planner.ClientApp.Pages.Plans.Models;

public class NewPlanIncome {

	public Guid Id = Guid.CreateVersion7();

	public string? Name { get; set; }

	public IncomeFrequency? Frequency { get; set; }

	public decimal? Amount { get; set; }

	public Guid? TargetAssetId { get; set; }

	public DateTime? StartDate { get; set; }

	public DateTime? EndDate { get; set; }
}
