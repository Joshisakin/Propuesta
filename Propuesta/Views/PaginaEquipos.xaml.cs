using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaEquipos : ContentPage
{
	public PaginaEquipos()
	{
		InitializeComponent();
		BindingContext = new PaginaEquiposViewModel();
	}
}
