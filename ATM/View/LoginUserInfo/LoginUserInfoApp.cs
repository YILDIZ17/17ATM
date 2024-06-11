using ATM.Bll;
using ATM.Model;
using System.Text;

namespace ATM.View
{
    public class LoginUserInfoApp(
        IUserInputHandlerApp userInputHandlerApp,
        ILoadAllUsersBll loadAllUsersBll
            ) : ILoginUserInfoApp // Class to log in
    { 
        private readonly IUserInputHandlerApp _userInputHandlerApp = userInputHandlerApp;
        private readonly ILoadAllUsersBll _loadAllUsersBll = loadAllUsersBll;
        
        public UserInfo? UserLogin() // Method to log in
        {

            int loginAttempts;
            for (loginAttempts = 2; loginAttempts >= 0; loginAttempts--)
            {

                Console.Write("Please enter your four-digit secret code: ");
                var userSecretCode = _userInputHandlerApp.GetMaskedInput();

                UserInfo? userInfo = GetUserBySecretCode(userSecretCode.ToString());

                if (userInfo == null)
                {
                    Console.WriteLine();
                    Console.WriteLine("Secret code invalid.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Welcome to your account {userInfo.Name}.");
                    Console.WriteLine();
                    Console.OutputEncoding = Encoding.Unicode;
                    Console.WriteLine($"Your initial balance is {userInfo.InitialBalance}{userInfo.Currency}.");
                    Console.WriteLine();
                    return userInfo;
                }

                Console.WriteLine();
                Console.WriteLine("You have " + loginAttempts + " attempts left.");
                Console.WriteLine();
            }

            if (loginAttempts <= 0) // If the user enters a wrong code 3 times, we lock the account
            {
                Console.WriteLine("Your account is locked, run away.");
                Console.WriteLine();
            }
            return null;
        }

        private UserInfo? GetUserBySecretCode(string userSecretCode) // Method to get the user by his secret code
        {
            var users = _loadAllUsersBll.LoadAllUsers();
            var user = users.Where(x => x.SecretCode == userSecretCode).FirstOrDefault();
            return user;
        }
    }
}
