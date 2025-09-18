using Propuesta.Models;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public class TeamRegistrationViewModel : ObservableObject
    {
        private string _teamName;
        public string TeamName
        {
            get => _teamName;
            set { _teamName = value; OnPropertyChanged(); }
        }

        private string _teamDescription;
        public string TeamDescription
        {
            get => _teamDescription;
            set { _teamDescription = value; OnPropertyChanged(); }
        }

        private string _logoPath = "dotnet_bot.png"; // Default logo
        public string LogoPath
        {
            get => _logoPath;
            set { _logoPath = value; OnPropertyChanged(); }
        }

        private string _delegateName;
        public string DelegateName
        {
            get => _delegateName;
            set { _delegateName = value; OnPropertyChanged(); }
        }

        private string _delegateDNI;
        public string DelegateDNI
        {
            get => _delegateDNI;
            set { _delegateDNI = value; OnPropertyChanged(); }
        }

        private string _delegateMobile;
        public string DelegateMobile
        {
            get => _delegateMobile;
            set { _delegateMobile = value; OnPropertyChanged(); }
        }

        public ICommand SaveTeamCommand { get; }
        public ICommand SelectLogoCommand { get; }

        public TeamRegistrationViewModel()
        {
            SaveTeamCommand = new Command(async () => await SaveTeam());
            SelectLogoCommand = new Command(async () => await SelectLogo());
        }

        private async Task SaveTeam()
        {
            if (string.IsNullOrWhiteSpace(TeamName) || string.IsNullOrWhiteSpace(DelegateName))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "El nombre del equipo y del delegado son obligatorios.", "OK");
                return;
            }

            // In a real app, you would save this to a database and update the main team list.
            // For this prototype, we'll just show an alert and navigate back.
            await Application.Current.MainPage.DisplayAlert("Éxito", $"Equipo '{TeamName}' guardado correctamente.", "OK");
            await Shell.Current.GoToAsync(".."); // Go back to the previous page
        }

        private async Task SelectLogo()
        {
            // This simulates selecting a file. In a real app, you'd use a file picker.
            await Application.Current.MainPage.DisplayAlert("Simulación", "Aquí se abriría un selector de archivos para elegir el logo del equipo.", "OK");
            // For the prototype, we can pretend a logo was selected.
            LogoPath = "dotnet_bot.png";
        }
    }
}
