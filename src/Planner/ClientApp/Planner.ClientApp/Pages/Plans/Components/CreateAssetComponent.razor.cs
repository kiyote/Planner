using MudBlazor;
using Microsoft.AspNetCore.Components;
using Planner.Core;
using Planner.ClientApp.Pages.Plans.Models;

namespace Planner.ClientApp.Pages.Plans.Components;

public partial class CreateAssetComponent {
	[CascadingParameter]
	public required IMudDialogInstance MudDialog { get; set; }

	public string AssetName { get; set; } = "";

	public AssetTaxStatus TaxStatus { get; set; } = AssetTaxStatus.Taxable;

	[Parameter]
	public decimal InterestRatePercent { get; set; } = 0.0m;

	public decimal Amount { get; set; } = 0.0m;

	private void AddAsset() {
		if( string.IsNullOrWhiteSpace( AssetName ) ) {
			return;
		}
		NewPlanAsset asset = new NewPlanAsset {
			Name = AssetName,
			TaxStatus = TaxStatus,
			InterestPercent = InterestRatePercent,
			Amount = Amount
		};

		MudDialog.Close( DialogResult.Ok( asset ) );
	}

	private void CancelAsset() {
		MudDialog.Cancel();
	}
}
