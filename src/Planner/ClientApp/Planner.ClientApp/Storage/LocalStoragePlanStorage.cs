using System.Text.Json;
using Microsoft.JSInterop;
using Planner.Core;

namespace Planner.ClientApp.Storage;

internal class LocalStoragePlanStorage : IPlanStorage {

	private readonly IJSRuntime _js;
	private readonly JsonSerializerOptions _json;

	public LocalStoragePlanStorage(
		IJSRuntime js
	) {
		_js = js;
		_json = new JsonSerializerOptions() {
			AllowTrailingCommas = true,
			IndentCharacter = ' ',
			WriteIndented = true,
			IndentSize = 3,
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
			PropertyNameCaseInsensitive = true
		};
	}

	async Task IPlanStorage.SavePlanAsync(
		Plan plan
	) {
		PlanSummary[] storedPlans = await DoGetPlansAsync();

		if( !storedPlans.Any( s => s.Id == plan.Id ) ) {
			await DoAddPlanSummary( new PlanSummary( plan.Id, plan.Name, DateTime.UtcNow ) );
		};

		string planText = JsonSerializer.Serialize( plan, _json );
		await SetToLocalStorage( plan.Id.ToString( "N" ), planText );
	}

	Task<PlanSummary[]> IPlanStorage.GetPlansAsync() {
		return DoGetPlansAsync();
	}

	private async Task<PlanSummary[]> DoGetPlansAsync() {
		string storedPlansText = await GetFromLocalStorage( "plans" ) ?? "";
		if( string.IsNullOrWhiteSpace( storedPlansText ) ) {
			return [];
		}
		StoredPlans storedPlans = JsonSerializer.Deserialize<StoredPlans>( storedPlansText, _json ) ?? new StoredPlans( [] );
		return [ .. storedPlans.Plans.OrderByDescending( p => p.LastUpdated ) ];
	}

	private async Task DoAddPlanSummary(
		PlanSummary planSummary
	) {
		PlanSummary[] storedPlans = await DoGetPlansAsync();
		StoredPlans newStoredPlans = new StoredPlans(
			[ .. storedPlans, planSummary ]
		);
		string newStoredPlansText = JsonSerializer.Serialize( newStoredPlans, _json );
		await SetToLocalStorage( "plans", newStoredPlansText );
	}

	private async ValueTask SetToLocalStorage( string key, string value ) {
		await _js.InvokeVoidAsync( "localStorage.setItem", key, value );
	}

	private async ValueTask<string?> GetFromLocalStorage( string key, string? defaultValue = null ) {
		return await _js.InvokeAsync<string>( "localStorage.getItem", key ) ?? defaultValue;
	}

	private async ValueTask RemoveFromLocalStorage( string key ) {
		await _js.InvokeVoidAsync( "localStorage.removeItem", key );
	}
}
