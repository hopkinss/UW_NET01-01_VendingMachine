using System;

namespace VendingMachine
{
    public class VendingMachine
    {
        private int amountSpent;

        public VendingMachine(int costOfSoda,int amountSpent = 0)
        {
            CostOfSoda = costOfSoda;
            AmountSpent = amountSpent;
        }

        public int CostOfSoda { get; set; }

        public int AmountSpent
        {
            get => amountSpent; 
            set
            {
                amountSpent += value;
            }
        }

        public void GetEnteredAmount(string response)
        {

            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }
            
            var isInt = int.TryParse(response, out int amountSpent);

            if (!isInt)
            {
                throw new ArgumentException($"Argument '{response}' is not an integer\n");
            }

            if (isInt)
                this.amountSpent += amountSpent;

        }

        public bool IsAmountSufficient()
        {
            return this.AmountSpent >= this.CostOfSoda;
        }

        public int Balance()
        {
            return this.CostOfSoda - this.AmountSpent;
        }

    }
}

