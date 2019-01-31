using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "Service")]
    public class Service
    {
        [XmlAttribute(DataType = "string")]
        public string Service_Name { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Service_Cost { get; set; }

        public Service() { }

        public Service(string sName, string sCost)
        {
            this.Service_Name = sName;
            this.Service_Cost = sCost;
        }

        public override string ToString()
        {
            return $"{Service_Name}: ${Service_Cost}";
        }
    }
    
}