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

        public CreateNewAccount(List<UserAccount> users)
        {
            InitializeComponent();
            Users = users;
        }


        private bool ValidateAllEntries()
        {

            bool fnameValid, lnameValid, passValid, emailValid, numberValid;
            bool addressNumValid, addressNameValid, cityValid, stateValid, zipValid;

            fnameValid = string.IsNullOrWhiteSpace(firstName.Text) ? false : true;
            firstName.Background = fnameValid ? Brushes.White : Brushes.Coral;
            lnameValid = string.IsNullOrWhiteSpace(lastName.Text) ? false : true;
            lastName.Background = lnameValid ? Brushes.White : Brushes.Coral;
            passValid = string.IsNullOrWhiteSpace(password.Password) ? false : true;
            password.Background = passValid ? Brushes.White : Brushes.Coral;
            emailValid = string.IsNullOrWhiteSpace(email.Text) ? false : true;
            email.Background = emailValid ? Brushes.White : Brushes.Coral;
            numberValid = string.IsNullOrWhiteSpace(number.Text) ? false : true;
            number.Background = numberValid ? Brushes.White : Brushes.Coral;

            addressNumValid = string.IsNullOrWhiteSpace(streetNumber.Text) ? false : true;
            streetNumber.Background = addressNumValid ? Brushes.White : Brushes.Coral;
            addressNameValid = string.IsNullOrWhiteSpace(streetName.Text) ? false : true;
            streetName.Background = addressNameValid ? Brushes.White : Brushes.Coral;
            cityValid = string.IsNullOrWhiteSpace(city.Text) ? false : true;
            city.Background = cityValid ? Brushes.White : Brushes.Coral;
            stateValid = string.IsNullOrWhiteSpace(state.Text) ? false : true;
            state.Background = stateValid ? Brushes.White : Brushes.Coral;
            zipValid = string.IsNullOrWhiteSpace(zip.Text) ? false : true;
            zip.Background = zipValid ? Brushes.White : Brushes.Coral;

            //validate card info


            Warning.Visibility = fnameValid && lnameValid && passValid && emailValid && numberValid
                 && addressNumValid && addressNameValid && cityValid && stateValid
                 && zipValid ? Visibility.Hidden : Visibility.Visible;

            return fnameValid && lnameValid && passValid && emailValid && numberValid &&
                addressNumValid && addressNameValid && cityValid && stateValid && zipValid;
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateAllEntries())
            {
                Address address = new Address(streetNumber.Text, streetName.Text, city.Text,
                    state.Text, zip.Text);
                string expiration = expirationDate.Text + "/" + expirationYear.Text;
                Card card = new Card(cardType.SelectedItem.ToString(), cardNumber.Text, expiration, cardName.Text, CVV.Text);
                UserAccount act = new UserAccount(firstName.Text, lastName.Text, password.Password,
                    email.Text, number.Text, address, card);
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
            mail.To.Add(email.Text);
            mail.Subject = "Verify Your New Account";
            mail.Body = $"Welcome to the new application, {firstName.Text}!";
            mail.BodyEncoding = Encoding.UTF8;
            client.Send(mail);
        
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }

}
