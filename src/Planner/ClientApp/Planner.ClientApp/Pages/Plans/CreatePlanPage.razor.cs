using Microsoft.AspNetCore.Components;
using MudBlazor;
using Planner.ClientApp.Pages.Plans.Components;
using Planner.ClientApp.Pages.Plans.Models;
using Planner.ClientApp.Storage;
using Planner.Core;

namespace Planner.ClientApp.Pages.Plans;

public partial class CreatePlanPage {

	[Inject]
	public required NavigationManager NavigationManager { get; set; }

	[Inject]
	public required IDialogService DialogService { get; set; }

	[Inject]
	public required IPlanStorage PlanStorage { get; set; }

	private List<NewPlanMember> _members = [];

	private List<NewPlanAsset> _planAssets = [];

	private List<NewPlanIncome> _planIncomes = [];

	private string _planName = $"Plan {DateTime.UtcNow:yyyy-MMM-dd}";

	private decimal _defaultInflationPercent = 3;

	private decimal _defaultInterestPercent = 5;

	private void RemoveMember(
		Guid memberId
	) {
		IEnumerable<NewPlanMember> toRemove = _members.Where( member => member.Id == memberId );
		_members = [ .. _members.Except( toRemove ) ];
	}

	private void RemoveAsset(
		Guid assetId
	) {
		IEnumerable<NewPlanAsset> toRemove = _planAssets.Where( asset => asset.Id == assetId );
		_planAssets = [ .. _planAssets.Except( toRemove ) ];
	}

	private void RemoveIncome(
		Guid incomeId
	) {
		IEnumerable<NewPlanIncome> toRemove = _planIncomes.Where( income => income.Id == incomeId );
		_planIncomes = [ .. _planIncomes.Except( toRemove ) ];
	}

	private async Task ShowCreatePlanMemberAsync(
	) {
		var options = new DialogOptions { CloseOnEscapeKey = true };

		IDialogReference dialog = await DialogService.ShowAsync<CreatePlanMemberComponent>( "New Member", options );
		DialogResult? result = await dialog.Result;
		if( result?.Data is NewPlanMember member ) {
			_members.Add( member );
		}
	}

	private async Task ShowCreatePlanAssetAsync(
	) {
		var options = new DialogOptions { CloseOnEscapeKey = true };
		var parameters = new DialogParameters<CreateAssetComponent> {
			{ p => p.InterestRatePercent, _defaultInterestPercent }
		};

		IDialogReference dialog = await DialogService.ShowAsync<CreateAssetComponent>( "New Asset", parameters, options );
		DialogResult? result = await dialog.Result;
		if( result?.Data is NewPlanAsset asset ) {
			_planAssets.Add( asset );
		}
	}

	private async Task ShowCreatePlanIncomeAsync(
	) {
		var options = new DialogOptions { CloseOnEscapeKey = true };
		var parameters = new DialogParameters<CreateIncomeComponent> {
			{ p => p.PlanAssets, _planAssets }
		};

		IDialogReference dialog = await DialogService.ShowAsync<CreateIncomeComponent>( "New Income", parameters, options );
		DialogResult? result = await dialog.Result;
		if( result?.Data is NewPlanIncome income ) {
			_planIncomes.Add( income );
		}
	}

	private async Task CreatePlanAsync() {
		Member[] members = [ .. _members.Where( m => m.Name is not null && m.Birthdate is not null ).Select( m => new Member( m.Id, m.Name!, m.Birthdate!.Value, m.LifeExpectancyInYears ) ) ];
		Asset[] assets = [ .. _planAssets.Where( a => a.Name is not null && a.Amount is not null && a.InterestPercent is not null && a.Amount is not null ).Select( a => new Asset( a.Id, a.Name!, a.InterestPercent!.Value, a.TaxStatus!.Value, a.Amount!.Value ) ) ];
		Income[] incomes = [ .. _planIncomes.Where( i => i.Name is not null && i.Amount is not null ).Select( i => new Income( i.Id, i.Name!, i.Frequency!.Value, i.Amount!.Value, i.TargetAssetId!.Value ) ) ];

		Guid id = Guid.CreateVersion7();
		Plan plan = new Plan(
			id,
			_planName,
			members,
			assets,
			incomes
		);
		await PlanStorage.SavePlanAsync( plan );
		NavigationManager.NavigateTo( $"/plans/{id:N}" );
	}
}
