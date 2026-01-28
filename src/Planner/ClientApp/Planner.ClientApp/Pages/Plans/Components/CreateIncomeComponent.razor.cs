using Microsoft.AspNetCore.Components;
using MudBlazor;
using Planner.ClientApp.Pages.Plans.Models;
using Planner.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Planner.ClientApp.Pages.Plans.Components;

public partial class CreateIncomeComponent {
	[CascadingParameter]
	public required IMudDialogInstance MudDialog { get; set; }

	[Parameter]
	public List<NewPlanAsset> PlanAssets { get; set; } = [];

	public string IncomeName { get; set; } = "";

	public IncomeFrequency Frequency { get; set; } = IncomeFrequency.Monthly;

	public decimal Amount { get; set; } = 0.0m;

	public Guid? TargetAssetId { get; set; }

	public DateTime? StartDate { get; set; } = new DateTime( DateTime.UtcNow.Year, DateTime.UtcNow.Month, 1 );

	public DateTime? EndDate { get; set; }

	private void AddIncome() {
		if( string.IsNullOrWhiteSpace( IncomeName )
			|| TargetAssetId is null
		) {
			return;
		}
		NewPlanIncome income = new NewPlanIncome {
			Name = IncomeName,
			Frequency = Frequency,
			Amount = Amount,
			TargetAssetId = TargetAssetId,
			StartDate = StartDate,
			EndDate = EndDate
		};

		MudDialog.Close( DialogResult.Ok( income ) );
	}

	private void CancelAsset() {
		MudDialog.Cancel();
	}
}
