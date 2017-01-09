using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CMPE1600ReviewLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            double originalAmount;                   //Holds the users input
            double [] doubleArray = new double[9];   //Double array that holds all normalized values in double form
            
            //Asks for user input and determines if any errors are present
            originalAmount = AskUser();

            //Normalizes user input
            doubleArray = Normalize(originalAmount);

            //Displays normalized currency
            DisplayConsole(doubleArray);

            //Pauses program for user to read output
            Console.ReadKey();
        }
        ///////////////////////////////////////Methods\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //Method to ask user for currency and rounds to two decimal places
        public static double AskUser()
        {
            //Variables
            double userInput;        //Holds users inputted currency
            bool error = false;      //Error flag
            //Asks user for input and rounds value or rejects if not valid
            do
            {
                Console.Write("Please enter the amount of currency you wish to normalize in Canadian dollars: ");


                if (double.TryParse(Console.ReadLine(), out userInput))
                {
                    Console.WriteLine("User entry of {0} interpreted and rounded to {1}", userInput, Math.Round(userInput,2));
                    error = false;
                }
                else
                {
                    Console.WriteLine("\nAn invalid value was detected. Please try again by pressing any key...");
                    Console.ReadKey();
                    Console.Clear();
                    error = true;
                }

            } while (error);
            //returns a rounded value to two decimal places
            return Math.Round(userInput, 2);
        }
        //Method that divides user input for currency by each bill or coin value from largest and draws the value on GDI drawer
        public static double [] Normalize(double originalValue)
        {
            double[] currencyArray = new double[9];
            double bill50 = 0, bill20 = 0, bill10 = 0, bill05 = 0, twoonies = 0, loonies = 0, quarters = 0, dimes = 0, nickels = 0;

            if(originalValue > 0.01)
            {
                if (originalValue >= 50.0)
                {
                    bill50 = originalValue / 50.0;
                    if (bill50 > 0)
                    {
                        originalValue = originalValue % 50.0;
                    }

                }
                if (originalValue >= 20.0)
                {
                    bill20 = originalValue / 20.0;
                    if (bill20 > 0.0)
                    {
                        originalValue = originalValue % 20.0;
                    }
                }
                if (originalValue >= 10.0)
                {
                    bill10 = originalValue / 10.0;
                    if (bill10 > 0)
                    {
                        originalValue = originalValue % 10.0;
                    }
                }
                if (originalValue >= 5)
                {
                    bill05 = (originalValue / 5.0);
                    if (bill05 > 0.0)
                    {
                        originalValue = originalValue % 5.0;
                    }
                }
                if (originalValue >= 2.0)
                {
                    twoonies = (originalValue / 2.0);
                    if (twoonies > 0.0)
                    {
                        originalValue = originalValue % 2.0;
                    }
                }
                if (originalValue >= 1.0)
                {
                    loonies = (originalValue / 1.0);
                    if (loonies > 0)
                    {
                        originalValue = originalValue % 1;
                    }
                }
                if (originalValue >= 0.25)
                {
                    quarters = (originalValue / 0.25);
                    if (quarters > 0)
                    {
                        originalValue = originalValue % 0.25;
                    }
                }
                if (originalValue > 0.10)
                {
                    dimes = (originalValue / 0.10);
                    if (dimes > 0)
                    {
                        originalValue = originalValue % 0.10;
                    }
                }
                if (originalValue > 0.05)
                {
                    nickels = (originalValue / 0.05);
                    if (nickels > 0)
                    {
                        originalValue = originalValue % 0.05;
                    }
                }
            }
            else
            {
                Console.WriteLine("The given currecny cannot be normalized beyond the given value.");
            }
            currencyArray = new double [] {Math.Truncate(bill50), Math.Truncate(bill20), Math.Truncate(bill10), Math.Truncate(bill05), Math.Truncate(twoonies), Math.Truncate(loonies), Math.Truncate(quarters), Math.Truncate(dimes), Math.Truncate(nickels)};

            return currencyArray;


        }
        public static void DisplayConsole(double [] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine((array[i]));
            }
        }
        
    }
}
