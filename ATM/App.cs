using ATM.View;

namespace ATM
{
    public class App
    {
        private readonly IShowUserInterfaceApp _showUserInterfaceApp;
        private readonly ILoginUserInfoApp _loginUserInfoApp;
        public App
            (
            IShowUserInterfaceApp showUserInterfaceApp,
            ILoginUserInfoApp loginUserInfoApp
            ) 
            {
            _showUserInterfaceApp = showUserInterfaceApp;
            _loginUserInfoApp = loginUserInfoApp;
            //Run();
            }

        public void Run()
        {
            var user = _loginUserInfoApp.UserLogin();
            if (user != null) // If the user logs in, we start the program
            {

                //Start(user, new ShowUserInterfaceApp()); // Start the program
                bool retry = true;
                while (retry) // While the user doesn't choose 4, we display the user interface
                {
                    retry = _showUserInterfaceApp.ShowUserInterface(user);
                }
                Console.ReadLine();
            }
        }
    }
}
