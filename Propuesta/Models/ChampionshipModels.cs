
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Propuesta.Models
{
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Championship : ObservableObject
    {
        public required string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Team> Teams { get; set; } = new();
        public List<Group> Groups { get; set; } = new();
    }

    public class Team : ObservableObject
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        public List<Player> Players { get; set; } = new();
        public required Delegate TeamDelegate { get; set; }
        public int Points { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
    }

    public class Player : ObservableObject
    {
        public required string DNI { get; set; }
        public required string FullName { get; set; }
        public required string MobileNumber { get; set; }
        public int JerseyNumber { get; set; }
    }

    public class Delegate : ObservableObject
    {
        public required string DNI { get; set; }
        public required string FullName { get; set; }
        public required string MobileNumber { get; set; }
    }

    public class Group : ObservableObject
    {
        public required string GroupName { get; set; }
        public List<Team> Teams { get; set; } = new();
        public List<Match> Matches { get; set; } = new();
    }

    public class Match : ObservableObject
    {
        public required Team HomeTeam { get; set; }
        public required Team AwayTeam { get; set; }
        public DateTime MatchDateTime { get; set; }
        public required string Venue { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public bool IsResultConfirmed { get; set; }
        public List<Goal> Goals { get; set; } = new();
        public List<Card> Cards { get; set; } = new();
    }

    public class Goal
    {
        public required Player Scorer { get; set; }
        public int Minute { get; set; }
    }

    public enum CardType { Yellow, Red }

    public class Card
    {
        public required Player Player { get; set; }
        public CardType CardType { get; set; }
        public int Minute { get; set; }
    }

    public enum PaymentMethod
    {
        Efectivo,
        Yape,
        Plin,
        TarjetaCredito,
        TarjetaDebito
    }

    public class RegistrationPayment : ObservableObject
    {
        public required Team Team { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod Method { get; set; }
        public bool IsVerified { get; set; }
    }
}
