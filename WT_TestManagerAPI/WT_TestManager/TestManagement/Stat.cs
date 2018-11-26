using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement
{
    public class Stat
    {
        public int personalGuessCount;
        public int otherGuessCount;
        public double personalAverage;
        public double otherAverage;
        public string bestGuesser;
        public double otherHighestResult;
        public double personalHighestResult;

        public Stat(int personalGuessCount, int otherGuessCount, 
            double personalAverage, double otherAverage, string bestGuesser,
            double otherHighestResult, double personalHighestResult)
        {
            this.personalGuessCount = personalGuessCount;
            this.otherGuessCount = otherGuessCount;
            this.personalAverage = personalAverage;
            this.otherAverage = otherAverage;
            this.bestGuesser = bestGuesser;
            this.otherHighestResult = otherHighestResult;
            this.personalHighestResult = personalHighestResult;
        }
    }
}