using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    class Roulette
    {
        static void Main(string[] args)
        {
            string[] rouletteNumbers = new string[38];
            string[] rouletteColors = new string[38] {"green", "red", "black", "red", "black", "red", "black", "red", "black", "red", "black", "black", "red", "black",
            "red", "black", "red", "black", "red", "red", "black", "red", "black", "red", "black", "red", "black","red", "black", "black", "red", "black", "red","black",
            "red", "black", "red", "green"};
            int gameFinish = 0;
            Random r = new Random();
            RouletteBets rb = new RouletteBets();

            for (int i = 0; i < rouletteNumbers.Length; i++)
            {
                if (i == 37)
                {
                    rouletteNumbers[i] = "00";
                }
                else
                {
                    rouletteNumbers[i] = i.ToString();
                }
            }

            do
            {
                Console.WriteLine("Welcome to Roulette table at my casino! Please enter a follwing menu option to play!\n1.Spin the wheel and see all possible winning bets!\n2.Exit the Program");
                string check = Console.ReadLine();
                int x;
                int spotIndex = r.Next(0, 38);
                string landingSpot = rouletteNumbers[spotIndex];
                while (Int32.TryParse(check, out x) == false || x != 1 && x != 2)
                {
                    Console.WriteLine("Please enter a valid menu option!");
                    check = Console.ReadLine();
                }
                switch (x)
                {
                    case 1:
                        Console.WriteLine($"The ball has landed on number {landingSpot}.");
                        Console.WriteLine($"1. The winning number bet was {landingSpot}.");
                        Console.WriteLine($"2. {rb.evenOddBet(rouletteNumbers,spotIndex)}");
                        Console.WriteLine($"3. The winning color bet is {rb.colorBet(rouletteColors, spotIndex)}.");
                        Console.WriteLine($"4. {rb.lowHighBet(rouletteNumbers, spotIndex)}");
                        Console.WriteLine($"5. {rb.dozenBet(rouletteNumbers, spotIndex)}");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        gameFinish++;
                        break;
                }
            } while (gameFinish != 1);

            Console.WriteLine("Thanks for playing roulette at my casino!");





        }
    }
}


    
