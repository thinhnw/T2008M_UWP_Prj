using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2008M_UWP_Prj.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2008M_UWP_Prj.Pages.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoodByCategoryPage : Page
    {
        int ctgId;
        public FoodByCategoryPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Models.View.Category ctg = e.Parameter as Models.View.Category;
            ctgId = ctg.Id;
            Title.Text = ctg.Name;
            Debug.WriteLine("ctg id 1st " + ctgId);
        }

        public async void RenderFoodByCategory()
        {
            Services.FoodByCategoryService service = new Services.FoodByCategoryService();
            Debug.WriteLine("ctg id 2nd " + ctgId);
            FoodByCategory foodByCategory = await service.GetFoodByCategory(ctgId);
            if (foodByCategory != null)
            {
                foreach (Food food in foodByCategory.foods)
                {
                    Debug.WriteLine(food.name);
                    FoodList.Items.Add(new Models.View.Food
                    {
                        Name = food.name,
                        Id = food.id,
                        Img = new BitmapImage(new Uri(food.image)),
                        Price = food.price
                    });
                }
            }
        }
       
        private void FoodList_Loaded(object sender, RoutedEventArgs e)
        {
            RenderFoodByCategory();
        }

        private void StackPanel_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Models.View.Food selectedItem = (Models.View.Food) FoodList.SelectedItem;
            Debug.WriteLine(selectedItem.Name);
            MainPage.MainFrame.Navigate(typeof(Pages.Products.FoodPage), selectedItem);
        }
    }
}
