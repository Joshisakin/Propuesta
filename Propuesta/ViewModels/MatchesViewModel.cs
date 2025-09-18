using Propuesta.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public class MatchesViewModel : ObservableObject
    {
        public ObservableCollection<Match> Matches { get; }
        public ICommand RecordResultCommand { get; }

        public MatchesViewModel()
        {
            Matches = new ObservableCollection<Match>(GetMockMatches());
            RecordResultCommand = new Command<Match>(async (match) => await RecordResult(match));
        }

        private async Task RecordResult(Match match)
        {
            string homeScoreStr = await Application.Current.MainPage.DisplayPromptAsync("Resultado", $"Goles de {match.HomeTeam.Name}:");
            string awayScoreStr = await Application.Current.MainPage.DisplayPromptAsync("Resultado", $"Goles de {match.AwayTeam.Name}:");

            if (int.TryParse(homeScoreStr, out int homeScore) && int.TryParse(awayScoreStr, out int awayScore))
            {
                match.HomeScore = homeScore;
                match.AwayScore = awayScore;
                match.IsResultConfirmed = true;

                // In a real app, you would update points and standings here.
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor, ingrese un marcador válido.", "OK");
            }
        }

        private List<Match> GetMockMatches()
        {
            var teams = new TeamsViewModel().Teams; // Get mock teams
            return new List<Match>
            {
                new Match
                {
                    HomeTeam = teams[0],
                    AwayTeam = teams[1],
                    MatchDateTime = DateTime.Now.AddDays(1).AddHours(2),
                    Venue = "Cancha 1"
                },
                new Match
                {
                    HomeTeam = teams[2],
                    AwayTeam = teams[0],
                    MatchDateTime = DateTime.Now.AddDays(2).AddHours(4),
                    Venue = "Cancha 2",
                    HomeScore = 1,
                    AwayScore = 1,
                    IsResultConfirmed = true
                }
            };
        }
    }
}
