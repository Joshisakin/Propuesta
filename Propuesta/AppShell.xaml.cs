using Propuesta.Views;

namespace Propuesta;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PaginaDetalleEquipo), typeof(PaginaDetalleEquipo));
		Routing.RegisterRoute(nameof(PaginaRegistroEquipo), typeof(PaginaRegistroEquipo));
		Routing.RegisterRoute(nameof(PaginaPago), typeof(PaginaPago));
        Routing.RegisterRoute(nameof(PaginaPartidos), typeof(PaginaPartidos));
        Routing.RegisterRoute(nameof(PaginaClasificacion), typeof(PaginaClasificacion));
        Routing.RegisterRoute(nameof(PaginaEquipos), typeof(PaginaEquipos));
	}
}
