namespace Planner.ClientApp.Pages.Plans.Models;

public class NewPlanMember {
	public Guid Id { get; } = Guid.CreateVersion7();

	public string? Name { get; set; }

	public DateTime? Birthdate { get; set; }

	public int LifeExpectancyInYears { get; set; }
}
