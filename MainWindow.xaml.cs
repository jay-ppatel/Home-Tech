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
        List<Service> Service = new List<Service>();
        Order newOrder = new Order();

        public MainWindow(UserAccount user)
        {
            MainWindowVM MainWindowVM = new MainWindowVM();
            InitializeComponent();
            CurrentUser = user;
            MainWindowVM.CurrentUser = CurrentUser;
            DataContext = MainWindowVM;


        }
    }
}

        /*
        private void Search_box_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            List<Service> filteredList = new List<Service>();
            if (!string.IsNullOrEmpty(Search_box.Text))
            {
                string searchInput = Search_box.Text.ToLower();
                IEnumerable<Service> serviceQuery = Service.Where(x => (x.Service_Name.ToLower()).Contains(searchInput));
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
        }*/
        

