using AppP1.Class;

namespace AppP1.Pages;

public partial class PrincipalPage : FlyoutPage
{
	
	
	public PrincipalPage()
    {
		InitializeComponent();
        App.Navigate = Navigate;
        App.menu = this;
    }
}