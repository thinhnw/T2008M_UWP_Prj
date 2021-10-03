using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2008M_UWP_Prj.Adapters
{
    class FoodGroup
    {
        private readonly string baseURL = "http://foodgroup.herokuapp.com/api";
        // singleton pattern
        private static FoodGroup instance;

        private FoodGroup()
        {

        }

        public static FoodGroup GetInstance()
        {
            if (instance == null)
            {
                instance = new FoodGroup();
            }
            return instance;
        }

        // api list categories
        public string TodaySpecial
        {
            get => String.Format(baseURL + "/today-special");
        }

        public string Category
        {
            get => String.Format(baseURL + "/menu");
        }

        public string FoodByCategory(int id)
        {
            return String.Format(baseURL + "/category/" + id);
        }

        public string Food(int id)
        {
            return String.Format(baseURL + "/food/" + id);
        }

        public string ApiCreateOrder
        {
            get => String.Format(baseURL + "/create-order");
        }
        public string OrderDetail(int id)
        {
            return String.Format(baseURL + "/order/" + id);
        }
    }
}
