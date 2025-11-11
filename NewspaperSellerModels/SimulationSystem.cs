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

        public Enums.DayType dayTypeUsingProbability(int randomDigit)
        {
            foreach(DayTypeDistribution dist in DayTypeDistributions)
            {
                if (dist.MinRange < randomDigit && dist.MaxRange > randomDigit)
                    return dist.DayType;
            }

            return Enums.DayType.Poor;
        }

        public int demandUsingProbability(int randomDigit)
        {
            foreach (DemandDistribution demandDist in DemandDistributions)
            {
                foreach(DayTypeDistribution dayDist in demandDist.DayTypeDistributions)
                {
                    if (dayDist.MinRange < randomDigit && dayDist.MaxRange > randomDigit)
                        return demandDist.Demand;
                }
            }

            return 0;
        }

        public void performanceReview()
        {
            this.PerformanceMeasures.TotalSalesProfit = 0;
            this.PerformanceMeasures.TotalCost = 0;
            this.PerformanceMeasures.TotalLostProfit = 0;
            this.PerformanceMeasures.TotalScrapProfit = 0;
            this.PerformanceMeasures.TotalNetProfit = 0;
            this.PerformanceMeasures.DaysWithMoreDemand = 0;
            this.PerformanceMeasures.DaysWithUnsoldPapers = 0;

            foreach(SimulationCase sim in SimulationTable)
            {
                this.PerformanceMeasures.TotalSalesProfit +=sim.SalesProfit;
                this.PerformanceMeasures.TotalCost += sim.DailyCost;
                this.PerformanceMeasures.TotalLostProfit += sim.LostProfit;
                this.PerformanceMeasures.TotalScrapProfit +=sim.ScrapProfit;
                this.PerformanceMeasures.TotalNetProfit +=sim.DailyNetProfit;

                if(sim.LostProfit>0)
                    this.PerformanceMeasures.DaysWithUnsoldPapers++;

                if(sim.ScrapProfit>0)
                    this.PerformanceMeasures.DaysWithMoreDemand++;
            }
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
                simulationCase.RandomNewsDayType = randomDay.Next(1,100);
                simulationCase.RandomDemand = randomDemand.Next(1, 100);
                simulationCase.NewsDayType=dayTypeUsingProbability(simulationCase.RandomNewsDayType);
                simulationCase.Demand=demandUsingProbability(simulationCase.Demand);

                simulationCase.calculateCase(NumOfNewspapers, PurchasePrice,SellingPrice,ScrapPrice,UnitProfit);
                this.SimulationTable.Add(simulationCase);
            }
            this.performanceReview();
        }
    }
}
