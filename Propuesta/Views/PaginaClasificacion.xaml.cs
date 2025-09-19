using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaClasificacion : ContentPage
{
	public PaginaClasificacion()
	{
		InitializeComponent();
		BindingContext = new PaginaClasificacionViewModel();
	}
}
