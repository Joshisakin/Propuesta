using Propuesta.Models;
using Propuesta.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public class TeamsViewModel : ObservableObject
    {
        public ObservableCollection<Team> Teams { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand ViewTeamCommand { get; }

        public TeamsViewModel()
        {
            Teams = new ObservableCollection<Team>(GetMockTeams());
            AddTeamCommand = new Command(async () => await GoToAddTeam());
            ViewTeamCommand = new Command<Team>(async (team) => await GoToViewTeam(team));
        }

        private async Task GoToAddTeam()
        {
            // Navigate to a new page to add a team
            await Shell.Current.GoToAsync(nameof(TeamRegistrationView));
        }

        private async Task GoToViewTeam(Team team)
        {
            // Navigate to a team details page
            var navigationParameter = new Dictionary<string, object>
            {
                { "Team", team }
            };
            await Shell.Current.GoToAsync(nameof(TeamDetailView), navigationParameter);
        }

        private List<Team> GetMockTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Name = "Los Halcones",
                    Description = "Equipo del barrio El Carmen",
                    LogoUrl = "dotnet_bot.png", // Using default bot image as placeholder
                    Players = new List<Player>
                    {
                        new Player { FullName = "Juan Perez", JerseyNumber = 10 },
                        new Player { FullName = "Carlos Ruiz", JerseyNumber = 7 }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { FullName = "Roberto Gomez" }
                },
                new Team
                {
                    Name = "Los Leones",
                    Description = "Equipo de la urbanización La Florida",
                    LogoUrl = "dotnet_bot.png",
                    Players = new List<Player>
                    {
                        new Player { FullName = "Miguel Torres", JerseyNumber = 9 },
                        new Player { FullName = "Luis Mendoza", JerseyNumber = 5 }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { FullName = "Ana Rodriguez" }
                },
                 new Team
                {
                    Name = "Tiburones FC",
                    Description = "Equipo de la playa",
                    LogoUrl = "dotnet_bot.png",
                    Players = new List<Player>
                    {
                        new Player { FullName = "Pedro Pascal", JerseyNumber = 9 },
                        new Player { FullName = "Luis Diaz", JerseyNumber = 5 }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { FullName = "Jorge Jimenez" }
                }
            };
        }
    }
}
