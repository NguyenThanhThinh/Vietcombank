using System.Xml.Serialization;

namespace Vietcombank.Models
{
    public class Exrate
    {
        [XmlAttribute(AttributeName = "CurrencyCode")]
        public string CurrencyCode { get; set; }

        [XmlAttribute(AttributeName = "CurrencyName")]
        public string CurrencyName { get; set; }

        [XmlAttribute(AttributeName = "Buy")] public string Buy { get; set; }

        [XmlAttribute(AttributeName = "Transfer")]
        public string Transfer { get; set; }

        [XmlAttribute(AttributeName = "Sell")] public string Sell { get; set; }
    }
}