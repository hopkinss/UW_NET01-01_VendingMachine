using Microsoft.Extensions.Configuration;
using System;
using System.Text;

namespace VendingMachine
{
    class Program
    {

        static void Main(string[] args)
        {
            // Access app configuration from appsettings.json
            var config = Settings().Build();

            var paymentProcessor = new PaymentProcessor(int.Parse(config["CostOfSoda"]));

            Console.WriteLine("Welcome to the .NET Soda vending machine");
            Console.Write($"Please insert {paymentProcessor.CostOfSoda} cents: ");
   
            while (!paymentProcessor.IsAmountSufficient())
            {
                try
                {
                    paymentProcessor.GetEnteredAmount(Console.ReadLine());
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                Console.Write($"You have inserted {paymentProcessor.AmountSpent} cents\n");

                if (!paymentProcessor.IsAmountSufficient())
                    Console.Write($"Please deposit {paymentProcessor.Balance()} cents more to purchase the soda: ");
            }

            var msg = paymentProcessor.Balance() < 0 ? $"and {Math.Abs(paymentProcessor.Balance())} cents change" : string.Empty;
            Console.WriteLine($"Thanks. Here is your soda {msg}");
        }


        public static IConfigurationBuilder Settings()
        { 
            var configBuilder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            return configBuilder;
        }


    }
}

