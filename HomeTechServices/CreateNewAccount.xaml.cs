using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
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
    /// Interaction logic for CreateNewAccount.xaml
    /// </summary>
    public partial class CreateNewAccount : Window
    {
        public List<UserAccount> Users { get; set; }
        XmlSerializer xmler = new XmlSerializer(typeof(List<UserAccount>));
        public bool IsEdit { get; set; }
        public UserAccount EditingUser { get; set; }

        public CreateNewAccount(List<UserAccount> users, bool isEdit = false)
        {
            InitializeComponent();
            Users = users;
            IsEdit = isEdit;
        }

        public CreateNewAccount(UserAccount user, List<UserAccount> users, bool isEdit = true)
        {
            InitializeComponent();
            IsEdit = isEdit;
            EditingUser = user;
            Users = users;
        }

        private bool ValidateAllEntries()
        {
            if (string.IsNullOrWhiteSpace(fullName.Text))
            {
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(userName.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(password.Password))
            {
                return false;
            }
            /*
            if (string.IsNullOrWhiteSpace(email.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(number.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(email.Text))
            {
                return false;
            }*/
            return true;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateAllEntries())
            {
                UserAccount act = new UserAccount();//(username.Text, password.Password, name.Text);
                act.Username = userName.Text;
                act.Password = password.Password;
                Users.Add(act);
                string path = "Users.xml";
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
                {
                    xmler.Serialize(fs, Users);
                }
                MessageBox.Show("Account Has Been Created, check your email", "Success!!");
                EmailNewUser();
                this.Close();
            }
        }

        private void EmailNewUser()
        {
            //this is specific to gmail, if you use a different service, you must find the proper one
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Timeout = 10000;
            //the first parameter is the account sending the email, the second is the password for that account
            client.Credentials = new System.Net.NetworkCredential("noreply.HomeTechServices@gmail.com", "softwaredev23");
            MailMessage mail = new MailMessage();
            //parameter is the account send ing the mail
            mail.From = new MailAddress("noreply.HomeTechServices@gmail.com");
            //parameter is the account receiving the email
            mail.To.Add(userName.Text);
            mail.Subject = "Verify Your New Account";
            mail.Body = $"Welcome to the new application, {fullName.Text}!";
            mail.BodyEncoding = Encoding.UTF8;
            client.Send(mail);
        
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
