namespace MuhasebeApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            this.UserAppTheme = AppTheme.Light;

        }
    }
}
