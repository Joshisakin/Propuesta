using Propuesta.Views;

namespace Propuesta;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(TeamDetailView), typeof(TeamDetailView));
		Routing.RegisterRoute(nameof(TeamRegistrationView), typeof(TeamRegistrationView));
		Routing.RegisterRoute(nameof(PaymentView), typeof(PaymentView));
        Routing.RegisterRoute(nameof(MatchesView), typeof(MatchesView));
        Routing.RegisterRoute(nameof(StandingsView), typeof(StandingsView));
        Routing.RegisterRoute(nameof(TeamsView), typeof(TeamsView));
	}
}
