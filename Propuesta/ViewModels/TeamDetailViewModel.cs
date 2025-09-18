using Propuesta.Models;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    [QueryProperty(nameof(Team), "Team")]
    public class TeamDetailViewModel : ObservableObject
    {
        private Team _team;
        public Team Team
        {
            get => _team;
            set
            {
                _team = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPlayerCommand { get; }

        public TeamDetailViewModel()
        {
            AddPlayerCommand = new Command(async () => await AddPlayer());
        }

        private async Task AddPlayer()
        {
            // Logic to add a new player
            string newPlayerName = await Application.Current.MainPage.DisplayPromptAsync("Nuevo Jugador", "Nombre del jugador:");
            if (!string.IsNullOrWhiteSpace(newPlayerName))
            {
                string jerseyNumberStr = await Application.Current.MainPage.DisplayPromptAsync("Nuevo Jugador", "Número de camiseta:");
                if (int.TryParse(jerseyNumberStr, out int jerseyNumber))
                {
                    var newPlayer = new Player { FullName = newPlayerName, JerseyNumber = jerseyNumber };
                    Team.Players.Add(newPlayer);
                    // This is a temporary solution. In a real app, you would have a proper collection that notifies changes.
                    // For the prototype, we can force a refresh of the Team property.
                    var tempTeam = Team;
                    Team = null;
                    Team = tempTeam;
                }
            }
        }
    }
}
