using ATM.Model;
using ATM.View;

namespace ATM.View
{
    public class ShowRetryApp(
        ShowUserInterfaceApp showUserInterfaceApp
               ) : IShowRetryApp
    { 
        private readonly ShowUserInterfaceApp _showUserInterfaceApp = showUserInterfaceApp;
        
        public void ShowRetry(UserInfo userInfo) // Method to ask the user if he wants to do another operation
        {
            Console.WriteLine("Do you want to make another operation ? 1 - YES | 2 - NO");
            Console.WriteLine();
            Console.Write("Choice number : ");
            int answer;
            answer = int.Parse(Console.ReadLine());
            if (answer == 1) // If the user chooses 1, he can make another operation
            {
                Console.WriteLine();
                Console.WriteLine($"Your initial balance is {userInfo.InitialBalance}{userInfo.Currency}.");
                Console.WriteLine();
                _showUserInterfaceApp.ShowUserInterface(userInfo);
            }
            else if (answer == 2) // If the user chooses 2, we display a message and close the program
            {
                Console.WriteLine();
                Console.WriteLine("Don't forget your card, see you soon !");
                Console.WriteLine();
                Environment.Exit(0); // Exit program
            }
            else // if the user chooses another number, we display an error message (1 or 2)
            {
                Console.WriteLine();
                Console.WriteLine("Please choose a number between 1 and 2.");
                Console.WriteLine();
                ShowRetry(userInfo); // We call the method to start again
            }
        }
    }
}
