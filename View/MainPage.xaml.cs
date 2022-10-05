using Labbet.Model;
using Newtonsoft.Json;

namespace Labbet;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        this.BackgroundImageSource = "https://wallpaperaccess.com/full/859076.jpg";
        InitializeComponent();
        InitData();


    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        InitData();
    }
    public async Task InitData()
    {
        try
        {
            //10.0.2.2 for Android, localhost for windows
            string apiURL = @"http://www.omdbapi.com/?i=tt3896198&apikey=d6b7a744"; 
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                content = content.Replace("<P>", "");

                //List<Datum> serviceResponse = JsonConvert.DeserializeObject<List<Datum>>(content);
                List<Film> serviceResponse = JsonConvert.DeserializeObject<List<Film>>(content);
                lstFilm.ItemsSource = serviceResponse;
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available", "OK");
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available.(" + ex.Message + ")", "OK");
        }
    }
}

