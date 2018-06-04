using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace Kochbuch
{
    class OnlineDb : IRezeptDb
    {
        private static OnlineDb instance;
        private HttpClient client;
        public Task<RezeptModel> GetRezeptAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task<RezeptModel> GetRezeptAsync(string Titel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RezeptModel>> GetRezeptModelsAsync()
        {
            List<RezeptModel> rezepte = new List<RezeptModel>();
            client = new HttpClient();
            var response = await client.GetAsync("http://kochbuchapi20180530122617.azurewebsites.net/api/Rezept");
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                rezepte = JsonConvert.DeserializeObject<List<RezeptModel>>(json);
            }
            return rezepte;
        }

        public async Task<bool> SaveRezeptAsync(RezeptModel rezept)
        {
            client = new HttpClient();

            var response = await client.PostAsync("http://kochbuchapi20180530122617.azurewebsites.net/api/Rezept", new StringContent(JsonConvert.SerializeObject(rezept), Encoding.UTF8, "application/json"));
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public Task<bool> SaveRezepteAsync(List<RezeptModel> rezepte)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteRezeptAsync(string titel)
        {
            client = new HttpClient();
            var response  = await client.DeleteAsync("http://kochbuchapi20180530122617.azurewebsites.net/api/Rezept/"+titel);
        }
        public static OnlineDb getInstance()
        {
            if(instance == null)
            {
                instance = new OnlineDb();
            }
            return instance;
        }
    }
}
