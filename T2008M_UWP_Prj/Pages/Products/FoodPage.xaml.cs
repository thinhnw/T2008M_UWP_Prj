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
using T2008M_UWP_Prj.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2008M_UWP_Prj.Pages.Products
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FoodPage : Page
    {

        Food FoodDetail;
        public FoodPage()
        {
            this.InitializeComponent();
            QuantityTextBox.Text = "0";
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            FoodDetail = e.Parameter as Food;
            PriceTextBlock.Text = FoodDetail.price + " VND";
            NameTextBlock.Text = FoodDetail.name;
        }

        private void QuantityTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

        private void ReduceQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Int32.Parse(QuantityTextBox.Text);
            if (quantity > 0)
            {                                
                QuantityTextBox.Text = (quantity - 1).ToString();
            }
        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        {
            int quantity = Int32.Parse(QuantityTextBox.Text);
            QuantityTextBox.Text = (quantity + 1).ToString();            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CartService cart = new CartService();
            CartItem item = new CartItem()
            {
                Id = FoodDetail.id,
                Name = FoodDetail.name,
                Image = FoodDetail.image,
                Price = FoodDetail.price,
                Qty = Int32.Parse(QuantityTextBox.Text),
            };
            cart.AddToCart(item);
            QuantityTextBox.Text = "0";

            //var list = cart.GetCart();

        }
    }
}
