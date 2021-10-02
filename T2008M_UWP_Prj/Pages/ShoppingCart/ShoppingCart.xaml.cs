using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using T2008M_UWP_Prj.Models;
using T2008M_UWP_Prj.Services;
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
        CartService service;
        public ShoppingCart()
        {
            this.InitializeComponent();
           
            //var list = car
        }

        private void ReduceQuantityButton_Click(object sender, RoutedEventArgs e)
        {          
            int id = (int)((Button) sender).Tag;
            int qty = service.ItemCount(id);
            service.UpdateItem(id, qty - 1);
            RenderCart();
        }

        private void QuantityTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c)) || args.NewText.Length == 0;
          
        }

        private void IncreaseQuantityButton_Click(object sender, RoutedEventArgs e)
        { 
            int id = (int)((Button)sender).Tag;
            int qty = service.ItemCount(id);
            service.UpdateItem(id, qty + 1);
            RenderCart();
        }

        public void RenderCart()
        {            
            service = new CartService();

            List<CartItem> cart = service.GetCart();
            Cart.Items.Clear();
            if (cart != null)
            {
                foreach (CartItem item in cart)
                {
                    Cart.Items.Add(item);
                }
            }

            TotalAmount.Text = service.GetTotalAmount().ToString();            
        }

        private void FoodList_Loaded(object sender, RoutedEventArgs e)
        {
            RenderCart();
        }

        private void QuantityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int id = (int) ((TextBox) sender).Tag;
            service.UpdateItem(id, Int32.Parse(((TextBox) sender).Text));
            RenderCart();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)((Button)sender).Tag;
            service.RemoveItem(id);
            RenderCart();
        }
    }
}
