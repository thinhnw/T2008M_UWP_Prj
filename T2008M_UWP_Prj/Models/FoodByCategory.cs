using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2008M_UWP_Prj.Models
{       

    public class FoodByCategory
    {
        public Category category { get; set; }
        public List<Food> foods { get; set; }
    }

    public class FoodByCategoryWrapper
    {
        public string message { get; set; }
        public FoodByCategory data { get; set; }
    }

}
