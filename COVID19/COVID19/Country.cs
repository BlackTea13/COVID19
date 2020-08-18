using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID19
{
    class Country
    {
        readonly string country_name;
        static int totalDeaths;
        static int totalDeathsPerMil;
        List<Day> Days = new List<Day>();

        //constructor
        public Country(string country_name, List<Day> listofdays)
        {
            this.country_name = country_name;
            Days = listofdays;
        }

        public Country(string countryName)
        {
            country_name = countryName;
        }

        public void addDay(Day day)
        {
            Days.Add(day);
        }

    }
}
