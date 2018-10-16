using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Vietcombank.Models;

namespace Vietcombank.Services
{
    public class ExchangeRateService : IExchangeRateService
    {
        const string baseURL = "https://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";

        public IEnumerable<Exrate> All(int page = 1, int pageSize = 10)
        {
           
            var request = (HttpWebRequest)WebRequest.Create(baseURL);

            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            var responseStream = response.GetResponseStream();

            var serializer = new XmlSerializer(typeof(ExrateList));

            var exrateList = (ExrateList)serializer.Deserialize(responseStream);

            var result = exrateList.Exrates.OrderBy(n=>n.CurrencyName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            return result;
            
        }

        public int Total()
        {
           
            var request = (HttpWebRequest)WebRequest.Create(baseURL);

            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse)request.GetResponse();

            var responseStream = response.GetResponseStream();

            var serializer = new XmlSerializer(typeof(ExrateList));

            var exrateList = (ExrateList)serializer.Deserialize(responseStream);

            return exrateList.Exrates.Count();
        }
    }
}
