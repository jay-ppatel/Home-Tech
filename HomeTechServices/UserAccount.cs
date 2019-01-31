using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "UserAccount")]
    public class UserAccount
    {
        [XmlIgnore]
        public Guid CustomerID { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Username { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Name { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Email { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Number { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Address { get; set; }

        public UserAccount() { }

        public UserAccount(string user, string pass, string name, string email, string number, string address)
        {
            this.CustomerID = Guid.NewGuid();
            this.Username = user;
            this.Password = pass;
            this.Name = name;
            this.Email = email;
            this.Number = number;
            this.Address = address;
        }

        public Guid getID()
        {
            return this.CustomerID;
        }

        public string getName()
        {
            return this.Name;
        }

        public string getAddress()
        {
            return this.Address;
        }
    }
}
