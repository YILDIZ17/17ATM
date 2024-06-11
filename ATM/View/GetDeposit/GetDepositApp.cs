using ATM.Bll;
using ATM.Model;

namespace ATM.View
{
    public class GetDepositApp(
        IDepositBll depositBll,
        IGetCurrencyFromCodeBll getCurrencyFromCodeBll
            ) : IGetDepositApp // Class to make a deposit
    {
        private readonly ICurrencyDisplayApp _currencyDisplayApp = new CurrencyDisplayApp();
        private readonly IDepositBll _depositBll = depositBll;
        private readonly IGetCurrencyFromCodeBll _getCurrencyFromCodeBll = getCurrencyFromCodeBll;

        public void GetDeposit(UserInfo userInfo) // Method to get the deposit
        {
            Console.WriteLine();
            Console.WriteLine("You have chosen to make a deposit.");
            Console.WriteLine();
            _currencyDisplayApp.DisplayCurrency(); // We display the current exchange rates
            Console.Write("\tPlease enter the amount to deposit : ");
            double depositAmount = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\tPlease choose the currency to deposit ( 1 - ₺ | 2 - $ | 3 - kr | 4 - £ | 5 - € ) : ");
            string depositCurrency = _getCurrencyFromCodeBll.GetCurrencyFromCode(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            Console.Write($"\tDo you confirm you want to deposit {depositAmount}{depositCurrency} ? ( 1 - YES | 2 - NO ) : ");
            int depositConfirmation = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

            if (depositConfirmation == 1)
            {
                var bankingResponse = _depositBll.GetBankingResponseOK(userInfo, depositCurrency, depositAmount);
                Console.WriteLine(bankingResponse.Title);
                Console.WriteLine(bankingResponse.Message);
            }
            else if (depositConfirmation == 2) // If the user doesn't want to make the deposit, we display a message
            {               
                var bankingResponse = _depositBll.GetBankingResponseKO();
                Console.WriteLine(bankingResponse.Message);
            }
            else
            { // If the user enters a wrong number, we display an error message
                var bankingResponse = _depositBll.GetBankingResponseKO2();
                Console.WriteLine(bankingResponse.Message);
            }
            Console.WriteLine();
        }
    }
}
