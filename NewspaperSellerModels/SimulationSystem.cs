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

        public void runSimulation()
        {
            this.SimulationTable.Clear();

            Random randomDay= new Random();
            Random randomDemand = new Random();
            for (int i=0;i< this.NumOfRecords;i++)
            {
                SimulationCase simulationCase = new SimulationCase();
                simulationCase.DayNo = i+1;
                simulationCase.RandomNewsDayType = randomDay.Next(1,101);
                simulationCase.RandomDemand = randomDemand.Next(1, 101);
                simulationCase.NewsDayType=dayTypeUsingProbability(simulationCase.RandomNewsDayType);
                simulationCase.Demand=demandUsingProbability(simulationCase.Demand);

                simulationCase.calculateCase();
                this.SimulationTable.Add(simulationCase);
            }
        }
    }
}
