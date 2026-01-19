using Microsoft.AspNetCore.Components;
using MudBlazor;
using Planner.Core.LifeExpectancies;
using Planner.ClientApp.Pages.Plans.Components;

namespace Planner.ClientApp.Pages.Plans;

public partial class CreatePage {
	[Inject]
	public required IDialogService DialogService {get; set;}

	public List<NewPlanMember> Members = [];

	public List<NewPlanAsset> PlanAssets = [];

	private string _planName = $"Plan {DateTime.UtcNow.ToString( format: "yyyy-MMM-dd" )}";

	private void RemoveMember(
		Guid memberId
	) {
		IEnumerable<NewPlanMember> toRemove = Members.Where( member => member.Id == memberId );
		Members = Members.Except( toRemove ).ToList();
	}

	private void RemoveAsset(
		Guid assetId
	) {
		IEnumerable<NewPlanAsset> toRemove = PlanAssets.Where( asset => asset.Id == assetId );
		PlanAssets = PlanAssets.Except( toRemove ).ToList();
	}

	private async Task ShowCreatePlanMemberAsync(
	) {
        var options = new DialogOptions { CloseOnEscapeKey = true };

		IDialogReference dialog = await DialogService.ShowAsync<CreatePlanMemberComponent>("New Member", options);
		DialogResult? result = await dialog.Result;
		if (result?.Data is NewPlanMember member) {
			Members.Add( member );
		}
	}

	private async Task ShowCreatePlanAssetAsync(
	) {
        var options = new DialogOptions { CloseOnEscapeKey = true };

		IDialogReference dialog = await DialogService.ShowAsync<CreateAssetComponent>("New Asset", options);
		DialogResult? result = await dialog.Result;
		if (result?.Data is NewPlanAsset asset) {
			PlanAssets.Add( asset );
		}
	}
}
