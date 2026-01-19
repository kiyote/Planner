using MudBlazor;
using Microsoft.AspNetCore.Components;
using Planner.Core;

namespace Planner.ClientApp.Pages.Plans.Components;

public partial class CreateAssetComponent {
	[CascadingParameter]
	public required IMudDialogInstance MudDialog { get; set; }


	public string AssetName { get; set; } = "";

	public AssetTaxStatus TaxStatus { get; set; } = AssetTaxStatus.Taxable;

	public float InterestRate { get; set; } = 5.0f;

	public decimal Amount { get; set; } = 0.0m;

	private void AddAsset() {
		if( string.IsNullOrWhiteSpace( AssetName ) ) {
			return;
		}
		NewPlanAsset asset = new NewPlanAsset {
			Name = AssetName,
			TaxStatus = TaxStatus,
			InterestRate = InterestRate,
			Amount = Amount
		};

		MudDialog.Close( DialogResult.Ok( asset ) );
	}

	private void CancelAsset() {
		MudDialog.Cancel();
	}
}
