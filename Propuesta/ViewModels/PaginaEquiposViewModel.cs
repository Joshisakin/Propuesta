using Propuesta.Models;
using Propuesta.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public partial class PaginaEquiposViewModel : ObservableObject
    {
        public ObservableCollection<Team> Teams { get; }
        public ICommand AddTeamCommand { get; }
        public ICommand ViewTeamCommand { get; }

        public PaginaEquiposViewModel()
        {
            Teams = new ObservableCollection<Team>(GetMockTeams());
            AddTeamCommand = new Command(async () => await GoToAddTeam());
            ViewTeamCommand = new Command<Team>(async (team) => await GoToViewTeam(team));
        }

        private async Task GoToAddTeam()
        {
            
            await Shell.Current.GoToAsync(nameof(PaginaRegistroEquipo));
        }

        private async Task GoToViewTeam(Team team)
        {
            
            var navigationParameter = new Dictionary<string, object>
            {
                { "Team", team }
            };
            await Shell.Current.GoToAsync(nameof(PaginaDetalleEquipo), navigationParameter);
        }

        private List<Team> GetMockTeams()
        {
            return new List<Team>
            {
                new Team
                {
                    Name = "Fichi1",
                    Description = "Equipo del barrio El Carmen",
                    LogoUrl = "dotnet_bot.png",
                    Players = new List<Player>
                    {
                        new Player { FullName = "Juan Perez", JerseyNumber = 10, DNI = "12345678", MobileNumber = "987654321" },
                        new Player { FullName = "Carlos Ruiz", JerseyNumber = 7, DNI = "87654321", MobileNumber = "987654322" }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { 
                        FullName = "Roberto Gomez", 
                        DNI = "23456789", 
                        MobileNumber = "987654323" 
                    }
                },
                new Team
                {
                    Name = "Fichi2",
                    Description = "Equipo de la urbanización La Florida",
                    LogoUrl = "dotnet_bot.png",
                    Players = new List<Player>
                    {
                        new Player { FullName = "Miguel Torres", JerseyNumber = 9, DNI = "34567890", MobileNumber = "987654324" },
                        new Player { FullName = "Luis Mendoza", JerseyNumber = 5, DNI = "45678901", MobileNumber = "987654325" }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { 
                        FullName = "Ana Rodriguez", 
                        DNI = "56789012", 
                        MobileNumber = "987654326" 
                    }
                },
                 new Team
                {
                    Name = "inmortales fisi",
                    Description = "Equipo de la playa",
                    LogoUrl = "dotnet_bot.png",
                    Players = new List<Player>
                    {
                        new Player { FullName = "Pedro Pascal", JerseyNumber = 9, DNI = "67890123", MobileNumber = "987654327" },
                        new Player { FullName = "Luis Diaz", JerseyNumber = 5, DNI = "78901234", MobileNumber = "987654328" }
                    },
                    TeamDelegate = new Propuesta.Models.Delegate { 
                        FullName = "Jorge Jimenez", 
                        DNI = "89012345", 
                        MobileNumber = "987654329" 
                    }
                }
            };
        }
    }
}
