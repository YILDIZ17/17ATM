using ATM.Model;

namespace ATM.Bll
{
    public interface IWithdrawalBll
    {
        BankingResponse GetBankingResponseOK(UserInfo userInfo, string withdrawCurrency, double withdrawAmount);


    }
}
