/* Project:         Assignment Set 6 - Program 14
 * Date:            October 2020
 * Developed By:    LV
 * Class Name:      StockAnalyzer
 * Modified By:     Christopher Karnas
 * Last Modified:   11.20.20
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIS605AS6
{
    class StockAnalyzer
    {
        #region "Properties"

        public string TickerSymbol { get; private set; }
        public decimal[] StockPrices { get; private set; }

        #endregion

        #region "Constructor"

        public StockAnalyzer(string symbol, decimal[] prices)
        {
            TickerSymbol = symbol;

            //StockPrices = new decimal[] { };

            StockPrices = prices;
        }

        #endregion

        #region "Methods"

        /* Complete this method to find and return the smallest percentage gain in price between any two consecutive trading days.
         * 
         *  The return value should be formatted to display with a % sign and 5 decimal places.
         *  
         *  Percentage change in price between two consecutive trading days (e.g., Days 1 and 2) =
         *  
         *        (Day 2 Price - Day 1 Price) / Day 1 Price
        */

        public string FindSmallestPercentageGainInPrice()
        {
            decimal currentMin = decimal.MaxValue;
            string output = $"No Gain in Price";

            for (int x=0; x < StockPrices.Length-1; ++x)
            {
                decimal change = (StockPrices[x + 1] - StockPrices[x]) / StockPrices[x];
                if (change > 0 && change < currentMin)
                {
                    currentMin = change;
                }
            }

            if (currentMin != Decimal.MaxValue)
            {
                output = $"{currentMin.ToString("p5")}";
            }

            return output;
        }

        // can we find the minimum without using a loop?
        //decimal[] sortedPrices = new decimal[StockPrices.Length];

        //StockPrices.CopyTo

        /* Complete this method to find and return the largest price change (either up or down) between any two consecutive trading days.  
         * 
         * Price change (either up or down) between two consecutive trading days (e.g., Days 1 and 2) =
         * 
         * Absolute value of (Day 2 Price - Day 1 Price) 
         */

        public decimal FindLargestPriceChange()
        {
            decimal currentMax = 0;

            for (int x = 0; x < StockPrices.Length - 1; ++x)
            {
                decimal change = Math.Abs(StockPrices[x + 1] - StockPrices[x]);
                if (change > 0 && change > currentMax)
                {
                    currentMax = change;
                }
            }
            return currentMax;
        }

        /* Complete this method to find and return the number of times there is a negative change in price between any two consecutive trading days.
         * 
         * There is a negative change in price between two consecutive trading days (e.g., Days 1 and 2), if Day 2 Price - Day 1 Price < 0
        */

        public int FindNumTimesNegativePriceChange()
        {
            int count = 0;

            for (int x = 0; x < StockPrices.Length - 1; ++x)
            {
                decimal change = StockPrices[x+1] - StockPrices[x];
                if (change < 0)
                {
                    ++count;
                }
            }
            return count;
        }

        /* Complete this method to find and return the longest period (in days) of continuous price gain.
         * 
         * There is a gain in price between two consecutive trading days (e.g., Days 1 and 2), if Day 2 Price - Day 1 Price > 0
        */



        //for loop with if inside
        //if else, nested if
        //reinitialize current streak back to zero


        public int FindLongestPriceGainStreak()
        {
            int currentStreak = 0;
            int longestStreak = 0;

            for (int x = 0; x < StockPrices.Length - 1; ++x)
            {
                decimal change = (StockPrices[x + 1] - StockPrices[x]);
                if (change > 0)
                {
                    ++currentStreak;
                }
                else
                {
                    currentStreak = 0;
                }
                if (currentStreak > longestStreak)
                {
                    longestStreak = currentStreak;
                }
            }
            return longestStreak;
        }
   
        #endregion
    }
}