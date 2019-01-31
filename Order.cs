using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "Order")]
    public class Order
    {

        [XmlAttribute(DataType = "string")]
        public string CustomerName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string CustomerAddress { get; set; }
        [XmlElement(ElementName = "Card")]
        public Card Card { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Total { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Date { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Time { get; set; }
        [XmlElement(ElementName = "Technician")]
        public Technician Technician { get; set; }
        [XmlElement(ElementName = "ServiceList")]
        public ObservableCollection<Service> ServiceList { get; set; }

        public Order() { }

        public Order(string name, string address, ObservableCollection<Service> serviceList, string total, string date, string time, Technician tech)
        {

            this.CustomerName = name;
            this.CustomerAddress = address;
            this.ServiceList = serviceList;
            this.Total = total;
            this.Date = date;
            this.Time = time;
            this.Technician = tech;
        }



        public Technician getTech()
        {
            return this.Technician;
        }


        public override string ToString()
        {

            return $"Date: {Date} Time: {Time} Technician: {Technician}";   //base.ToString();
        }


    }
}
