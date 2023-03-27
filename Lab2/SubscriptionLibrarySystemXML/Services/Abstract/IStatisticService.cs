using System.Xml.Linq;

namespace SubscriptionLibrarySystemXML.Services.Abstract
{
    internal interface IStatisticService
    {
        decimal GetTotalRentalRevenue(XDocument doc);
        decimal GetAverageCollateralPrice(XDocument doc);
        decimal GetAverageDailyRentalPrice(XDocument doc);
    }
}
