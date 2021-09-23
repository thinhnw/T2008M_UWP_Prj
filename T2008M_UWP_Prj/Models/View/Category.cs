using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;

namespace T2008M_UWP_Prj.Models.View
{
    class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public BitmapImage Img { get; set; }
    }
}
