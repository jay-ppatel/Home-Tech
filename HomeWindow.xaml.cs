using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        ObservableCollection<Order> OrderCollection { get; set; } = new ObservableCollection<Order>();
        UserAccount User = null;

        public HomeWindow(UserAccount user)
        {
            InitializeComponent();
            User = user;
            try
            {
                ReadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to read csv file\nInner Exception:{ex.InnerException.Message}");
            }

            DisplayList();
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

        public void DisplayList()
        {
            if (UpcomingOrder().Count > 0)
            {
                Upcoming.ItemsSource = UpcomingOrder();
            }
            else
            {
                Upcoming.ItemsSource = new List<string> { "No Events To Show" };
            }

        }

        public List<string> UpcomingOrder()
        {
            List<string> upcomingList = new List<string>();
            string name = User.FirstName + " " + User.LastName;
            if (OrderCollection.Count > 0)
            {
                foreach (Order order in OrderCollection)
                {
                    if ((order.CustomerName == (name)) && (!CompareDate(order.Date)))
                    {
                        upcomingList.Add(order.ToString());
                    }
                }
            }

            return upcomingList;
        }

        private bool CompareDate(string date)
        {

            var newDate = DateTime.ParseExact(date, "MM/dd/yyyy", null, DateTimeStyles.None);
            return (newDate < DateTime.Now);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow(User);
            mw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
