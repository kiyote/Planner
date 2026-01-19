
using MudBlazor;
using Microsoft.AspNetCore.Components;
using Planner.Core.LifeExpectancies;

namespace Planner.ClientApp.Pages.Plans.Components;

public partial class CreatePlanMemberComponent {

	[CascadingParameter]
	public required IMudDialogInstance MudDialog { get; set; }

	[Inject]
	public required ILifeExpectancyProvider LifeExpectancyProvider { get; set; }

	private DateTime? _memberBirthdate = null;
	private string? _memberName = null;

	private void AddMember() {
		if( string.IsNullOrWhiteSpace( _memberName )
			|| ( _memberBirthdate is null )
		) {
			return;
		}
		NewPlanMember member = new NewPlanMember {
			Name = _memberName,
			Birthdate = _memberBirthdate,
			LifeExpectancyInYears = LifeExpectancyProvider.GetLifeExpectancyInYears( _memberBirthdate.Value, DateTime.UtcNow )
		};

		MudDialog.Close( DialogResult.Ok( member ) );
	}

	private void CancelMember() {
		MudDialog.Cancel();
	}
}

