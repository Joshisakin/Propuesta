using Propuesta.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Propuesta.ViewModels
{
    public partial class PaginaClasificacionViewModel : ObservableObject
    {
        public ObservableCollection<Team> Standings { get; }

        public PaginaClasificacionViewModel()
        {
            Standings = new ObservableCollection<Team>(GetMockStandings());
        }

        private List<Team> GetMockStandings()
        {
            
            var teams = new PaginaEquiposViewModel().Teams;

            teams[0].MatchesPlayed = 2;
            teams[0].Wins = 1;
            teams[0].Draws = 1;
            teams[0].Losses = 0;
            teams[0].Points = 4;
            teams[0].GoalsFor = 5;
            teams[0].GoalsAgainst = 3;

            teams[1].MatchesPlayed = 1;
            teams[1].Wins = 0;
            teams[1].Draws = 0;
            teams[1].Losses = 1;
            teams[1].Points = 0;
            teams[1].GoalsFor = 2;
            teams[1].GoalsAgainst = 4;

            teams[2].MatchesPlayed = 1;
            teams[2].Wins = 0;
            teams[2].Draws = 1;
            teams[2].Losses = 0;
            teams[2].Points = 1;
            teams[2].GoalsFor = 1;
            teams[2].GoalsAgainst = 1;

            
            return teams.OrderByDescending(t => t.Points).ThenByDescending(t => t.GoalDifference).ToList();
        }
    }
}
