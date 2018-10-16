using System.ComponentModel;
using System.Xml.Serialization;

namespace Vietcombank.Models
{
    public class Exrate
    {
        [XmlAttribute(AttributeName = "CurrencyCode")]
        [DisplayName("Mã ngoại tệ")]
        public string CurrencyCode { get; set; }
        [DisplayName("Tên ngoại tệ")]
        [XmlAttribute(AttributeName = "CurrencyName")]
        public string CurrencyName { get; set; }
        [DisplayName("Mua tiền mặt")]
        [XmlAttribute(AttributeName = "Buy")]
        public string Buy { get; set; }
        [DisplayName("Mã chuyển khoản")]
        [XmlAttribute(AttributeName = "Transfer")]
        public string Transfer { get; set; }
        [DisplayName("Bán")]
        [XmlAttribute(AttributeName = "Sell")]
        public string Sell { get; set; }
    }
}