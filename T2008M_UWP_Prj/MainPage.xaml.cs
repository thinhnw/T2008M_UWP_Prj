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
using T2008M_UWP_Prj.Pages;
using System.Diagnostics;
using System.Collections;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T2008M_UWP_Prj
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static Frame MainFrame;
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Pages.Home.HomePage));
            MainFrame = MyFrame;
            MySplitView.IsPaneOpen = true;

            Adapters.SQLiteHelper db = Adapters.SQLiteHelper.GetInstance();

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Type> pages = new List<Type>();
            pages.Add(typeof(Pages.Home.HomePage));
            pages.Add(typeof(Pages.Products.ProductsIndexPage));
            pages.Add(typeof(Pages.ShoppingCart.ShoppingCart));

            MainFrame.Navigate(pages[Menu.SelectedIndex]);
        }

        private void Menu_Loaded(object sender, RoutedEventArgs e)
        {
            Menu.Items.Add(new MenuItem() { Name = "Home", MenuPage = "home", Icon = "\uEC19", ComponentName = "HomeItem" });
            Menu.Items.Add(new MenuItem() { Name = "Eat-In", MenuPage = "eat-in", Icon = "\uED56", ComponentName = "EatInItem" });
            Menu.Items.Add(new MenuItem() { Name = "Shopping Cart", MenuPage = "cart", Icon = "\ue7bf", ComponentName = "CollectionItem" });
            //Menu.Items.Add(new MenuItem() { Name = "Delivery", MenuPage = "delivery", Icon = "\uED57 ", ComponentName = "DeliveryItem" });
            //Menu.Items.Add(new MenuItem() { Name = "Take Away", MenuPage = "take-away", Icon = "\uED56 ", ComponentName = "TakeAwayItem" });
            //Menu.Items.Add(new MenuItem() { Name = "Driver Payment", MenuPage = "driver-payment", Icon = "\uE9A6 ", ComponentName = "DriverPaymentItem" });
            //Menu.Items.Add(new MenuItem() { Name = "Customers", MenuPage = "customers", Icon = "\uE77B ", ComponentName = "CustomersItem" });
            
            Menu.SelectedIndex = 0;
        }
     
    }
}
