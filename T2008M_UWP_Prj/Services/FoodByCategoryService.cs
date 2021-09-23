using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T2008M_UWP_Prj.Models;

namespace T2008M_UWP_Prj.Services
{
    class FoodByCategoryService
    {
        public async Task<FoodByCategory> GetFoodByCategory(int id)
        {
            Adapters.FoodGroup api = Adapters.FoodGroup.GetInstance();
            HttpClient http = new HttpClient();
            var res = await http.GetAsync(api.FoodByCategory(id));            
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var stringContent = await res.Content.ReadAsStringAsync();
                Debug.WriteLine(stringContent);
                FoodByCategoryWrapper foodByCategoryWrapper = JsonConvert.DeserializeObject<FoodByCategoryWrapper>(stringContent);
                return foodByCategoryWrapper.data;
            }
            return null;
        }
    }
}
