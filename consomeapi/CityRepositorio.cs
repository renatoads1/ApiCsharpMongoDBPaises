using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace consomeapi
{
    class CityRepositorio
    {
        HttpClient cityz = new HttpClient();

        public CityRepositorio()
        {
            cityz.BaseAddress = new Uri("http://battuta.medunes.net/api/");
            cityz.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<City>> GetRegiaoAsync(string code,string region)
        {
        
            HttpResponseMessage response = await cityz.GetAsync($"http://battuta.medunes.net/api/city/{code}/search/?region={region}&key=1296b8ffbe8c01ed6b5de9bb7f431ed2");
            //HttpResponseMessage response = await cityz.GetAsync($"region/{code}/all/?key=1296b8ffbe8c01ed6b5de9bb7f431ed2");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(data);
            }
            return new List<City>();
        }
    }
}
