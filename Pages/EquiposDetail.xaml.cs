using AppP1.Class;

namespace AppP1.Pages;

public partial class EquiposDetail : ContentPage
{
    private EquiposCLS _equipoSeleccionado;
	public EquiposDetail(EquiposCLS equipo)
	{
		InitializeComponent();
        _equipoSeleccionado = equipo;

        // Aqu� puedes llenar los controles de la p�gina con los datos del equipo
        BindingContext = _equipoSeleccionado;
    }
}