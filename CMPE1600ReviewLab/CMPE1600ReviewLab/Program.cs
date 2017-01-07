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
            double originalAmount;

            //Asks for user input and determines if any errors are present
            originalAmount = AskUser();

            //Normalizes user input
            Normalize(originalAmount);

            //Pauses program for user to read output
            Console.ReadKey();
        }
        //Methods

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
        public static void Normalize(double originalValue)
        {
            int numFifty;
            int numTwenty;
            int numTen;
            int numFive;
            int numTwo;
            int numOne;
            int numQuarter;
            int numDime;
            int numNickel;
        }
    }
}
