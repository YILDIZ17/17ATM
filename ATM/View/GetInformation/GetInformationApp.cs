using ATM.Model;

namespace ATM.View
{
    public class GetInformationApp(
        IAccountUserInfoApp accountUserInfoApp
            ) : IGetInformationApp // Class to get the information of the user
    {
        private readonly IAccountUserInfoApp _accountUserInfoApp = accountUserInfoApp;

        public void GetInformation(UserInfo userInfo) // Method to get the information of the user
        {

            Console.WriteLine();
            Console.WriteLine("You have chosen to see your information.");
            Console.WriteLine();
            _accountUserInfoApp.AccountInfo(userInfo);
            Console.WriteLine();
        }
    }
}
