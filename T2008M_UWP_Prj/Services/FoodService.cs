using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T2008M_UWP_Prj.Models;


namespace T2008M_UWP_Prj.Services
{
    class FoodService
    {
        public async Task<Food> GetFood()
        {
            Adapters.FoodGroup api = Adapters.FoodGroup.GetInstance();
            HttpClient http = new HttpClient();
            var res = await http.GetAsync(api.Food(1));
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stringContent = await res.Content.ReadAsStringAsync();
                FoodDataWrapper foodDataWrapper = JsonConvert.DeserializeObject<FoodDataWrapper>(stringContent);
                return foodDataWrapper.data;
            }
            return null;
        }
    }
}
