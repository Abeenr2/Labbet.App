using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Labbet.Model;
using Newtonsoft.Json;
using System.Net.Http;

namespace Labbet.Services
{
    public class FilmerServices
    {
        HttpClient httpClient;
        public FilmerServices()
        {
            httpClient = new HttpClient();
        }



        public async Task<Film> GetFilm()
        {
            var url = "http://www.omdbapi.com/?i=tt3896198&apikey=d6b7a744";
            var response = await httpClient.GetAsync(url);
            Film resultFilm = new Film();

            if (response.IsSuccessStatusCode) 
            {
                resultFilm = await response.Content.ReadFromJsonAsync<Film>();
            }
            return resultFilm;
        }

        //List<Film> filmList = new();
        //public async Task<List<Film>> GetFilmer()
        //{
        //    if (filmList?.Count > 0)
        //    {
        //        return filmList;
        //    }
        //    var url = "http://www.omdbapi.com/?i=tt3896198&apikey=d6b7a744";
        //    var response = await httpClient.GetAsync(url);

        //    if (response.IsSuccessStatusCode) 
        //    {
        //        filmList = await response.Content.ReadFromJsonAsync<List<Film>>();
        //    }
        //    return filmList;
        //}
   
    }

}
