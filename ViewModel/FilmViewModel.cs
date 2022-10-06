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

namespace Labbet.ViewModel
{
    public partial class FilmViewModel : BasViewModel
    {

        FilmerServices filmerServices;
        public ObservableCollection<Film> film { get; } = new();

        public FilmViewModel(FilmerServices filmerServices)
        {
            Title = "Alla filmer kommer ligga här";
            this.filmerServices = filmerServices;
        }
        [RelayCommand]
        async Task GetFilmerAsync()
        {
            if (IsBusy)
            {
                return;
            }
            try
            {
                IsBusy = true;
                var film = await filmerServices.GetFilmer();
                if (film.Count != 0) // om listan inte har 0 memes
                {
                    film.Clear(); // rensa listan
                }
                foreach (var meme in film)  // för varje meme i memes listan
                {
                    film.Add(meme); // lägg till memes
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error", $"Cannot bring the movies out: {ex.Message}", "Ok");

            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
