using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EveryFan.Recruitment.UnitTests;

namespace ConsoleApplication
{
    class Program
    {
        // HON LEE 
        // 10/3/2015

        static void Main(string[] args)
        {
            Console.ReadLine();

            EveryFan.Recruitment.UnitTests.WinnerTakesAllPayoutCalculatorTests WinnerTakesAllPayoutCalculatorTests = new EveryFan.Recruitment.UnitTests.WinnerTakesAllPayoutCalculatorTests();
            WinnerTakesAllPayoutCalculatorTests.TwoEntries();
            WinnerTakesAllPayoutCalculatorTests.ThreeEntries();
            WinnerTakesAllPayoutCalculatorTests.SplitWinnings();

            EveryFan.Recruitment.UnitTests.FiftyFiftyPayoutCalculatorTests FiftyFiftyPayoutCalculatorTests = new FiftyFiftyPayoutCalculatorTests();
            FiftyFiftyPayoutCalculatorTests.TwoEntries();
            FiftyFiftyPayoutCalculatorTests.ThreeEntries();
            //FiftyFiftyPayoutCalculatorTests.OddSplitWinnings();
            FiftyFiftyPayoutCalculatorTests.SplitWinnings();
        }
    }
}
