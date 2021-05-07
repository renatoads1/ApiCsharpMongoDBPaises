using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace consomeapi
{
    class RegiaoRepositorio
    {
        HttpClient regiaoz = new HttpClient();

        public RegiaoRepositorio()
        {
            regiaoz.BaseAddress = new Uri("http://battuta.medunes.net/api/");
            regiaoz.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Regiao>> GetRegiaoAsync(string code)
        {
            HttpResponseMessage response = await regiaoz.GetAsync($"region/{code}/all/?key=1296b8ffbe8c01ed6b5de9bb7f431ed2");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Regiao>>(data);
            }
            return new List<Regiao>();
        }
    }
}
