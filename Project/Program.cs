// Noah Pascual
// MIS 3013 995
// Makeup Assignment


using System;
using System.Collections.Generic;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {

            // Main Method Variables.
            double creditScore;      
            bool isNum = false;
            double autoPrice = 0;
            double tradeInValue = 0;
            double downPayment = 0;

            // static void DisplayHeader().
            DisplayHeader();

            Console.WriteLine("Please enter your current credit score >>>");
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out creditScore))
                {
                    double interestRate = CalculateInterestRate(creditScore);

                    // Prompt for automobile amount and fact check.
                    isNum = false;
                    while (!isNum)
                    {
                        Console.WriteLine("\nWhat is the price of the automobile that you would like to purchase today? >>>");
                        isNum = double.TryParse(Console.ReadLine(), out autoPrice);
                    }

                    // Prompt for trade in value and fact check.
                    isNum = false;
                    while (!isNum)
                    {
                        Console.WriteLine("\nWill you be trading in an old vehicle? >>>\n" +
                            "\t<<< If yes, enter the amount your trade in was appraised for. >>> \n" +
                            "\t<<< If not, simply enter 0. >>>");
                        isNum = double.TryParse(Console.ReadLine(), out tradeInValue);
                    }

                    // Ask the user if they will be putting a down payment.
                    isNum = false;
                    while (!isNum)
                    {
                        Console.WriteLine("\n How much of a downpayment will you be putting down? >>>");
                        isNum = double.TryParse(Console.ReadLine(), out downPayment);
                    }

                    DisplayResults1(creditScore, autoPrice, tradeInValue, interestRate, downPayment);
                    DisplayResults2(creditScore, autoPrice, tradeInValue, interestRate, downPayment);

                    break;
                } 
                else
                {
                    // Invalid creidt score output.
                    Console.WriteLine("That is an invalid credit score. Please enter your credit score: >>>");
                }
            }

            string goodbye = "!!! Enjoy your new ride !!!";
            Console.SetCursorPosition((Console.WindowWidth - goodbye.Length) / 2, Console.CursorTop);
            Console.WriteLine($"{goodbye}");

            Console.WriteLine("Press any button to exit. >>>");

            Console.ReadKey();
        }

        private static void DisplayResults(double creditScore, double autoPrice)
        {
            throw new NotImplementedException();
        }

        private static double CalculateInterestRate(double creditScore)
        {
            // FederalTax Variables.
            double interestRatePercentage;

            //Tax rate Taxable income bracket.
            if (creditScore >= 850)
            {
                interestRatePercentage = 0.02;
            }
            else if (creditScore >= 800)
            {
                interestRatePercentage = 0.04;
            }
            else if (creditScore >= 750)
            {
                interestRatePercentage = 0.06;
            }
            else if (creditScore >= 700)
            {
                interestRatePercentage = 0.075;
            }
            else if (creditScore >= 650)
            {
                interestRatePercentage = 0.09;
            }
            else if (creditScore >= 600)
            {
                interestRatePercentage = 0.10;
            }
            else
            {
                interestRatePercentage = 0.125;
            }
            // Calculated Federal Tax for Main Method.
            return interestRatePercentage;
        }

        // Display Header (Main)
        static void DisplayHeader()
        {
            string title = "--- Noah's Autoloan and Finance Center (Makeup Assignment) ---\n\r";
            Console.SetCursorPosition((Console.WindowWidth - title.Length) / 2, Console.CursorTop);
            Console.WriteLine(title);
        }

        // Results One: With the customers credit score, intrest rate (based on credit), vehicle price, their trade in, and their total (without intrest rate).
        private static void DisplayResults1(double creditScore, double autoPrice, double tradeInValue, double interestRate, double downPayment)
        {
            Console.WriteLine($"\t Current Credit Score:                {creditScore}");
            Console.WriteLine($"\t Intrest Rate based on Credit:        {interestRate}");
            Console.WriteLine($"\t Vehcile List Price (+):              {autoPrice:C2}");
            Console.WriteLine($"\t Trade In Dealership Appraisal (-):   {tradeInValue:C2}");
            Console.WriteLine($"\t Customer Down Payment (-):           {downPayment:C2}");
            Console.WriteLine($"\t Vehicle New Price With Trade (=):    {autoPrice - downPayment - tradeInValue:C2}\n\r");
        }

        // Results Two: Provides accumulated cost and monthly payments.
        private static void DisplayResults2(double creditScore, double autoPrice, double tradeInValue, double interestRate, double downPayment)
        {
            PaymentTermLength customer = new PaymentTermLength();

            // Payoff Variables
            double balance = autoPrice - tradeInValue - downPayment;
            double monthlyRate = interestRate / 12;

            // Monthly Payment Calculations 
            double Month12 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.TwelveMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.TwelveMonthPayOff()) - 1);
            double Month24 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.TwentyFourMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.TwentyFourMonthPayOff()) - 1);
            double Month36 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.ThirtySixMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.ThirtySixMonthPayOff()) - 1);
            double Month48 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.FourtyEightMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.FourtyEightMonthPayOff()) - 1);
            double Month60 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.SixtyMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.SixtyMonthPayOff()) - 1);
            double Month72 = balance * (monthlyRate * Math.Pow(1 + monthlyRate, customer.SeventyTwoMonthPayOff())) / (Math.Pow(1 + monthlyRate, customer.SeventyTwoMonthPayOff()) - 1);

            // Total Cost of Vehicle.
            double accumulated1Year = Month12 * 12;
            double accumulated2Year = Month24 * 24;
            double accumulated3Year = Month36 * 36;
            double accumulated4Year = Month48 * 48;
            double accumulated5Year = Month60 * 60;
            double accumulated6Year = Month72 * 72;

            string title1 = "--- Noah's AutoCenter consists of 5 different loan terms ---";
            Console.SetCursorPosition((Console.WindowWidth - title1.Length) / 2, Console.CursorTop);
            Console.WriteLine($"{title1}");

            string title2 = "Below is your accumulated cost for your vehcile along with the montly payments:";
            Console.SetCursorPosition((Console.WindowWidth - title2.Length) / 2, Console.CursorTop);
            Console.WriteLine($"{title2}");
            
            // Display Method that shows Monthly payment cost and total accumulated costs.
            Console.WriteLine($"\t 12 Month Payoff Total: {accumulated1Year:C2} \tMonthly payments will be: {Month12:C2}");
            Console.WriteLine($"\t 24 Month Payoff Total: {accumulated2Year:C2} \tMonthly payments will be: {Month24:C2}");
            Console.WriteLine($"\t 36 Month Payoff Total: {accumulated3Year:C2} \tMonthly payments will be: {Month36:C2}");
            Console.WriteLine($"\t 48 Month Payoff Total: {accumulated4Year:C2} \tMonthly payments will be: {Month48:C2}");
            Console.WriteLine($"\t 60 Month Payoff Total: {accumulated5Year:C2} \tMonthly payments will be: {Month60:C2}");
            Console.WriteLine($"\t 72 Month Payoff Total: {accumulated6Year:C2} \tMonthly payments will be: {Month72:C2}\n\r");
        }

    }
}
