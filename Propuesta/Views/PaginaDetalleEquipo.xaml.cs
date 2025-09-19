using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaDetalleEquipo : ContentPage
{
	public PaginaDetalleEquipo()
	{
		InitializeComponent();
		BindingContext = new PaginaDetalleEquipoViewModel();
	}
}
