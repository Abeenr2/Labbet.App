using Labbet.Model;
using Newtonsoft.Json;
using Labbet.ViewModel;

namespace Labbet;

public partial class MainPage : ContentPage
{
  
    public MainPage(FilmViewModel filmViewModel)
    {
      
        InitializeComponent();
        BindingContext = filmViewModel;
    }
    
}

