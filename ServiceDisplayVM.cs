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
using System.Xml.Serialization;

namespace HomeTechServices
{
    public class ServiceDisplayVM : INotifyPropertyChanged
    {

        public static ObservableCollection<Service> Services { get; set; } = new ObservableCollection<Service>();
        public static ObservableCollection<Service> ServiceCollection { get; set; } = new ObservableCollection<Service>();

        public static ObservableCollection<Service> FilteredCollection { get; set; } = new ObservableCollection<Service>();

        private Service selectedService;
        public Service SelectedService
        {
            get { return selectedService; }
            set
            {
                selectedService = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedService"));
            }
        }

        public ServiceDisplayVM()
        {
            AddServices();
            try
            {
                ReadInOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to read ProductVMXML file\nInner Exception:{ex.InnerException.Message}");
            }

        }

        private void ReadInOrders()
        {
            string path = "Services.xml";
            XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Service>));

            if (File.Exists(path))
            {
                using (FileStream rs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    ServiceCollection = xmler.Deserialize(rs) as ObservableCollection<Service>;
                }
            }
        }

        private void AddServices()
        {
            Services.Add(new Service() { Service_Name = "Consultation service", Service_Cost = "200" });
            Services.Add(new Service() { Service_Name = "Device and System Installation", Service_Cost = "300" });
            Services.Add(new Service() { Service_Name = "Service Calls", Service_Cost = "190" });
            Services.Add(new Service() { Service_Name = "Wire Installation", Service_Cost = "250" });
            Services.Add(new Service() { Service_Name = "Remote Technical Support", Service_Cost = "160" });
            Services.Add(new Service() { Service_Name = "Wifi Installation", Service_Cost = "200" });
            Services.Add(new Service() { Service_Name = "Smart Doorbell/Smart Lock Installation", Service_Cost = "340" });
            Services.Add(new Service() { Service_Name = "Wireless Camera Installation", Service_Cost = "400" });
            Services.Add(new Service() { Service_Name = "Voice Control Set-up (Alexa/Google Home)", Service_Cost = "100" });
            Services.Add(new Service() { Service_Name = "Smart Light Installation", Service_Cost = "600" });
            Services.Add(new Service() { Service_Name = "Computer Software and Hardware Fix/Installation", Service_Cost = "100" });
            Services.Add(new Service() { Service_Name = "Security System Installation", Service_Cost = "430" });
            Services.Add(new Service() { Service_Name = "Home Theater Set-Up", Service_Cost = "380" });
            Services.Add(new Service() { Service_Name = "Thermostat Set-Up", Service_Cost = "220" });

            string path = "Services.xml";
            XmlSerializer xmler = new XmlSerializer(typeof(ObservableCollection<Service>));
            using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                xmler.Serialize(fs, Services);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public static void UpdateCollection(string search)
        {
            ObservableCollection<Service> hold = new ObservableCollection<Service>();
            hold = ServiceCollection;
            if (!string.IsNullOrEmpty(search))
            {
                ServiceCollection.Clear();
                IEnumerable<Service> serviceQuery = Services.Where(x => (x.Service_Name.ToLower()).Contains(search));
                foreach (Service service in serviceQuery)
                {
                    FilteredCollection.Add(service);
                }
                ServiceCollection = FilteredCollection;
                CollectionViewSource.GetDefaultView(ServiceCollection).Refresh();
            }
            else
            {
                ServiceCollection = hold;
                FilteredCollection = ServiceCollection;
                CollectionViewSource.GetDefaultView(ServiceCollection).Refresh();
            }


            //ServiceCollection = Services;
            /*
            Pet petToUpdate = PetCollection.FirstOrDefault(x => x.Name == pet.Name);
            petToUpdate.Stock = petToUpdate.Stock - purchasedAmount;
            CollectionViewSource.GetDefaultView(PetCollection).Refresh();*/
        }

    }
}
