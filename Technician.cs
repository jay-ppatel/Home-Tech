using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "Technician")]
    public class Technician
    {
        [XmlAttribute(DataType = "string")]
        public string Name { get; set; }
        [XmlAttribute(DataType = "string")]
        public string PhoneNumber { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Email { get; set; }
        [XmlAttribute(DataType = "string")]
        public string StartTime { get; set; }
        [XmlAttribute(DataType = "string")]
        public string EndTime { get; set; }

        internal static Technician ParseFromFile(string line)
        {
            var columns = line.Split(',');
            return new Technician
            {
                Name = columns[0],
                PhoneNumber = columns[1],
                Email = columns[2],
                StartTime = columns[3],
                EndTime = columns[4]

            };
        }

        public override string ToString()
        {
            return $"{Name}";
        }

    }
}
