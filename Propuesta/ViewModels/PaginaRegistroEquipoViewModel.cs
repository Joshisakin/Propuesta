using Propuesta.Models;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public partial class PaginaRegistroEquipoViewModel : ObservableObject
    {
        private string _teamName = string.Empty;
        public string TeamName
        {
            get => _teamName;
            set { _teamName = value; OnPropertyChanged(); }
        }

        private string _teamDescription = string.Empty;
        public string TeamDescription
        {
            get => _teamDescription;
            set { _teamDescription = value; OnPropertyChanged(); }
        }

        private string _logoPath = "dotnet_bot.png";
        public string LogoPath
        {
            get => _logoPath;
            set { _logoPath = value; OnPropertyChanged(); }
        }

        private string _delegateName = string.Empty;
        public string DelegateName
        {
            get => _delegateName;
            set { _delegateName = value; OnPropertyChanged(); }
        }

        private string _delegateDNI = string.Empty;
        public string DelegateDNI
        {
            get => _delegateDNI;
            set { _delegateDNI = value; OnPropertyChanged(); }
        }

        private string _delegateMobile = string.Empty;
        public string DelegateMobile
        {
            get => _delegateMobile;
            set { _delegateMobile = value; OnPropertyChanged(); }
        }

        public ICommand SaveTeamCommand { get; }
        public ICommand SelectLogoCommand { get; }

        public PaginaRegistroEquipoViewModel()
        {
            SaveTeamCommand = new Command(async () => await SaveTeam());
            SelectLogoCommand = new Command(async () => await SelectLogo());
        }

        private async Task SaveTeam()
        {
            if (string.IsNullOrWhiteSpace(TeamName) || string.IsNullOrWhiteSpace(DelegateName))
            {
                var window = Application.Current?.Windows?.FirstOrDefault();
                if (window?.Page is not null)
                {
                    await window.Page.DisplayAlert("Error", "El nombre del equipo y del delegado son obligatorios.", "OK");
                }
                return;
            }

            var mainWindow = Application.Current?.Windows?.FirstOrDefault();
            if (mainWindow?.Page is not null)
            {
                await mainWindow.Page.DisplayAlert("Éxito", $"Equipo '{TeamName}' guardado correctamente.", "OK");
                await Shell.Current.GoToAsync(".."); 
            }
        }

        private async Task SelectLogo()
        {
           
            var window = Application.Current?.Windows?.FirstOrDefault();
            if (window?.Page is not null)
            {
                await window.Page.DisplayAlert("Simulación", "Aquí se abriría un selector de archivos para elegir el logo del equipo.", "OK");
                
                LogoPath = "dotnet_bot.png";
            }
        }
    }
}
