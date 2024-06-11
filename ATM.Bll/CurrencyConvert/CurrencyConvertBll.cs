namespace ATM.Bll
{
    public class CurrencyConvertBll : ICurrencyConvertBll // Class to convert the withdrawal to the currency chosen
    {
        private readonly Dictionary<string, double> _exchangeRate = new() // Dictionary with the different currencies and their exchange rate
        {
            {"₺", 33.8}, // Turkish lira
            {"$", 1.7 }, // Dollar
            {"kr", 17.99 }, // Norwegian krone
            {"£", 0.99 }, // Pound
            {"€", 1.0 } // Euro
        };

        public double Convert(string currency, double amount) // Method to convert the withdrawal
        {
            return amount * _exchangeRate[currency]; // We multiply the amount by the exchange rate of the currency chosen
        }
    }
}
