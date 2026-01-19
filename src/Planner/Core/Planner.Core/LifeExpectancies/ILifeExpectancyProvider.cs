using System;

namespace Planner.Core.LifeExpectancies;

public interface ILifeExpectancyProvider
{
	int GetLifeExpectancyInYears(
		DateTime birthDate,
		DateTime currentDate
	);

}
