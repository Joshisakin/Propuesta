using Propuesta.Models;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    [QueryProperty(nameof(Team), "Team")]
    public partial class PaginaDetalleEquipoViewModel : ObservableObject, IQueryAttributable
    {
        private Team? _team;
        public Team? Team
        {
            get => _team;
            set
            {
                _team = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddPlayerCommand { get; }

        public PaginaDetalleEquipoViewModel()
        {
            AddPlayerCommand = new Command(async () => await AddPlayer());
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("Team", out var teamValue) && teamValue is Team team)
            {
                Team = team;
            }
        }

        private async Task AddPlayer()
        {
            if (Team == null) return;

            var window = Application.Current?.Windows?.FirstOrDefault();
            if (window?.Page == null) return;

            
            string? newPlayerName = await window.Page.DisplayPromptAsync("Nuevo Jugador", "Nombre del jugador:");
            if (!string.IsNullOrWhiteSpace(newPlayerName))
            {
                string? jerseyNumberStr = await window.Page.DisplayPromptAsync("Nuevo Jugador", "Número de camiseta:");
                if (int.TryParse(jerseyNumberStr, out int jerseyNumber))
                {
                    var newPlayer = new Player { FullName = newPlayerName, JerseyNumber = jerseyNumber, DNI = "", MobileNumber = "" };
                    Team.Players.Add(newPlayer);
                    var tempTeam = Team;
                    Team = null;
                    Team = tempTeam;
                }
            }
        }
    }
}