using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTechServices
{
    public class Service
    {
        public string Service_Name { get; set; }
        public string Service_Cost { get; set; }
        public string Service_Details { get; set; }

        public Service() { }

        public Service(string sName, string sCost, string sDetails)
        {
            this.Service_Name = sName;
            this.Service_Cost = sCost;
            this.Service_Details = sDetails;
        }

        public override string ToString()
        {
            return $"{Service_Name}, {Service_Cost}";
        }
    }
    
}