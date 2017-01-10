using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace CMPE1600ReviewLab
{
    class Program
    {
        static CDrawer drawSpace = new CDrawer();
        static void Main(string[] args)
        {
            //Variables
            double originalAmount;                   //Holds the users input
            double [] doubleArray = new double[9];   //Double array that holds all normalized values in double form
            string[] currencyArray = new string[9] { "$50", "$20", "$10", "$5", "$2", "$1", "$0.25", "0.10", "0.05" };
            //Asks for user input and determines if any errors are present
            originalAmount = AskUser();

            //Normalizes user input
            doubleArray = Normalize(originalAmount);

            //Displays normalized currency
            DisplayConsole(doubleArray, currencyArray);

            //Draws Currency on GDI drawer
            DrawCurrency(doubleArray, originalAmount);

            //Pauses program for user to read output
            Console.ReadKey();
        }
        ///////////////////////////////////////Methods\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        //Method to ask user for currency and rounds to two decimal places
        public static double AskUser()
        {
            //Variables
            double userInput;        //Holds users inputted currency
            string input = null;     //Holds string of user input for adjustment if symbols are present
            bool error = false;      //Error flag

            //Asks user for input and rounds value or rejects if not valid
            do
            {
                Console.Write("Please enter the amount of currency you wish to normalize in Canadian dollars: ");
                foreach (char item in Console.ReadLine())
                {
                    if (char.IsDigit(item)|| item == '.')
                    {
                        input += item;
                    }
                    
                }

                
                
                if (double.TryParse(input, out userInput))
                {
                    userInput = (Math.Round(userInput * 100) * 5 / 5) / 100;
                    
                    Console.WriteLine("User entry of {0} interpreted and rounded to {1:C}", input, userInput);
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
                if (originalValue >= 0.049)
                {
                    nickels = (originalValue / 0.049);
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
        public static void DisplayConsole(double [] array, string [] cArray)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("{0} x {1}", cArray[i].ToString(), array[i]);
            }
        }
        public static void DrawCurrency(double [] array, double originalValue)
        {
            drawSpace.AddText("$" + originalValue.ToString(), 20, 325, 20, 150, 50, Color.Yellow);
            if (array[0] > 0)
            {
                drawSpace.AddRectangle(100, 100, 175, 75, Color.PaleVioletRed, 2, Color.Gray);
                drawSpace.AddText("$50 x " + array[0].ToString(), 10, 145, 100, 75, 75, Color.Black);
            }
            if (array[1] > 0)
            {
                drawSpace.AddRectangle(100, 200, 175, 75, Color.LawnGreen, 2, Color.Gray);
                drawSpace.AddText("$20 x " + array[1].ToString(), 10, 145, 200, 75, 75, Color.Black);
            }
            if (array[2] > 0)
            {
                drawSpace.AddRectangle(100, 300, 175, 75, Color.MediumPurple, 2, Color.Gray);
                drawSpace.AddText("$10 x " + array[2].ToString(), 10, 145, 300, 75, 75, Color.Black);
            }
            if(array[3] > 0)
            {
                drawSpace.AddRectangle(100, 400, 175, 75, Color.AliceBlue, 2, Color.Gray);
                drawSpace.AddText("$5 x " + array[3].ToString(), 10, 145, 400, 75, 75, Color.Black);
            }
            if (array[4] > 0)
            {
                drawSpace.AddEllipse(400, 100, 57, 57, Color.Silver, 2, Color.Gray);
                drawSpace.AddText("$2 x " + array[4].ToString(), 10, 390, 90, 75, 75, Color.Black);
            }
            if (array[5] > 0)
            {
                drawSpace.AddEllipse(400, 160, 57, 57, Color.Gold, 2, Color.Gray);
                drawSpace.AddText("$1 x " + array[5].ToString(), 10, 390, 150, 75, 75, Color.Black);
            }
            if(array[6] > 0)
            {
                drawSpace.AddEllipse(400, 220, 57, 57, Color.Silver, 2, Color.Gray);
                drawSpace.AddText("$0.25 x " + array[6].ToString(), 10, 390, 210, 75, 75, Color.Black);
            }
            if(array[7] > 0)
            {
                drawSpace.AddEllipse(400, 280, 57, 57, Color.Silver, 2, Color.Gray);
                drawSpace.AddText("$0.10 x " + array[7].ToString(), 10, 390, 270, 75, 75, Color.Black);
            }
            if(array[8] > 0)
            {
                drawSpace.AddEllipse(400, 340, 57, 57, Color.Silver, 2, Color.Gray);
                drawSpace.AddText("$0.05 x " + array[8].ToString(), 10, 390, 330, 75, 75, Color.Black);
            }
            
        }
    }
}
