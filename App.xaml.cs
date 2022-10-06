using Labbet.ViewModel;

namespace Labbet;

public partial class App : Application
{
 
    public App()
    {
        InitializeComponent();
    
        MainPage = new AppShell();
    }
}
