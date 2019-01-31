using System;
using System.Collections.Generic;
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

namespace HomeTechServices
{
    /// <summary>
    /// Interaction logic for SelectTechnician.xaml
    /// </summary>
    public partial class SelectTechnician : Window
    {
        //MainWindowVM Main = new MainWindowVM();
        Order Order = null;
        //List<Technician> TechnicianCollection = ProcessCVSFile("techlist.csv");
        List<string> timeOptions = new List<string>() { "08:00 AM", "09:00 AM", "10:00 AM", "11:00 AM",
            "12:00 PM", "01:00 PM", "02:00 PM", "03:00 PM", "04:00 PM", "05:00 PM", "06:00 PM", "07:00 PM",
            "08:00 PM", "09:00 PM", "10:00 PM" };

        public SelectTechnician(Order order)
        {
            //Main = main;
            //SelectTechnicianVM selectTechnicianVM = new SelectTechnicianVM(Main);
            InitializeComponent();
            Order = order;
            time.ItemsSource = timeOptions;
            //DataContext = selectTechnicianVM;
        }

        /*
        private static List<Technician> ProcessCVSFile(string pathToFile)
        {
           return File.ReadAllLines(pathToFile)
                .Skip(1)
                .Where(line => line.Length > 1)
                .Select(Technician.ParseFromFile).ToList();
        }

        private List<string> technicianName(List<Technician> technicians)
        {
            List<string> names = new List<string>();
            foreach(Technician tech in technicians)
            {
               names.Add(tech.ToString());
            }
            return names;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(IsValid())
            {
                Order.Date = date.Text;
                Order.Time = time.SelectionBoxItem.ToString();
                Order.Technician = technicianList.SelectedItem.ToString();
                FinalOrderPage final = new FinalOrderPage(Order,TechnicianCollection);
                final.Show();
                this.Close();
            }
        }

        private bool IsValid()
        {
            bool validateDate, validateTime, validateTech;

            validateDate = string.IsNullOrEmpty(date.Text) ? false : true;
            validateTime = string.IsNullOrEmpty(time.SelectionBoxItem.ToString()) ? false : true;
            validateTech = technicianList.SelectedIndex == -1 ? false : true;
            Warning.Visibility = validateDate && validateTime && validateTech ? Visibility.Hidden : Visibility.Visible;

            return validateDate && validateTime && validateTech;

        }
        
        
        private bool CompareTime(string time, string start, string end)
        { 
            var format = "hh:mm tt";
            var selectedTime = DateTime.ParseExact(time, format, null, System.Globalization.DateTimeStyles.None);
            var startTime = DateTime.ParseExact(start, format, null, System.Globalization.DateTimeStyles.None);
            var endTime = DateTime.ParseExact(end, format, null, System.Globalization.DateTimeStyles.None);

            return (startTime <= selectedTime) && (selectedTime <= endTime);
        }*/
        
        private void time_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
            List<string> filteredList = new List<string>();
            if (!string.IsNullOrEmpty(time.SelectionBoxItem.ToString()))
            {
                foreach (Technician tech in TechnicianCollection)
                { 
                    if(CompareTime(time.SelectionBoxItem.ToString(), tech.StartTime, tech.EndTime))
                    {
                        filteredList.Add(tech.ToString());
                    }
                    
                }

                technicianList.ItemsSource = filteredList;
            }
           else
            {
                technicianList.ItemsSource = technicianName(TechnicianCollection);
            }*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
