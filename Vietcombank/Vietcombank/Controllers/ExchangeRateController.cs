using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Mvc;
using Vietcombank.Models;

namespace Vietcombank.Controllers
{
    public class ExchangeRateController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var baseURL = "https://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";

            var request =  (HttpWebRequest) WebRequest.Create(baseURL);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse) request.GetResponse();

            var responseStream = response.GetResponseStream();

            var serializer = new XmlSerializer(typeof(ExrateList));
            var exrateList = (ExrateList) serializer.Deserialize(responseStream);

            return View(exrateList.Exrates);
        }
    }
}