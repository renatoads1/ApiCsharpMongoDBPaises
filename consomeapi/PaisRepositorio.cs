using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace consomeapi
{
    class PaisRepositorio
    {
        HttpClient paisz = new HttpClient();

        public PaisRepositorio()
        {
            paisz.BaseAddress = new Uri("http://battuta.medunes.net/api/");
            paisz.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); 
        }

        public async Task<List<Pais>> GetPaisAsync() {

            HttpResponseMessage response = await paisz.GetAsync("country/all/?key=1296b8ffbe8c01ed6b5de9bb7f431ed2");
            if (response.IsSuccessStatusCode)
            {
                var dados = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Pais>>(dados);
            }

            return new List<Pais>();
        }

    }
}
