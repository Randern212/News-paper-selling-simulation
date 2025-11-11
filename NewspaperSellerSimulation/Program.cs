using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewspaperSellerModels;
using NewspaperSellerTesting;

namespace NewspaperSellerSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SimulationSystem system=new SimulationSystem();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


            List<string> testCaseNames = new List<string> { Constants.FileNames.TestCase1, Constants.FileNames.TestCase2, Constants.FileNames.TestCase3 }; ;
            foreach(string testCase in testCaseNames)
            {
                string result = TestingManager.Test(system, testCase);
                MessageBox.Show(result);
            }
        }
    }
}
