using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeTechServices
{
    [XmlRoot(ElementName = "Card")]
    public class Card
    {
        [XmlAttribute(DataType = "string")]
        public string CardType { get; set; }
        [XmlAttribute(DataType = "string")]
        public string CardNumber { get; set; }
        [XmlAttribute(DataType = "string")]
        public string Expiration { get; set; }
        [XmlAttribute(DataType = "string")]
        public string CardName { get; set; }
        [XmlAttribute(DataType = "string")]
        public string CVV { get; set; }

        public Card() { }

        public Card(string cardType, string cardNumber, string expiration, string cardName, string cvv)
        {
            CardType = cardType;
            CardNumber = cardNumber;
            Expiration = expiration;
            CardName = cardName;
            CVV = cvv;
        }
    }

}
