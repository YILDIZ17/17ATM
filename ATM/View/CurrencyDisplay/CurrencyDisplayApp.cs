using ATM.Bll;

namespace ATM.View
{
    public class CurrencyDisplayApp : ICurrencyDisplayApp
    {
        readonly CurrencyConvertBll currencyConvert = new();

        public void DisplayCurrency()
        {
            Console.WriteLine($"\tThe current exchange rates are as follows : ");
            Console.WriteLine();
            Console.WriteLine($"\t1€ = {currencyConvert.Convert("€", 1)}€ [EUR]"); // Euro
            Console.WriteLine($"\t1€ = {currencyConvert.Convert("₺", 1)}₺ [TRY]"); // Turkish lira
            Console.WriteLine($"\t1€ = {currencyConvert.Convert("$", 1)}$ [USD]"); // Dollar
            Console.WriteLine($"\t1€ = {currencyConvert.Convert("kr", 1)}kr [NOK]"); // Norwegian krone
            Console.WriteLine($"\t1€ = {currencyConvert.Convert("£", 1)}£ [GBP]"); // Pound
            Console.WriteLine();
        }
    }
}
