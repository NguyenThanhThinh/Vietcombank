using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Vietcombank.Models;
using Vietcombank.ViewModels;

namespace Vietcombank.Services
{
    using static ServiceConstants;
    public class ExchangeRateService : IExchangeRateService
    {
        private const string baseURL = "https://www.vietcombank.com.vn/exchangerates/ExrateXML.aspx";

        private const string dongaBankURL = "http://www.dongabank.com.vn/exchange/export";

        public IEnumerable<Exrate> All(int page = DefaultPage, int pageSize = DefaultPageSize)
        {
            var exrateList = ExrateList();

            var result = exrateList.Exrates.OrderBy(n => n.CurrencyName)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            return result;
        }

        private static ExrateList ExrateList()
        {
            var request = (HttpWebRequest) WebRequest.Create(baseURL);

            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse) request.GetResponse();

            var responseStream = response.GetResponseStream();

            var serializer = new XmlSerializer(typeof(ExrateList));

            var exrateList = (ExrateList) serializer.Deserialize(responseStream);

            return exrateList;
        }

        public IEnumerable<Item> GetAllDongA(int page = DefaultPage, int pageSize = DefaultPageSize)
        {
            var exrateBankViewModel = DongABank();

            var result = exrateBankViewModel.Items.OrderBy(n => n.type)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();

            return result;
        }

        private static DongABankViewModel DongABank()
        {
            var request = (HttpWebRequest) WebRequest.Create(dongaBankURL);

            request.Headers["User-Agent"] = "Mozilla/5.0 ( compatible ) ";

            request.Headers["Accept"] = "*/*";

            request.AutomaticDecompression = DecompressionMethods.GZip;

            var response = (HttpWebResponse) request.GetResponse();

            var responseStream = response.GetResponseStream();

            var reader = new StreamReader(responseStream);

            var data = reader.ReadToEnd();

            data = data.Replace(")", "").Replace("(", "");
           
            var exrateBankViewModel =
                (DongABankViewModel) JsonConvert.DeserializeObject(data, typeof(DongABankViewModel));
            return exrateBankViewModel;
        }

        public int Total()
        {
            var exrateList = ExrateList();

            return exrateList.Exrates.Count();
        }

        public int TotalDongA()
        {
            var exrateBankViewModel = DongABank();

            return exrateBankViewModel.Items.Count();
        }
    }
}