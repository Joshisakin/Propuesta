using Propuesta.Models;
using Propuesta.Views;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        public ICommand GoToTeamsCommand { get; }
        public ICommand GoToMatchesCommand { get; }
        public ICommand GoToStandingsCommand { get; }
        public ICommand GoToRegisterPaymentCommand { get; }

        public DashboardViewModel()
        {
            GoToTeamsCommand = new Command(async () => await GoToTeams());
            GoToMatchesCommand = new Command(async () => await GoToMatches());
            GoToStandingsCommand = new Command(async () => await GoToStandings());
            GoToRegisterPaymentCommand = new Command(async () => await GoToRegisterPayment());
        }

        private async Task GoToTeams()
        {
            await Shell.Current.GoToAsync(nameof(TeamsView));
        }

        private async Task GoToMatches()
        {
            await Shell.Current.GoToAsync(nameof(MatchesView));
        }

        private async Task GoToStandings()
        {
            await Shell.Current.GoToAsync(nameof(StandingsView));
        }

        private async Task GoToRegisterPayment()
        {
            await Shell.Current.GoToAsync(nameof(PaymentView));
        }
    }
}
