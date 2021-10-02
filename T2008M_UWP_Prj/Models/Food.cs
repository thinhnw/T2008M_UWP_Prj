using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace T2008M_UWP_Prj.Models
{    
    public class Food
    {
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public int price { get; set; }

        public BitmapImage bImage
        {
            get => new BitmapImage(new Uri(image));
        }
    }

    public class FoodDataWrapper
    {
        public string message { get; set; }
        public Food data { get; set; }
    }


}
