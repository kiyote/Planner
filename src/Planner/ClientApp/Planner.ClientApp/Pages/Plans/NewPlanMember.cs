namespace Planner.ClientApp.Pages.Plans;

public class NewPlanMember {
	public Guid Id { get; } = Guid.NewGuid();

	public string? Name { get; set; }

	public DateTime? Birthdate { get; set; }

	public int LifeExpectancyInYears { get; set; }
}
