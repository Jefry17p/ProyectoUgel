using AppP1.Pages;

namespace AppP1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            App.Current.MainPage = new Home();
        }

        public static NavigationPage Navigate { get; internal set; }
        public static PrincipalPage menu { get; internal set; }
    }
}
