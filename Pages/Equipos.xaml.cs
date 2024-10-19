using AppP1.Class;
using AppP1.ServicesApi;

namespace AppP1.Pages;

public partial class Equipos : ContentPage
{
    private readonly ApiEquipos _apiEquipos;

    public Equipos(ApiEquipos apiEquipos)
    {
        InitializeComponent();
        _apiEquipos = apiEquipos;  // Usar la instancia inyectada
        CargarEquipos();
    }

    private async void CargarEquipos()
    {
        try
        {
            var equiposResponse = await _apiEquipos.ObtenerEquiposAsync();
            if (equiposResponse.Success)
            {
                ListaEquipo.ItemsSource = equiposResponse.Data;
            }
            else
            {
                await DisplayAlert("Error", equiposResponse.Message, "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudieron cargar los equipos: " + ex.Message, "OK");
        }
    }


    private void AgregarEquipo_Clicked(object sender, EventArgs e)
    {
        // Lógica para agregar un nuevo equipo
    }

    private async void ListaEquipos_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item != null)
        {
            var equipoSeleccionado = e.Item as EquiposCLS;
            await Navigation.PushAsync(new EquiposDetail(equipoSeleccionado));
        }
    }
}
