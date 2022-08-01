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
            
            var tombLink =
                $"https://www.tcmb.gov.tr/kurlar/{((isToday) ? "today" : string.Format("{2}/{1}/{0}{1}{2}", (day.ToString().PadLeft(2, '0'), month.ToString().PadLeft(2, '0')), year))}.xml";

            result.Currencies = new List<GetCurrencyModelItem>();
            var doc = new XmlDocument();
            doc.Load(tombLink);

            if (doc.SelectNodes("Tarih_Date").Count < 1)
            {
                throw new Exception("Kur bilgisi bulunamadı.");

            }

            foreach (XmlNode node in doc.SelectNodes("Tarih_Date")[0].ChildNodes)
            {
                var currencyRate = new GetCurrencyModelItem
                {
                    Code = node.Attributes["Kod"].Value,
                    Name = node["Isim"].InnerText,
                    Unit = int.Parse(node["Unit"].InnerText),
                    ForexBuying = Convert.ToDecimal("0" + node["ForexBuying"].InnerText),
                    ForexSelling = Convert.ToDecimal("0" + node["ForexSelling"].InnerText),
                    BanknoteBuyingRate = Convert.ToDecimal("0" + node["BanknoteBuying"].InnerText),
                    BanknoteSellingRate = Convert.ToDecimal("0" + node["BanknoteSelling"].InnerText)
                };

                result.Currencies.Add(currencyRate);
            }

            return result;
        }
    }
}
