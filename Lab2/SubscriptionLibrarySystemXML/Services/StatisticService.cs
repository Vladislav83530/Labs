using SubscriptionLibrarySystemXML.Services.Abstract;
using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services
{
    internal class StatisticService : IStatisticService
    {

        /// <summary>
        /// Get total rental revenue
        /// </summary>
        /// <returns>sum price</returns>
        public decimal GetTotalRentalRevenue(XDocument doc) =>
            doc.Descendants("subscription").Sum(b => (decimal)b.Attribute("rentalfee"));


        /// <summary>
        /// Get average collateral price
        /// </summary>
        /// <returns>average price</returns>
        public decimal GetAverageCollateralPrice(XDocument doc) =>
            doc.Descendants("book").Average(b => (decimal)b.Attribute("collateralprice"));

        /// <summary>
        /// Get average daily rental price
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>average price</returns>
        public decimal GetAverageDailyRentalPrice(XDocument doc) =>
            doc.Descendants("book").Average(b => (decimal)b.Attribute("dailyrentalprice"));
    }
}
