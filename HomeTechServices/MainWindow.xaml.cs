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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
         UserAccount CurrentUser { get; set; }
         List<UserAccount> UserCollection { get; set; }
         List<Service> Service = new List<Service>();
        //List<Service> Service { get; set; }

        public MainWindow(UserAccount user, List<UserAccount> userCollection)

        {
            InitializeComponent();

            Service.Add(new Service() { Service_Name = "Consulatation service", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Device and system installtion", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Service calls", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Wire Installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Remote technical Support", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Wifi Installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Smart Doorbell/Smart Lock installatio ", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Wireless camera installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Voice control set up(Alex/Google Home)", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Smart Light installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Computer Software and Hardware Fix/Installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Security System installation", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Home Theater setup", Service_Cost = "200", Service_Details = "" });
            Service.Add(new Service() { Service_Name = "Thermostat setup", Service_Cost = "200", Service_Details = "" });
            List_view.ItemsSource = Service;
        }


        private void Search_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Service> filteredList = new List<Service>();
            if (!string.IsNullOrEmpty(Search_box.Text))
            {
                IEnumerable<Service> serviceQuery = Service.Where(x => x.Service_Name.ToLower().Contains(Search_box.Text));
                foreach (Service service in serviceQuery)
                {
                    filteredList.Add(service);
                }
                List_view.ItemsSource = filteredList;
            }
            else
            {
                List_view.ItemsSource = Service;
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddtoCart(object sender, RoutedEventArgs e)
        {
            List<Service> serviceList = new List<Service>();
            Order newOrder = new Order();
            int total = 0;
            foreach(Service item in List_view.SelectedItems)
            {
                serviceList.Add(item);
                total += int.Parse(item.Service_Cost);
                //MessageBox.Show(item.ToString());
            }
 
            newOrder.ServiceList = serviceList;
            newOrder.Total = Convert.ToString(total);

            SelectTechnician tech = new SelectTechnician(newOrder);
            tech.ShowDialog();
        }
    }
}
