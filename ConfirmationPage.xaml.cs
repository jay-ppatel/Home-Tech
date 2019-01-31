using System;
using System.Collections.Generic;
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

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for ConfirmationPage.xaml
    /// </summary>
    public partial class ConfirmationPage : Window
    {
        Order Order = null;
        UserAccount User = null;

        public ConfirmationPage(Order order, UserAccount user)
        {
            InitializeComponent();
            Order = order;
            User = user;
            technician.Content = order.Technician.Name;
            date.Content = order.Date;
            time.Content = order.Time;
            total.Content = order.Total;
            address.Content = order.CustomerAddress.ToString();
            card.Content = order.Card.CardNumber;
            number.Content = order.Technician.PhoneNumber;
            email.Content = order.Technician.Email;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            HomeWindow hw = new HomeWindow(User);
            hw.Show();

            this.Close();
        }


    }
}
