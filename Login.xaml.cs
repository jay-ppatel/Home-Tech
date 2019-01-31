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
using System.Xml.Serialization;

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public List<UserAccount> Users { get; set; } = new List<UserAccount>();
        XmlSerializer xmler = new XmlSerializer(typeof(List<UserAccount>));

        public Login()
        {
            InitializeComponent();
            try
            {
                ReadInUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to read XML file\nInner Exception:{ex.InnerException.Message}");
            }
        }

        private void ReadInUsers()
        {
            string path = "Users.xml";
            if (File.Exists(path))
            {
                using (FileStream rs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Users = xmler.Deserialize(rs) as List<UserAccount>;
                }
            }
        }

        private bool ValidateAllEntries()
        {
            bool userValid, passValid;

            userValid = string.IsNullOrWhiteSpace(username.Text) ? false : true;
            username.Background = userValid ? Brushes.White : Brushes.Coral;
            passValid = string.IsNullOrWhiteSpace(password.Password) ? false : true;
            password.Background = passValid ? Brushes.White : Brushes.Coral;
            Warning.Visibility = userValid && passValid ? Visibility.Hidden : Visibility.Visible;

            return userValid && passValid;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateAllEntries())
            {
                UserAccount account = Users.FirstOrDefault(x => x.Email == username.Text);
                if (account?.Password == password.Password)
                {
                    /*MainWindow mw = new MainWindow(account, Users);
                    this.Close();
                    mw.ShowDialog();*/
                    HomeWindow hw = new HomeWindow(account);
                    hw.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Login credentials", "Sign In Error");
                }
            }
        }
        
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            CreateNewAccount account = new CreateNewAccount(Users);
            account.ShowDialog();
        }
    }
}
