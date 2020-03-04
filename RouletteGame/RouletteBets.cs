using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    class RouletteBets
    {
        int[] col1 = { 1, 4, 7, 10, 13, 16, 19, 22, 25, 28, 31, 34 };       //initialized 3 arrays to represent the columns to check for the winning column bet
        int[] col2 = { 2, 5, 8, 11, 14, 17, 20, 23, 26, 29, 32, 35 };
        int[] col3 = { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30, 33, 36 };
        int colCheck;
        public string evenOddBet(string[] rouletteNumber, int spotIndex)        //this method will determine if even or odd is the winning bet
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

        public string colorBet(string[] rouletteColors, int spotIndex)      //returns the color of a number using the rouletteColors array
        {
            string color = rouletteColors[spotIndex];
            return color;
        }

        public string lowHighBet(string[] rouletteNumbers, int spotIndex)       //checks whether the winning bet would be low or high(either 1-18/19-36)
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

        public string dozenBet(string[] rouletteNumbers, int spotIndex)     //determines what dozen the numbers falls in(1-12/13-24/25-36)
        {
            string dozenPlace;
            if (spotIndex == 0)
            {
               dozenPlace = "0 does not fall in a dozen, neither dozen is a winning bet.";
            }
            else if (spotIndex == 37)
            {
                dozenPlace = "00 does not fall in a dozen, neither dozen is a winning bet.";
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

        public string columnBet(string[] rouletteNumbers, int spotIndex)        //determines what column the number is located in using the arrays declared at the top of the class
        {
            string colBet = "";
            if (spotIndex == 0)
            {
               colBet = "0 does not fall in a column, neither column is a winning bet.";
            }
            else if (spotIndex == 37)
            {
                colBet = "00 does not fall in a column, neither column is a winning bet.";
            }
            else
            {
                for (int i = 0; i < col1.Length;i++)
                {
                    if(Int32.Parse(rouletteNumbers[spotIndex]) == col1[i])
                    {
                        colBet = ("The winning bet is the first column.");
                        this.colCheck = 1;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                for (int i = 0; i < col2.Length; i++)
                {
                    if (Int32.Parse(rouletteNumbers[spotIndex]) == col2[i])
                    {
                        colBet = ("The winning bet is the second column.");
                        this.colCheck = 2;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                for (int i = 0; i < col3.Length; i++)
                {
                    if (Int32.Parse(rouletteNumbers[spotIndex]) == col3[i])
                    {
                        colBet = ("The winning bet is the third column.");
                        this.colCheck = 3;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
           return colBet;
        }

        public string streetBet(string[] rouletteNumbers, int spotIndex)        //determines what street the number is located in(Ex: the number 2 is in street 1/2/3)
        {
            string sBet = "";
            if (spotIndex == 0)
            {
                sBet = "0 does not fall in a street, no street is a winning bet.";
            }
            else if (spotIndex == 37)
            {
                sBet = "00 does not fall in a street, no street is a winning bet.";
            }
            else
            {
                switch (colCheck)
                {
                    case 1:
                        sBet = ($"The winning street bet is {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}");
                        break;
                    case 2:
                        sBet = ($"The winning street bet is {rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}");
                        break;
                    case 3:
                        sBet = ($"The winning street bet is {rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}");
                        break;
                }
            }
           return sBet;
        }

        public string doubleRowBet(string[] rouletteNumbers, int spotIndex)     //determines which double rows the number is located in
        {
            string dBet = "";
            if (spotIndex == 0)
            {
                dBet = "0 does not fall in a double row, no double row is a winning bet.";
            }
            else if (spotIndex == 37)
            {
                dBet = "00 does not fall in a double row, no double row is a winning bet.";
            }
            else
            {
                switch (colCheck)
                {
                    case 1:
                        if (spotIndex == 1)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}/" +
                                    $"{rouletteNumbers[spotIndex + 3]}/{rouletteNumbers[spotIndex + 4]}/{rouletteNumbers[spotIndex + 5]}");
                        }
                        else if (spotIndex == 34)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/" +
                                    $"{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}");
                        }
                        else
                        {
                            dBet = ($"The winning double row bets are {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}/" +
                                    $"{rouletteNumbers[spotIndex + 3]}/{rouletteNumbers[spotIndex + 4]}/{rouletteNumbers[spotIndex + 5]} and {rouletteNumbers[spotIndex - 3]}" +
                                    $"/{rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/" + 
                                    $"{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex+2]}");
                        }
                        break;
                    case 2:
                        if (spotIndex == 2)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/" +
                                    $"{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]}/{rouletteNumbers[spotIndex + 4]}");
                        }
                        else if (spotIndex == 35)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex - 2]}/" +
                                    $"{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}");
                        }
                        else
                        {
                            dBet = ($"The winning double row bets are {rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/" +
                                    $"{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]}/{rouletteNumbers[spotIndex + 4]} and {rouletteNumbers[spotIndex - 4]}/{ rouletteNumbers[spotIndex - 3]}" +
                                    $"/{ rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}");
                        }
                        break;
                    case 3:
                        if (spotIndex == 3)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/" +
                                    $"{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]}");
                        }
                        else if (spotIndex == 36)
                        {
                            dBet = ($"The winning double row bet is {rouletteNumbers[spotIndex - 5]}/{rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/" +
                                    $"{rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}");
                        }
                        else
                        {
                            dBet = ($"The winning double row bets are {rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}/" +
                                    $"{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]} and {rouletteNumbers[spotIndex - 5]}/{rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/" +
                                    $"{rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]}");
                        }
                        break;
                }
            }
            return dBet;
        }

        public string splitBet(string[] rouletteNumbers, int spotIndex)     //determines all the split bets that the number could have(Ex. number 1 has the splits 1/2 and 1/4)
        {
            string spBet = "";
            if (spotIndex == 0)
            {
                spBet = "0 does not have any splits, there are no possible winning split bets";
            }
            else if (spotIndex == 37)
            {
                spBet = "00 does not have any splits, there are no possible winning split bets";
            }
            else
            {
                switch (colCheck)
                {
                    case 1:
                        if (spotIndex == 1)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]} and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+3]}");
                        }
                        else if (spotIndex == 34)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex-3]}/{rouletteNumbers[spotIndex]} and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}");
                        }
                        else
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+3]}");
                        }
                        break;
                    case 2:
                        if (spotIndex == 2)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+3]}");
                        }
                        else if (spotIndex == 35)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}");
                        }
                        else
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+3]}");
                        }
                        break;
                    case 3:
                        if (spotIndex == 3)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]} and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 3]}");
                        }
                        else if (spotIndex == 36)
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex - 1]}/{rouletteNumbers[spotIndex]} and {rouletteNumbers[spotIndex-3]}/{rouletteNumbers[spotIndex]}");
                        }
                        else
                        {
                            spBet = ($"The winning split bets are {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 3]}");
                        }
                        break;
                }

            }
                return spBet;
        }

        public string cornerBet(string[] rouletteNumbers, int spotIndex)        //determines what corners the number falls in(Ex.2 falls in corners 1/2/4/5 and 2/3/5/6)
        {
            string cBet = "";
            if (spotIndex == 0)
            {
                cBet = "0 does not fall in any corners, there are no possible winning corner bets";
            }
            else if (spotIndex == 37)
            {
                cBet = "00 does not fall in any corners, there are no possible winning corner bets";
            }
            else
            {
                switch (colCheck)
                {
                    case 1:
                        if (spotIndex == 1)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}/{rouletteNumbers[spotIndex + 3]}/{rouletteNumbers[spotIndex + 4]}");
                        }
                        else if (spotIndex == 34)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex - 2]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}");
                        }
                        else
                        {
                            cBet = ($"The winning corner bets are {rouletteNumbers[spotIndex-3]}/{rouletteNumbers[spotIndex-2]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]} and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}/{rouletteNumbers[spotIndex+3]}/{rouletteNumbers[spotIndex+4]}");
                        }
                        break;
                    case 2:
                        if (spotIndex == 2)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]} and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}/{rouletteNumbers[spotIndex+3]}/{rouletteNumbers[spotIndex+4]}");
                        }
                        else if (spotIndex == 35)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]} and {rouletteNumbers[spotIndex-3]}/{rouletteNumbers[spotIndex-2]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}");
                        }
                        else
                        {
                            cBet = ($"The winning corner bets are {rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}, {rouletteNumbers[spotIndex-3]}/{rouletteNumbers[spotIndex -2]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 1]}, {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+2]}/{rouletteNumbers[spotIndex+3]}, and {rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex+1]}/{rouletteNumbers[spotIndex+3]}/{rouletteNumbers[spotIndex+4]}");
                        }
                        break;
                    case 3:
                        if (spotIndex == 3)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]}");
                        }
                        else if (spotIndex == 36)
                        {
                            cBet = ($"The winning corner bet is {rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}");
                        }
                        else
                        {
                            cBet = ($"The winning corner bets are {rouletteNumbers[spotIndex - 4]}/{rouletteNumbers[spotIndex - 3]}/{rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]} and {rouletteNumbers[spotIndex-1]}/{rouletteNumbers[spotIndex]}/{rouletteNumbers[spotIndex + 2]}/{rouletteNumbers[spotIndex + 3]}");
                        }
                        break;
                }
            }
            return cBet;
        }
    }
}
