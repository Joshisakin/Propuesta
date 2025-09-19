using Propuesta.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public partial class PaginaPartidosViewModel : ObservableObject
    {
        public ObservableCollection<Match> Matches { get; }
        public ICommand RecordResultCommand { get; }

        public PaginaPartidosViewModel()
        {
            Matches = new ObservableCollection<Match>(GetMockMatches());
            RecordResultCommand = new Command<Match>(async (match) => await RecordResult(match));
        }

        private async Task RecordResult(Match match)
        {
            var window = Application.Current?.Windows?.FirstOrDefault();
            if (window?.Page == null) return;

            string? homeScoreStr = await window.Page.DisplayPromptAsync("Resultado", $"Goles de {match.HomeTeam.Name}:");
            if (homeScoreStr == null) return;

            string? awayScoreStr = await window.Page.DisplayPromptAsync("Resultado", $"Goles de {match.AwayTeam.Name}:");
            if (awayScoreStr == null) return;

            if (int.TryParse(homeScoreStr, out int homeScore) && int.TryParse(awayScoreStr, out int awayScore))
            {
                match.HomeScore = homeScore;
                match.AwayScore = awayScore;
                match.IsResultConfirmed = true;
            }
            else
            {
                await window.Page.DisplayAlert("Error", "Por favor, ingrese un marcador válido.", "OK");
            }
        }

        private List<Match> GetMockMatches()
        {
            var teams = new PaginaEquiposViewModel().Teams;
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
