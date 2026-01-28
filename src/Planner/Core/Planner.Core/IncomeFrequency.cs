using System.Text.Json.Serialization;

namespace Planner.Core;

[JsonConverter( typeof( JsonStringEnumConverter ) )]
public enum IncomeFrequency {
	Unknown,
	Monthly,
	OneTime,
	Annual
}
