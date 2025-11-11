using NewspaperSellerModels;
using NewspaperSellerTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NewspaperSellerSimulation
{
    public partial class Form1 : Form
    {
        SimulationSystem system;
        public Form1(SimulationSystem system)
        {
            InitializeComponent();
            this.system = system;
            BindingSource simBindingSource = new BindingSource();

            simBindingSource.DataSource = system.SimulationTable;
            dgvSimulationTable.DataSource = simBindingSource;
        }

        private void loadTestCasesButton(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "Select testCase File"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                readConfiguration(openFile.FileName);
                MessageBox.Show("testCase loaded successfully!");
            }
        }
        public void readConfiguration(string fileName)
        {
            var lines = File.ReadAllLines(fileName).Select(l => l.Trim()).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

            int i = 0;

            while (i < lines.Count)
            {
                string key = lines[i];
                i++;

                switch (key)
                {
                    case "NumOfNewspapers":
                        system.NumOfNewspapers = int.Parse(lines[i]);
                        i++;
                        break;

                    case "NumOfRecords":
                        system.NumOfRecords = int.Parse(lines[i]);
                        i++;
                        break;

                    case "PurchasePrice":
                        system.PurchasePrice = decimal.Parse(lines[i], CultureInfo.InvariantCulture);
                        i++;
                        break;

                    case "ScrapPrice":
                        system.ScrapPrice = decimal.Parse(lines[i], CultureInfo.InvariantCulture);
                        i++;
                        break;

                    case "SellingPrice":
                        system.SellingPrice = decimal.Parse(lines[i], CultureInfo.InvariantCulture);
                        i++;
                        break;

                    case "DayTypeDistributions":
                        {
                            var parts = lines[i].Split(',').Select(p => decimal.Parse(p.Trim(), CultureInfo.InvariantCulture)).ToArray();

                            system.DayTypeDistributions = new List<DayTypeDistribution>
                            {
                                new DayTypeDistribution { DayType = Enums.DayType.Good, Probability = parts[0] },
                                new DayTypeDistribution { DayType = Enums.DayType.Fair, Probability = parts[1] },
                                new DayTypeDistribution { DayType = Enums.DayType.Poor, Probability = parts[2] }
                            };

                            int cumulative = 0;
                            foreach (var dist in system.DayTypeDistributions)
                            {
                                dist.MinRange = cumulative + 1;
                                cumulative += (int)(dist.Probability * 100);
                                dist.CummProbability = cumulative;
                                dist.MaxRange = cumulative;
                            }

                            i++;
                        }
                        break;

                    case "DemandDistributions":
                        system.DemandDistributions = new List<DemandDistribution>();
                        i++;

                        while (i < lines.Count && !IsConfigKey(lines[i]))
                        {
                            var parts = lines[i].Split(',').Select(p => p.Trim()).ToArray();

                            var demand = int.Parse(parts[0]);
                            var goodProb = decimal.Parse(parts[1], CultureInfo.InvariantCulture);
                            var fairProb = decimal.Parse(parts[2], CultureInfo.InvariantCulture);
                            var poorProb = decimal.Parse(parts[3], CultureInfo.InvariantCulture);

                            var demandDist = new DemandDistribution
                            {
                                Demand = demand,
                                DayTypeDistributions = new List<DayTypeDistribution>
                                {
                                    new DayTypeDistribution { DayType = Enums.DayType.Good, Probability = goodProb },
                                    new DayTypeDistribution { DayType = Enums.DayType.Fair, Probability = fairProb },
                                    new DayTypeDistribution { DayType = Enums.DayType.Poor, Probability = poorProb }
                                }
                            };
                            int cumulative = 0;
                            foreach (var dist in demandDist.DayTypeDistributions)
                            {
                                dist.MinRange = cumulative + 1;
                                cumulative += (int)(dist.Probability * 100);
                                dist.CummProbability = cumulative;
                                dist.MaxRange = cumulative;
                            }

                            system.DemandDistributions.Add(demandDist);
                            i++;
                        }
                        break;

                    default:
                        i++;
                        break;
                }
            }

            system.UnitProfit = system.SellingPrice - system.PurchasePrice;
            system.runSimulation();
        }
        private bool IsConfigKey(string line)
        {
            string[] keys = {
            "NumOfNewspapers",
            "NumOfRecords",
            "PurchasePrice",
            "ScrapPrice",
            "SellingPrice",
            "DayTypeDistributions",
            "DemandDistributions"
        };
            return keys.Contains(line);
        }
    }
}
