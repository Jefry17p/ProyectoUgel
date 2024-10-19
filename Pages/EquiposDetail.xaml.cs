using AppP1.Class;

namespace AppP1.Pages;

public partial class EquiposDetail : ContentPage
{
    private EquiposCLS _equipoSeleccionado;
	public EquiposDetail(EquiposCLS equipo)
	{
		InitializeComponent();
        _equipoSeleccionado = equipo;

        // Aquí puedes llenar los controles de la página con los datos del equipo
        BindingContext = _equipoSeleccionado;
    }
}