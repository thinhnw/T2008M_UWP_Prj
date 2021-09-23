using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace T2008M_UWP_Prj.Services
{
    class CategoryService
    {
        public async Task<Models.Categories> GetMenu()
        {
            Adapters.FoodGroup api = Adapters.FoodGroup.GetInstance();
            HttpClient hc = new HttpClient(); // shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(api.Category);// get_file_content -> thao tác trả hàng của shipper
            Debug.WriteLine("code " + rs.StatusCode);
            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.Categories categories = JsonConvert.DeserializeObject<Models.Categories>(stringContent);// convert string json thành 1 object DTO (Categories)
                return categories;
            }
            return null;
        }
    }
}
