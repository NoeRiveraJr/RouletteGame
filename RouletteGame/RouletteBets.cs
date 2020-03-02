using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    class RouletteBets
    {
        public string evenOddBet(string[] rouletteNumber, int spotIndex)
        {
            string oddOrEven;
            if (spotIndex == 0)
            {
                oddOrEven = "0 is not odd or even, neither is a winning bet.";
            }
            else if (spotIndex==37)
            {
                oddOrEven = "00 is not odd or even, neither is a winning bet.";
            }
            else
            {
                if(Int32.Parse(rouletteNumber[spotIndex]) % 2 == 0)
                {
                    oddOrEven = ($"The winning bet is even because the number {rouletteNumber[spotIndex]} is even.");
                }
                else
                {
                    oddOrEven = ($"The winning bet is odd because the number {rouletteNumber[spotIndex]} is odd.");
                }
            }
            return oddOrEven;
        }

        public string colorBet(string[] rouletteColors, int spotIndex)
        {
            string color = rouletteColors[spotIndex];
            return color;
        }

        public string lowHighBet(string[] rouletteNumbers, int spotIndex)
        {
            string lowOrHigh;
            if (spotIndex == 0)
            {
                lowOrHigh = "0 is not a low or high number, neither is a winning bet.";
            }
            else if (spotIndex == 37)
            {
                lowOrHigh = "00 is not a low or high number, niether is a winning bet.";
            }
            else
            {
                if(Int32.Parse(rouletteNumbers[spotIndex]) > 0 && Int32.Parse(rouletteNumbers[spotIndex]) <= 18)
                {
                   lowOrHigh = ($"The winning bet is a low number because {rouletteNumbers[spotIndex]} is between 1 - 18.");
                }
                else
                {
                    lowOrHigh = ($"The winning bet is a high number because {rouletteNumbers[spotIndex]} is between 19 - 36.");
                }
            }
            return lowOrHigh;
        }

        public string dozenBet(string[] rouletteNumbers, int spotIndex)
        {
            string dozenPlace;
            if (spotIndex == 0)
            {
               dozenPlace = "0 does not fall in a dozen, neither would be a winning bet.";
            }
            else if (spotIndex == 37)
            {
                dozenPlace = "00 does not fall in a dozen, neither would be a winning bet.";
            }
            else
            {
                if (Int32.Parse(rouletteNumbers[spotIndex]) > 0 && Int32.Parse(rouletteNumbers[spotIndex]) <= 12)
                {
                    dozenPlace = ($"The winning bet is the first dozen because {rouletteNumbers[spotIndex]} is between 1 - 12.");
                }
                else if (Int32.Parse(rouletteNumbers[spotIndex]) > 12 && Int32.Parse(rouletteNumbers[spotIndex]) <= 24)
                {
                    dozenPlace = ($"The winning bet is the second dozen because {rouletteNumbers[spotIndex]} is between 13 - 24.");
                }
                else
                {
                    dozenPlace = ($"The winning bet is the third dozen because {rouletteNumbers[spotIndex]} is between 25 - 36.");
                }
            }
            return dozenPlace;
        }
    }

    
}
