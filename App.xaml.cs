using Labbet.ViewModel;

namespace Labbet;

public partial class App : Application
{
    public static FilmViewModel Film { get; set; } = new FilmViewModel();
    public App()
    {
        InitializeComponent();
        App.Film.LoadFilm();//Initilalise with data
        MainPage = new AppShell();
    }
}
