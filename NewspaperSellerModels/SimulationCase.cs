using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationCase
    {
        public int DayNo { get; set; }
        public int RandomNewsDayType { get; set; }
        public Enums.DayType NewsDayType { get; set; }
        public int RandomDemand { get; set; }
        public int Demand { get; set; }
        public decimal DailyCost { get; set; } //Demand*cost
        public decimal SalesProfit { get; set; } //Revenue
        public decimal LostProfit { get; set; }
        public decimal ScrapProfit { get; set; } 
        public decimal DailyNetProfit { get; set; }

        public void calculateCase(int numberPurchased, decimal purchaseCost, decimal sellingPrice, decimal scrapPrice, decimal unitProfit)
        {
            DailyCost = numberPurchased * purchaseCost;

            if (Demand >= numberPurchased)
            {
                // Sold all newspapers
                SalesProfit = numberPurchased * sellingPrice;
                LostProfit = (Demand - numberPurchased) * unitProfit;
                ScrapProfit = 0;
            }
            else
            {
                // Couldn't sell all newspapers
                SalesProfit = Demand * sellingPrice;
                LostProfit = 0;
                ScrapProfit = (numberPurchased - Demand) * scrapPrice;
            }

            DailyNetProfit = SalesProfit - DailyCost - LostProfit + ScrapProfit;
        }

    }
}
