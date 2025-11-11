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
            SalesProfit = Demand * sellingPrice;

            LostProfit = 0;
            ScrapProfit = 0;

            if (Demand > numberPurchased)
                LostProfit = (Demand - numberPurchased) * (sellingPrice - purchaseCost);
            else if (Demand < numberPurchased)
                ScrapProfit = (numberPurchased - Demand) * scrapPrice;
           
            DailyNetProfit = SalesProfit - DailyCost - LostProfit + ScrapProfit;
        }

    }
}
