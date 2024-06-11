using ATM.Model;

namespace ATM.Bll
{
    public class WithdrawalBll : GetCurrencyFromCodeBll, IWithdrawalBll
    {

        public BankingResponse GetBankingResponseOK(UserInfo userInfo, string withdrawCurrency, double withdrawAmount)
        {
            BankingResponse bankingResponse = new();
            if (withdrawCurrency == userInfo.Currency && withdrawAmount > 9 && withdrawAmount < 501) // If the currency chosen is the same as the one of the account, we make the withdrawal
            {
                bankingResponse.Title = "\tOperation done.";
                bankingResponse.Message = $"\tNew balance : {userInfo.InitialBalance - withdrawAmount}{userInfo.Currency}.";

            }
            else if (withdrawCurrency != userInfo.Currency && withdrawAmount > 9 && withdrawAmount < 501) // If the currency chosen is different from the one of the account, we convert the withdrawal
            {
                CurrencyConvertBll currencyConverter = new();
                double withdrawnAmountConverted = currencyConverter.Convert(withdrawCurrency, withdrawAmount);
                bankingResponse.Title = "\tOperation done.";
                bankingResponse.Message = $"\tNew balance : {userInfo.InitialBalance - withdrawnAmountConverted}{userInfo.Currency}.";

                // Initialize the new balance
                userInfo.InitialBalance -= withdrawnAmountConverted;
            }
            else if (withdrawAmount > userInfo.InitialBalance)
            {
                bankingResponse.Title = "\tInsufficient balance";
                bankingResponse.Message = $"\tBalance : {userInfo.InitialBalance}{userInfo.Currency}.";
            }
            else if (withdrawAmount < 10 || withdrawAmount > 500) // If the withdrawal amount is not between 10 and 500, we display an error message
            {
                bankingResponse.Title = "\tOperation canceled";
                bankingResponse.Message = $"\tWithdrawal amount must be between 10 and 500.";
            }
            else
            {
                bankingResponse.Title = "\tError";
            }
            return bankingResponse;
        }
    }
}
