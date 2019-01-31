using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for FinalOrderPage.xaml
    /// </summary>
    public partial class FinalOrderPage : Window
    {
        public List<Order> orderList = new List<Order>();
        Order Order = null;

        public FinalOrderPage(Order order)
        {
            InitializeComponent();
            Order = order;
            total.Content = order.Total;
            technician.Content = order.Technician;
            time.Content = order.Time;
            date.Content = order.Date;
            serviceList.ItemsSource = order.ServiceList;
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            orderList.Add(Order);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
