using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace T2008M_UWP_Prj.Pages.OrdersRoute
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderDetail : Page
    {
        int id;
        public OrderDetail()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            id = (int) e.Parameter;
            OrderIdTextBlock.Text = id.ToString();
            RenderOrderDetail(id);
        }

        public async void RenderOrderDetail(int id)
        {
            OrderService service = new OrderService();
            OrderItems orderItems = await service.FetchOrderDetail(id);
            if (orderItems != null)
            {
                Cart.ItemsSource = orderItems.items;
                TotalAmount.Text = orderItems.items.Sum(item => item.price).ToString();
            }
        }
    }
    
}
