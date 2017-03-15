using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cat.Models
{
     public class Repositorio
    {

        public async Task<List<Cats>> GetCats()
        {
            List<Cats> Cat;
            var URLWebAPI = "http://demos.ticapacitacion.com/cats";
            using (var Client = new System.Net.Http.HttpClient())
            {
                var JSON = await Client.GetStringAsync(URLWebAPI);
                Cat = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Cats>>(JSON);
            }
            return Cat;
        }
    }
}
