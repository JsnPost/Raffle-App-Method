using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        private static Dictionary<int, string> guests = new Dictionary<int, string>();

        private static int min = 1000;

        private static int max = 9999;

        private static Random rdm = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestName();
            PrintWinner();
            Console.ReadLine();
        }


        static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string response = Console.ReadLine().ToLower();
            return response;
        }


        static void GetUserInfo()
        {
            string guestName = null;
            string anotherName = null;

            do
            {

                guestName = GetUserInput("enter guests name: ");

                while (guestName == "")
                {
                    guestName = GetUserInput("enter guest name: ");
                }

                int randomNumber = GenerateRandomNumber(min, max);

                //check number against keys in dictionary

                while (guests.Keys.Contains(randomNumber))
                {
                    randomNumber = GenerateRandomNumber(min, max);
                }

                guests.Add(randomNumber, guestName);

                anotherName = GetUserInput("Is there another guest to enter: ");

                /* Asks for guests name by calling method
                * generate / assigns random number
                * add to dictionary
                * asks if there is another guest to add
                * repeats until not yet
                */
            }

            while (Equals(anotherName, "yes"));

        }



        static int GenerateRandomNumber(int min, int max)

        {
            return rdm.Next(min, max);
        }

        static int GetRaffleNumber(Dictionary<int, string> raffleNumber)
        {
            List<int> newList = raffleNumber.Keys.ToList();
            int i = rdm.Next(newList.Count);
            int j = newList[i];
            return j;
        }

        static void PrintGuestName()
        {
            foreach (KeyValuePair<int, string> kvp in guests)
            {
                Console.WriteLine($"{kvp.Value} ==> {kvp.Key}");
            }
        }

        static void PrintWinner()
        {
            int k = GetRaffleNumber(guests);
            Console.WriteLine($"The winner is {guests[k]} {k}");
        }


        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
