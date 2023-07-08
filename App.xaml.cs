namespace AR_JC_ProyectoP2
{
    public partial class App : Application
    {
        public static LogRepository LogRepo { get; private set; }

        public App(LogRepository repo)
        {
            InitializeComponent();

            MainPage = new AppShell();

            LogRepo = repo;
        }
    }
}
