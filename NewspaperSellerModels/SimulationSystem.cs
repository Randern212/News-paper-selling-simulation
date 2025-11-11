using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperSellerModels
{
    public class SimulationSystem
    {
        public SimulationSystem()
        {
            DayTypeDistributions = new List<DayTypeDistribution>();
            DemandDistributions = new List<DemandDistribution>();
            SimulationTable = new List<SimulationCase>();
            PerformanceMeasures = new PerformanceMeasures();
        }
        ///////////// INPUTS /////////////
        public int NumOfNewspapers { get; set; }
        public int NumOfRecords { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal ScrapPrice { get; set; }
        public decimal UnitProfit { get; set; }
        public List<DayTypeDistribution> DayTypeDistributions { get; set; }
        public List<DemandDistribution> DemandDistributions { get; set; }

        ///////////// OUTPUTS /////////////
        public List<SimulationCase> SimulationTable { get; set; }
        public PerformanceMeasures PerformanceMeasures { get; set; }

        public int getMinDayDigit()
        {
            int minDigit=this.DayTypeDistributions[0].MinRange;
            foreach(var dist in this.DayTypeDistributions)
            {
                if (minDigit > dist.MinRange)
                {
                    minDigit = dist.MinRange;
                }
            }
            return minDigit;
        }
        public int getMaxDayDigit()
        {
            int minDigit = this.DayTypeDistributions[0].MaxRange;
            foreach (var dist in this.DayTypeDistributions)
            {
                if (minDigit < dist.MaxRange)
                {
                    minDigit = dist.MaxRange;
                }
            }
            return minDigit;
        }

        public void runSimulation()
        {
            this.SimulationTable.Clear();

            Random randomDay= new Random();
            Random randomDemand = new Random();
            for (int i=0;i< this.NumOfRecords;i++)
            {
                SimulationCase simulationCase = new SimulationCase();
                simulationCase.DayNo = i+1;
                simulationCase.RandomNewsDayType = randomDay.Next(this.getMinDayDigit(),this.getMaxDayDigit());

                this.SimulationTable.Add(simulationCase);
            }
        }
    }
}
