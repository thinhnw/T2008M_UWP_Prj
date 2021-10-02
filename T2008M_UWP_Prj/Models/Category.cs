using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace T2008M_UWP_Prj.Models
{
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string icon { get; set; }
        public BitmapImage bImage
        {
            get => new BitmapImage(new Uri(icon));
        }
    }

    public class Categories  // Data transfer object
    {
        public string message { get; set; }
        public List<Category> data { get; set; }
    }
}
