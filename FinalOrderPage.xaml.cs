using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for FinalOrderPage.xaml
    /// </summary>
    public partial class FinalOrderPage : Window
    {
        ObservableCollection<Order> OrderCollection { get; set; } = new ObservableCollection<Order>();
        Order Order { get; set; }
        UserAccount User = null;
        public FinalOrderPage(Order order, UserAccount user)
        {
            InitializeComponent();
            Order = order;
            User = user;
            total.Content = order.Total;
            technician.Content = order.Technician.Name;
            time.Content = order.Time;
            date.Content = order.Date;
            serviceList.ItemsSource = order.ServiceList;

            try
            {
                ReadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to read csv file\nInner Exception:{ex.InnerException.Message}");
            }
        }
  
        private void ReadOrders()
        {
            string path = "Orders.xml";
            XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Order>));

            if (File.Exists(path))
            {
                using (FileStream rs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    OrderCollection = xmler.Deserialize(rs) as ObservableCollection<Order>;
                }
            }
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {

            string path = "Orders.xml";
            XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Order>));

            OrderCollection.Add(Order);

            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                xmler.Serialize(fs, OrderCollection);
            }
            this.Close();

            ConfirmationPage confirmation = new ConfirmationPage(Order, User);
            confirmation.ShowDialog();
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
