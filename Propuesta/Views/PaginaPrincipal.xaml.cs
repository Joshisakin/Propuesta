using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaPrincipal : ContentPage
{
	public PaginaPrincipal()
	{
		InitializeComponent();
		BindingContext = new PaginaPrincipalViewModel();
	}
}
