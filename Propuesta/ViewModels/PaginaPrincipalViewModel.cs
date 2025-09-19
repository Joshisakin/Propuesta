using Propuesta.Models;
using Propuesta.Views;
using System.Windows.Input;

namespace Propuesta.ViewModels
{
    public partial class PaginaPrincipalViewModel : ObservableObject
    {
        public ICommand IrAEquiposCommand { get; }
        public ICommand IrAPartidosCommand { get; }
        public ICommand IrAClasificacionCommand { get; }
        public ICommand IrARegistrarPagoCommand { get; }

        public PaginaPrincipalViewModel()
        {
            IrAEquiposCommand = new Command(async () => await IrAEquipos());
            IrAPartidosCommand = new Command(async () => await IrAPartidos());
            IrAClasificacionCommand = new Command(async () => await IrAClasificacion());
            IrARegistrarPagoCommand = new Command(async () => await IrARegistrarPago());
        }

        private async Task IrAEquipos()
        {
            await Shell.Current.GoToAsync(nameof(PaginaEquipos));
        }

        private async Task IrAPartidos()
        {
            await Shell.Current.GoToAsync(nameof(PaginaPartidos));
        }

        private async Task IrAClasificacion()
        {
            await Shell.Current.GoToAsync(nameof(PaginaClasificacion));
        }

        private async Task IrARegistrarPago()
        {
            await Shell.Current.GoToAsync(nameof(PaginaPago));
        }


    }
}
