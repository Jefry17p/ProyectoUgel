using AppP1.Class;
using AppP1.ServicesApi;
namespace AppP1.Pages;

public partial class MenuPage : ContentPage
{
    public List<menuCLS> listaMenu { get; set; }
    public menuCLS omenuCLS { get; set; }

    public MenuPage()
    {
        InitializeComponent();
        listaMenu = new List<menuCLS>()
        {
            new menuCLS() { codMenu = 1, nomMenu = "Equipos", imgMenu = "iclist.png" },
            new menuCLS() { codMenu = 2, nomMenu = "Mantenimientos", imgMenu = "icsettings.png" },
            new menuCLS() { codMenu = 3, nomMenu = "Pendientes", imgMenu = "icnoti.png" },
            new menuCLS() { codMenu = 4, nomMenu = "Historial", imgMenu = "ichistory.png" }
        };
        BindingContext = this;
    }

    private void lstMenu_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item == null) return;

        // Asegúrate de que omenuCLS esté correctamente asignado al elemento seleccionado
        omenuCLS = e.Item as menuCLS;

        // Asegúrate de que omenuCLS no sea nulo antes de acceder a su propiedad
        if (omenuCLS == null) return;

        Page nexPage = null;


        switch (omenuCLS.codMenu)
        {
            case 1:
                nexPage = new EquipmentPage();  // Pasar la instancia a Equipos
                break;
            case 2:
                nexPage = new MaintenancePage();
                break;
            case 3:
                nexPage = new EarringsPage();
                break;
            case 4:
                nexPage = new HistoryPage();
                break;
        }

        if (nexPage != null)
        {
            App.Navigate.PushAsync(nexPage);
        }
        App.menu.IsPresented = false;
    }
}
