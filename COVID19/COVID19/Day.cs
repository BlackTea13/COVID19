using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19
{
    class Day
    {
        string date;

        int newCases;
        int newDeaths;
        double newCasesPerMil;
        double newDeathsPerMil;

        //constructor
        public Day(string date, int newCases, int newDeaths, double newCasesPerMil, double newDeathsPerMil)
        {
            this.date = date;
            this.newCases = newCases;
            this.newDeaths = newDeaths;
            this.newCasesPerMil = newCasesPerMil;
            this.newDeathsPerMil = newDeathsPerMil;
        }
    }
}
