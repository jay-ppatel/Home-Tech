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
        [XmlAttribute(DataType = "string")]
        public string FirstName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string LastName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Password { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Email { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Number { get; set; }
        [XmlElement(ElementName = "UserAddress")]
        public Address UserAddress { get; set; }
        [XmlElement(ElementName = "UserCard")]
        public Card UserCard { get; set; }

        public UserAccount() { }

        public UserAccount(string fname, string lname, string pass, string email, string number, Address address, Card card)
        {
            this.FirstName = fname;
            this.LastName = lname;
            this.Password = pass;
            this.Email = email;
            this.Number = number;
            this.UserAddress = address;
            this.UserCard = card;
        }
  


    }
}
