using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class PaginaPago : ContentPage
{
	public PaginaPago()
	{
		InitializeComponent();
		BindingContext = new PaginaPagoViewModel();
	}
}
