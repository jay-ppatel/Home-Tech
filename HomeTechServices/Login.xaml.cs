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
            ReadInUsers();
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

        private bool ValidatAllEntries()
        {
            if (string.IsNullOrWhiteSpace(username.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(password.Password))
            {
                return false;
            }
            return true;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if(ValidatAllEntries())
            {
                UserAccount account = Users.FirstOrDefault(x => x.Username == username.Text);
                if (account?.Password == password.Password)
                {
                    MainWindow mw = new MainWindow(account, Users);
                    this.Close();
                    mw.ShowDialog();
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
