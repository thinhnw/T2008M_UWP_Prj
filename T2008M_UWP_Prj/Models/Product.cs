using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace T2008M_UWP_Prj.Models
{
    class Product
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public decimal Price { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public BitmapImage Img { get; set; }
        
    }
}
