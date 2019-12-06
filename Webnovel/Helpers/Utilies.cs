﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Webnovel.Helpers
{
    public static class Utilities
    {
        public static string ConvertDaysToMonthYear(int days)
        {
            
            if (days <= 30)
            {
                return days.ToString() + " Days";
            }
            //
            if (days > 30)
            {
                // cal month 
                int month = days / 30; 
                return month.ToString() + " Month(s)";

            }

            
            // convert to year 
            int years = days / 365;
            return years.ToString() + " Month(s)";

        }

        public static double  CalculateDaysRemainingFromToday(DateTime datetime)
        {
            var today = DateTime.UtcNow;
            var days = datetime.Subtract(today).TotalDays;
           return  Math.Round(days) ;
        }
    }

    public static class AppUtilities
    {
        public static double CalculateCowries(double amountUsd)
        {
            //o.o5 usd = 1 cr 
            //cr = usd/0.05  
           return (amountUsd / 0.05);
        } 

        public static double CalculateUsd(double cowries)
        {
            //o.o5 usd = 1 cr 
            //cr = usd/0.05  
           
            return (cowries * 0.05);

        }

        public static double CalculateCowriesToSpendOnWords(int words)
        {
            //10 cowries = 500 words 
            //0.02 cowries = 1 word 
            return  0.02 * words;
        }
        
    }
}
