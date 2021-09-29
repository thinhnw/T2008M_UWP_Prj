using System;
using System.Collections.Generic;
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

namespace T2008M_UWP_Prj.Pages.ShoppingCart
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ShoppingCart : Page
    {
        int ctgId = 1;
        public ShoppingCart()
        {
            this.InitializeComponent();           
        }

        private void ReduceQuantityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuantityTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {

        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public async void RenderFoodByCategory()
        {
            Services.FoodByCategoryService service = new Services.FoodByCategoryService();
            
            FoodByCategory foodByCategory = await service.GetFoodByCategory(ctgId);
            if (foodByCategory != null)
            {
                foreach (Food food in foodByCategory.foods)
                {                    
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
      
    }
}
