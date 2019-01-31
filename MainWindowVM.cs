using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeTechServices
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ServiceDisplayVM ServiceDisplayVM { get; set; }
        public UserAccount CurrentUser { get; set; }
        public Order newOrder { get; set; }

        private ObservableCollection<Service> _cartContents = new ObservableCollection<Service>();
        public ObservableCollection<Service> CartContents
        {
            get { return _cartContents; }
            set
            {
                _cartContents = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CartContents"));
            }
        }

        private int total;
        public int Total
        {
            get { return total; }
            set
            {
                total = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Total"));
            }
        }

        private string warning;
        public string Warning
        {
            get { return warning; }
            set
            {
                warning = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Warning"));
            }
        }

        private string filterItem;
        public string FilterItem
        {
            get { return filterItem; }
            set
            {
                filterItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("FilterItem"));
            }
        }

        private string selectDate;
        public string SelectDate
        {
            get { return selectDate; }
            set
            {
                selectDate = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectDate"));
            }
        }

        private string selectTime;
        public string SelectTime
        {
            get { return selectTime; }
            set
            {
                selectTime = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectTime"));
            }
        }

        private string selectTechnician;
        public string SelectTechnician
        {
            get { return selectTechnician; }
            set
            {
                selectTechnician = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectTechnician"));
            }
        }

        public MainWindowVM()
        {
            ServiceDisplayVM = new ServiceDisplayVM();
        }

        private void FilterList(object obj)
        {
            if(string.IsNullOrEmpty(FilterItem))
            {

                return;
            }

            ServiceDisplayVM = new ServiceDisplayVM();

            ServiceDisplayVM.FilteredCollection = new ObservableCollection<Service>();
            string searchInput = FilterItem.ToLower();
            ServiceDisplayVM.UpdateCollection(FilterItem.ToLower());

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

        private void AddToCartClicked(object obj)
        {
            Warning = "";
            Service selectedService = ServiceDisplayVM.SelectedService;

            if (ServiceDisplayVM.SelectedService == null)
            {
                Warning = "Please select a service.";
                MessageBox.Show("Please select a service");
                return;
            }

            Total += int.Parse(selectedService.Service_Cost);
            CartContents.Add(selectedService);

        }

        public ICommand AddToCartCommand
        {
            get
            {
                if (_addToCartEvent == null)
                {
                    _addToCartEvent = new DelegateCommand(AddToCartClicked);
                }

                return _addToCartEvent;
            }
        }
        DelegateCommand _addToCartEvent;

        private void AddTechnicianClicked(object obj)
        {
            newOrder = new Order();
            string name = CurrentUser.FirstName + " " + CurrentUser.LastName;
            newOrder.CustomerName = name;
            newOrder.CustomerAddress = CurrentUser.UserAddress.ToString();
            newOrder.Card = CurrentUser.UserCard;

            newOrder.ServiceList = CartContents;
            newOrder.Total = string.Concat("$", Convert.ToString(Total));

            SelectTechnicianVM SelectTechnicianVM = new SelectTechnicianVM(this, newOrder, CurrentUser);
            SelectTechnician tech = new SelectTechnician(newOrder);
            tech.DataContext = SelectTechnicianVM;
            tech.ShowDialog();


        }

        public ICommand AddTechnicianCommand
        {
            get
            {
                if (_addTechEvent == null)
                {
                    _addTechEvent = new DelegateCommand(AddTechnicianClicked);
                }

                return _addTechEvent;
            }
        }
        DelegateCommand _addTechEvent;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

    }
}
