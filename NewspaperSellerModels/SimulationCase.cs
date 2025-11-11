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

        public void calculateCase(int numberPurchased,decimal purchaseCost, decimal sellingCost, decimal scrapPrice, decimal unitProfit)
        {
            this.DailyCost = purchaseCost * numberPurchased;
            this.SalesProfit = sellingCost * this.Demand;
            this.ScrapProfit= scrapPrice * Math.Abs(this.Demand-numberPurchased);

            decimal diff = this.DailyCost - (this.SalesProfit + this.ScrapProfit);
            if (diff < 0)
                this.LostProfit = Math.Abs(diff);
            else
                this.LostProfit = 0;
            
            this.DailyNetProfit = this.SalesProfit - this.DailyCost - this.LostProfit + this.ScrapProfit;

        }
    }
}
