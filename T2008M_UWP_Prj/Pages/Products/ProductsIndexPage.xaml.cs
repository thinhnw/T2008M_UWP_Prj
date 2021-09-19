using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using T2008M_UWP_Prj.Models;
using Windows.UI.Xaml.Media.Imaging;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2008M_UWP_Prj.Pages.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ProductsIndexPage : Page
    {
        List<Product> Products;
        public ProductsIndexPage()
        {
            this.InitializeComponent();
            Products = new List<Product>();
            Debug.WriteLine(BaseUri);
            Products.Add(new Product { 
                Name = "Burger",
                Slug="burger", 
                Price = 13, 
                ShortDescription = "This is a burger",
                FullDescription = "Delicious burger",
                Img = new BitmapImage(new Uri("ms-appx:///Assets/burger-2.jpg"))
            });
            Products.Add(new Product
            {
                Name = "Cake",
                Slug = "cake",
                Price = 13,
                ShortDescription = "This is a cake",
                FullDescription = "Delicious cake",
                Img = new BitmapImage(new Uri("ms-appx:///Assets/cake.jfif"))
            });
            Products.Add(new Product
            {
                Name = "Pizza",
                Slug = "pizza",
                Price = 13,
                ShortDescription = "This is a burger",
                FullDescription = "Delicious pizza",
                Img = new BitmapImage(new Uri("ms-appx:///Assets/pizza.jpg"))
            });
        }
    }
}
