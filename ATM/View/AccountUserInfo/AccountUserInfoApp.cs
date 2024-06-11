using ATM.Model;

namespace ATM.View
{
    public class AccountUserInfoApp : IAccountUserInfoApp
    {
        public void AccountInfo(UserInfo userInfo) // Method to display the account information
        {
            Console.WriteLine($"\tAccount Number: {userInfo.AccountNumber}.");
            Console.WriteLine($"\tAccount Holder: {userInfo.Name}.");
            Console.WriteLine($"\tInitial Balance: {userInfo.InitialBalance}.");
            Console.WriteLine($"\tAccount Currency: {userInfo.Currency}.");
        }
    }
}
