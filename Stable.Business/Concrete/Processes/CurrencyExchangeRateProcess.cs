using Stable.Business.Abstract.Processes;
using Stable.Business.Concrete.Requests;
using Stable.Business.Concrete.Responses.CurrencyExchangeRate;
using Stable.Core.Utilities.Results.Concrete;
using Stable.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace Stable.Business.Concrete.Processes
{
    public class CurrencyExchangeRateProcess : ICurrencyExchangeRateProcess
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyExchangeRateProcess(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public CurrencyExchangeRateDto Execute(CurrencyExchangeRateRequest currencyExchangeRateRequest)
        {
            CurrencyExchangeRateDto result = new CurrencyExchangeRateDto();

            string tcmbLink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml",
                (currencyExchangeRateRequest.IsToday) ? "today" : string.Format("{2}/{1}/{0}{1}{2}",
                (currencyExchangeRateRequest.Day.ToString().PadLeft(2, '0'), currencyExchangeRateRequest.Month.ToString().PadLeft(2, '0')),
                currencyExchangeRateRequest.Year));

            result.Currencies = new List<CurrencyExchangeRateItemDto>();
            XmlDocument doc = new XmlDocument();
            doc.Load(tcmbLink);

            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                throw new Exception("Kur bilgisi bulunamadı.");

            }

            foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                var currencyRate = new CurrencyExchangeRateItemDto();
                currencyRate.Code = node.Attributes["Kod"].Value;
                currencyRate.Name = node["Isim"].InnerText;
                currencyRate.Unit = int.Parse(node["Unit"].InnerText);
                currencyRate.ForexBuying = Convert.ToDecimal("0" + node["ForexBuying"].InnerText.Replace(".", ","));
                currencyRate.ForexSelling = Convert.ToDecimal("0" + node["ForexSelling"].InnerText.Replace(".", ","));
                currencyRate.BanknoteBuyingRate = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText.Replace(".", ","));
                currencyRate.BanknoteSellingRate = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText.Replace(".", ","));

                result.Currencies.Add(currencyRate);
            }

            return result;
        }
    }
}
