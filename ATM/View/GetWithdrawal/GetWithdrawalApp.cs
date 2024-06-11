using ATM.Bll;
using ATM.Model;

namespace ATM.View
{
    public class GetWithdrawalApp(
        IDepositBll depositBll,
        IWithdrawalBll withdrawalBll,
        IGetCurrencyFromCodeBll getCurrencyFromCodeBll,
        ICurrencyDisplayApp currencyDisplayApp
            ) : IGetWithdrawalApp
    { 
        private readonly IDepositBll _depositBll = depositBll;
        private readonly IWithdrawalBll _withdrawalBll = withdrawalBll;
        private readonly IGetCurrencyFromCodeBll _getCurrencyFromCodeBll = getCurrencyFromCodeBll;
        private readonly ICurrencyDisplayApp _currencyDisplayApp = currencyDisplayApp;

        public void GetWithdrawal(UserInfo userInfo) // Method to get the withdrawal
        {
            Console.WriteLine();
            Console.WriteLine("You have chosen to make a withdrawal.");
            Console.WriteLine();
            _currencyDisplayApp.DisplayCurrency(); // We display the current exchange rates
            Console.Write("\tPlease enter the amount to withdraw : ");
            double withdrawAmount = double.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("\tPlease choose the currency to withdraw ( 1 - ₺ | 2 - $ | 3 - kr | 4 - £ | 5 - € ) : ");
            string withdrawCurrency = _getCurrencyFromCodeBll.GetCurrencyFromCode(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
            Console.Write($"\tDo you confirm you want to withdraw {withdrawAmount}{withdrawCurrency} ? ( 1 - YES | 2 - NO ) : ");
            int withdrawalConfirmation = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

            if (withdrawalConfirmation == 1) // If the user confirms the withdrawal, we display the new balance
            {
                var bankingResponse = _withdrawalBll.GetBankingResponseOK(userInfo, withdrawCurrency, withdrawAmount);
                Console.WriteLine(bankingResponse.Title);
                Console.WriteLine(bankingResponse.Message);
            }
            else if (withdrawalConfirmation == 2) // If the user doesn't want to make the withdrawal, we display a message
            {
                var bankingResponse = _depositBll.GetBankingResponseKO();
                Console.WriteLine(bankingResponse.Message);
            }
            else // If the user enters a wrong number, we display an error message
            {
                var bankingResponse = _depositBll.GetBankingResponseKO2();
                Console.WriteLine(bankingResponse.Message);
            }
            Console.WriteLine();
        }
    }
}
