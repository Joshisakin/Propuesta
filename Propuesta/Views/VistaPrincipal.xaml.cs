using Propuesta.ViewModels;

namespace Propuesta.Views;

public partial class DashboardView : ContentPage
{
	public DashboardView()
	{
		InitializeComponent();
		BindingContext = new DashboardViewModel();
	}
}
