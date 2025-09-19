using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaPartidos : ContentPage
{
	public PaginaPartidos()
	{
		InitializeComponent();
		BindingContext = new PaginaPartidosViewModel();
	}
}
