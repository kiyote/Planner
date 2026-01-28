using System.Text.Json.Serialization;

namespace Planner.Core;

[JsonConverter( typeof( JsonStringEnumConverter ) )]
public enum AssetTaxStatus {
	Unknown = -1,
	Taxable = 0,
	TaxFree = 1
}
