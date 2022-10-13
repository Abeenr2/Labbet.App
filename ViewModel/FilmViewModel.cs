using Labbet.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labbet.ViewModel;
using Labbet.Services;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Labbet.ViewModel
{
    public partial class FilmViewModel : INotifyPropertyChanged //: BasViewModel
    {
       //[ObservableProperty]
        //private Film? film;
        private Film _film = new Film { Title= "Hej", Year = "1998" };

        public Film FilmWS
        {
            get { return _film; }
            set {
                _film = value;
                OnPropertyChanged(); // reports this property
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        FilmerServices filmerServices;

        public event PropertyChangedEventHandler PropertyChanged;

        public FilmViewModel(FilmerServices filmerServices)
        {
            
            this.filmerServices = filmerServices;

        }


        [RelayCommand]
        async Task GetFilmAsync()
        {
           this.FilmWS = await filmerServices.GetFilm();



        }

    }
}
