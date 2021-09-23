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
        public ProductsIndexPage()
        {
            this.InitializeComponent();            
            
        }

        public async void RenderCategories()
        {
            Services.CategoryService service = new Services.CategoryService();
            Categories categories = await service.GetMenu();
            if (categories != null)
            {
                foreach (Category ctg in categories.data)
                {
                    Debug.WriteLine(ctg.name);
                    CategoryList.Items.Add(new Models.View.Category
                    {
                        Name = ctg.name,
                        Id = ctg.id,
                        Img = new BitmapImage(new Uri(ctg.icon))
                    });                    
                }
            }
        }

        private void CategoryList_Loaded(object sender, RoutedEventArgs e)
        {
            RenderCategories();
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            
            Models.View.Category selectedItem = (Models.View.Category) CategoryList.SelectedItem;
            Debug.WriteLine(selectedItem.Name);
            MainPage.MainFrame.Navigate(typeof(Pages.Products.FoodByCategoryPage), selectedItem);            
        }
    }
}
