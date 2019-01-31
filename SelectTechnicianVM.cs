using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace HomeTechServices
{
    public class SelectTechnicianVM : INotifyPropertyChanged
    {
        public MainWindowVM Parent { get; set; }
        public Order Order { get; set; }
        public UserAccount User { get; set;
        }
        List<Technician> TechList { get; set; } = new List<Technician>();

        public SelectTechnicianVM(MainWindowVM parent, Order order, UserAccount user)
        {
            TechList = ProcessCVSFile("techlist.csv");
            Order = order;
            Parent = parent;
            User = user;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private ObservableCollection<Technician> technicianCollection { get; set; } = new ObservableCollection<Technician>();
        public ObservableCollection<Technician> TechnicianCollection
        {
            get { return technicianCollection; }
            set
            {
                technicianCollection = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TechnicianCollection"));
            }
        }

        private string selectedDate;
        public string SelectedDate
        {
            get { return selectedDate; }
            set
            {
                selectedDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedDate"));
            }
        }

        private string selectedTime;
        public string SelectedTime
        {
            get { return selectedTime; }
            set
            {
                selectedTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTime"));
            }
        }


        private static List<Technician> ProcessCVSFile(string pathToFile)
        {
            return File.ReadAllLines(pathToFile)
                 .Skip(1)
                 .Where(line => line.Length > 1)
                 .Select(Technician.ParseFromFile).ToList();
        }


        private bool CompareTime(string time, string start, string end)
        {
            var format = "hh:mm tt";
            var selectedTime = DateTime.ParseExact(time, format, null, System.Globalization.DateTimeStyles.None);
            var startTime = DateTime.ParseExact(start, format, null, System.Globalization.DateTimeStyles.None);
            var endTime = DateTime.ParseExact(end, format, null, System.Globalization.DateTimeStyles.None);

            return (startTime <= selectedTime) && (selectedTime <= endTime);
        }

        private void FilterList(object obj)
        {
            TechnicianCollection = new ObservableCollection<Technician>();

            if(string.IsNullOrEmpty(SelectedTime.ToString()) && string.IsNullOrEmpty(SelectedDate.ToString()))
            {
                MessageBox.Show("Please complete all fields");
                return;
            }

            foreach(Technician tech in TechList)
            {
                if (CompareTime(SelectedTime.ToString(), tech.StartTime, tech.EndTime))
                {
                    TechnicianCollection.Add(tech);
                }
            }
            

            Order.Time = SelectedTime.ToString();
            Order.Date = SelectedDate.ToString().Substring(0,10);

            FilterTechnicianVM FilterTechnicianVM = new FilterTechnicianVM(this, Order,User);
            FilterTechnician filterTechnician = new FilterTechnician();
            filterTechnician.DataContext = FilterTechnicianVM;
            filterTechnician.ShowDialog();

        }

        public ICommand FilterListCommand
        {
            get
            {
                if (_filterListEvent == null)
                {
                    _filterListEvent = new DelegateCommand(FilterList);
                }

                return _filterListEvent;
            }
        }
        DelegateCommand _filterListEvent;


    }
}
