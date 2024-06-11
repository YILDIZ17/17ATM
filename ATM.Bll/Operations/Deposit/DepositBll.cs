using ATM.Model;

namespace ATM.Bll
{
    public class DepositBll : GetCurrencyFromCodeBll, IDepositBll
    {

        public BankingResponse GetBankingResponseOK(UserInfo userInfo, string depositCurrency, double depositAmount)
        {
            BankingResponse bankingResponse = new();
            if (depositCurrency == userInfo.Currency) // If the currency chosen is the same as the one of the account, we make the deposit
            {
                bankingResponse.Title = "\tOperation done.";
                bankingResponse.Message = $"\tNew balance : {userInfo.InitialBalance + depositAmount}{userInfo.Currency}.";
            }
            else // If the currency chosen is different from the one of the account, we convert the deposit
            {
                CurrencyConvertBll currencyConverter = new();
                double depositAmountConverted = currencyConverter.Convert(depositCurrency, depositAmount);
                bankingResponse.Title = "\tOperation done.";
                bankingResponse.Message = $"\tNew balance : {userInfo.InitialBalance + depositAmountConverted}{userInfo.Currency}.";

                // Initialize the new balance
                userInfo.InitialBalance += depositAmountConverted;
            }
            return bankingResponse;
        }

        public BankingResponse GetBankingResponseKO()
        {
            BankingResponse bankingResponse = new()
            {
                Message = "\tOperation canceled"
            };
            return bankingResponse;
        }

        public BankingResponse GetBankingResponseKO2()
        {
            BankingResponse bankingResponse = new()
            {
                Message = "\tError",
            };
            return bankingResponse;
        }
    }
}
