namespace ATM.Bll
{
    public class GetCurrencyFromCodeBll : IGetCurrencyFromCodeBll // Class to get the currency from the code
    {
        public string GetCurrencyFromCode(string currencyCode) // Method to get the currency from the code
        {
            string currency;
            switch (currencyCode) // Switch to get the currency from the code
            {
                case "1":
                    currency = "₺"; // Turkish lira
                    break;
                case "2":
                    currency = "$"; // Dollar
                    break;
                case "3":
                    currency = "kr"; // Norwegian krone
                    break;
                case "4":
                    currency = "£"; // Pound
                    break;
                case "5":
                    currency = "€"; // Euro
                    break;
                default:
                    currency = "false";
                    break;
            }
            return currency;
        }
    }
}
