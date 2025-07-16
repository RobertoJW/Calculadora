namespace Calculadora
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

            //este método sirve para limitar al usuario cuanto puede enpequeñecer la pestaña de la página principal 
            MainPage.SizeChanged += (s, e) =>
            {
                if (MainPage.Width < 400 || MainPage.Height < 400)
                {
                    MainPage.WidthRequest = Math.Max(MainPage.Width, 400);
                    MainPage.HeightRequest = Math.Max(MainPage.Height, 400);
                }
            }; 
        }
    }
}
