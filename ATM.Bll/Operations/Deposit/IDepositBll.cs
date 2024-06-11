using ATM.Model;

namespace ATM.Bll
{
    public interface IDepositBll
    {
        BankingResponse GetBankingResponseOK(UserInfo userInfo, string depositCurrency, double depositAmount);
        BankingResponse GetBankingResponseKO();
        BankingResponse GetBankingResponseKO2();
    }
}
