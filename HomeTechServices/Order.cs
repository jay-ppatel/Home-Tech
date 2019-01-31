using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    public class Order : UserAccount
    {
        public List<Service> ServiceList { get; set; }
        public string Total { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Technician { get; set; }

        public Order() { }

        public Order(List<Service> serviceList, string total, string date, string time, string tech)
        {
            this.CustomerID = getID();
            this.Name = getName();
            this.Address = getAddress();
            this.ServiceList = serviceList;
            this.Total = total;
            this.Date = date;
            this.Time = time;
            this.Technician = tech;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
    }
}
