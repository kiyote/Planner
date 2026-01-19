using System;

namespace Planner.Core.LifeExpectancies;

public class HardcodedLifeExpectancyProvider : ILifeExpectancyProvider {
	public int GetLifeExpectancyInYears(
		DateTime birthDate,
		DateTime currentDate
	) {
		return 85;
	}
}
