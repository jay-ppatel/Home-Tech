using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "Address")]
    public class Address
    {
        [XmlAttribute(DataType = "string")] public string StreetNumber { get; set; }
        [XmlAttribute(DataType = "string")] public string StreetName { get; set; }
        [XmlAttribute(DataType = "string")] public string City { get; set; }
        [XmlAttribute(DataType = "string")] public string State { get; set; }
        [XmlAttribute(DataType = "string")] public string ZipCode { get; set; }

        public Address() { }

        public Address(string streetNumber, string streetName, string city, string state, string zipCode)
        {
            StreetNumber = streetNumber;
            StreetName = streetName;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public override string ToString()
        {
            return $"{StreetNumber} {StreetName} {City} {State} {ZipCode}";
        }
    }
}
