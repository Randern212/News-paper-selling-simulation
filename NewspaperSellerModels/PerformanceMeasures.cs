using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class PerformanceMeasures
    {
        public decimal TotalSalesProfit { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalLostProfit { get; set; }
        public decimal TotalScrapProfit { get; set; }
        public decimal TotalNetProfit { get; set; }
        public int DaysWithMoreDemand { get; set; }
        public int DaysWithUnsoldPapers { get; set; }
        public List<object> toList()
        {
            return new List<object>
    {
        new { Measure = "Total Sales Profit", Value = TotalSalesProfit.ToString("C") },
        new { Measure = "Total Cost", Value = TotalCost.ToString("C") },
        new { Measure = "Total Lost Profit", Value = TotalLostProfit.ToString("C") },
        new { Measure = "Total Scrap Profit", Value = TotalScrapProfit.ToString("C") },
        new { Measure = "Total Net Profit", Value = TotalNetProfit.ToString("C") },
        new { Measure = "Days With More Demand", Value = DaysWithMoreDemand.ToString() },
        new { Measure = "Days With Unsold Papers", Value = DaysWithUnsoldPapers.ToString() }
    };
        }
    }
}
