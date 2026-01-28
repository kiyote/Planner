namespace Planner.Core;

public record Plan(
	Guid Id,
	string Name,
	Member[] Members,
	Asset[] Assets,
	Income[] Incomes
);
