using Stable.Business.Concrete.Helpers.Models;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Stable.Business.Concrete.Helpers
{
    public static class GetCurrencyHelper
    {
        public static GetCurrencyModel GetCurrency(int day, int month, int year, bool isToday)
        {
            var result = new GetCurrencyModel();
            
            string tcmbLink = string.Format("https://www.tcmb.gov.tr/kurlar/{0}.xml",
                (isToday) ? "today" : string.Format("{2}/{1}/{0}{1}{2}",
                (day.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0')),
                year));

            result.Currencies = new List<GetCurrencyModelItem>();
            XmlDocument doc = new XmlDocument();
            doc.Load(tcmbLink);

            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                throw new Exception("Kur bilgisi bulunamadı.");

            }

            foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                var currencyRate = new GetCurrencyModelItem();
                currencyRate.Code = node.Attributes["Kod"].Value;
                currencyRate.Name = node["Isim"].InnerText;
                currencyRate.Unit = int.Parse(node["Unit"].InnerText);
                currencyRate.ForexBuying = Convert.ToDecimal("0" + node["ForexBuying"].InnerText);
                currencyRate.ForexSelling = Convert.ToDecimal("0" + node["ForexSelling"].InnerText);
                currencyRate.BanknoteBuyingRate = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText);
                currencyRate.BanknoteSellingRate = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText);

                result.Currencies.Add(currencyRate);
            }


            return result;
        }
    }
}
