using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HomeTechServices
{
    public class FilterTechnicianVM : INotifyPropertyChanged
    {
        public UserAccount User { get; set; }
        public SelectTechnicianVM Parent { get; set; }
        public Order Order { get; set; }
        public FilterTechnicianVM(SelectTechnicianVM parent, Order order, UserAccount user)
        {
            Parent = parent;
            Order = order;
            User = user;
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        private Technician selectedTechnician;
        public Technician SelectedTechnician
        {
            get { return selectedTechnician; }
            set
            {
                selectedTechnician = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTechnician"));
            }
        }

        public void ConfirmOrderClicked(object obj)
        {
            if (SelectedTechnician == null)
            {
                MessageBox.Show("Select a technician");
                return;
            }

            Technician technician = SelectedTechnician;
            Order.Technician = technician;
            FinalOrderPage final = new FinalOrderPage(Order, User);
            final.ShowDialog();

        }
        public ICommand ConfirmOrderCommand
        {
            get
            {
                if (_addItemEvent == null)
                {
                    _addItemEvent = new DelegateCommand(ConfirmOrderClicked);
                }

                return _addItemEvent;
            }
        }
        DelegateCommand _addItemEvent;

    }
}
