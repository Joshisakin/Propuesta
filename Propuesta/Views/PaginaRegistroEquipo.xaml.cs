using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaRegistroEquipo : ContentPage
{
	public PaginaRegistroEquipo()
	{
		InitializeComponent();
		BindingContext = new PaginaRegistroEquipoViewModel();
	}
}
