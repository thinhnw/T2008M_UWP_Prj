using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using Windows.Storage.Streams;
using T2008M_UWP_Prj.Models;
using T2008M_UWP_Prj.Services;
using T2008M_UWP_Prj.Adapters;
using SQLitePCL;
using System.Diagnostics;

namespace T2008M_UWP_Prj.Services
{
    class OrderService
    {
        public async Task<Order> CreateOrder()
        {
            CartService cs = new CartService();
            var items = cs.GetCart();
            // cach 2: items co the truyen trong tham so cuar function
            if (items.Count > 0)
            {
                FoodGroup fg = FoodGroup.GetInstance();
                HttpClient httpClient = new HttpClient();
                Uri uri = new Uri(fg.ApiCreateOrder);
                HttpStringContent content = new HttpStringContent(
                        "{ \"items\": " + JsonConvert.SerializeObject(items) + "}",
                        UnicodeEncoding.Utf8,
                        "application/json"
                );
                Debug.WriteLine(JsonConvert.SerializeObject(items));
                HttpResponseMessage msg = await httpClient.PostAsync(uri, content);
                msg.EnsureSuccessStatusCode();
                var rsBody = await msg.Content.ReadAsStringAsync();
                OrderWrapper orderWrapper = JsonConvert.DeserializeObject<OrderWrapper>(rsBody);
                PersistOrder(orderWrapper.data);
                return orderWrapper.data;
                // sau khi nhan duoc order id -> luu vao 1 table trong SQLite de lam trang danh sach don hang
            }
            return null;
        }

        public async Task<OrderItems> FetchOrderDetail(int id)
        {
            FoodGroup api = FoodGroup.GetInstance();
            HttpClient http = new HttpClient();
            var msg = await http.GetAsync(new Uri(api.OrderDetail(id)));
            msg.EnsureSuccessStatusCode();                        
            var stringContent = await msg.Content.ReadAsStringAsync();
            OrderItemsWrapper wrapper = JsonConvert.DeserializeObject<OrderItemsWrapper>(stringContent);
            return wrapper.data;                        
        }

        public bool PersistOrder(Order order)
        {
            try
            {              
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "insert into CustomerOrder(Id) values(?)";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, order.order_id);
                
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<Order> GetOrderList()
        {
            List<Order> list = new List<Order>();
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "select * from CustomerOrder ORDER BY timestamp DESC";
                var statement = connection.Prepare(sql_txt);
                while (SQLiteResult.ROW == statement.Step())
                {
                    Order item = new Order()
                    {
                        order_id = Convert.ToInt32(statement[0]),
                        timestamp = Convert.ToString(statement[1])
                    };
                    list.Add(item);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return list;
        }
    }
}