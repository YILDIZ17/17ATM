using ATM.Model;

namespace ATM.View
{
    public class ShowUserInterfaceApp(
            IGetWithdrawalApp getWithdrawalApp,
            IGetDepositApp getDepositApp,
            IGetInformationApp getInformationApp
                ) : IShowUserInterfaceApp
    {
        private readonly IGetWithdrawalApp _getWithdrawalApp = getWithdrawalApp;
        private readonly IGetDepositApp _getDepositApp = getDepositApp;
        private readonly IGetInformationApp _getInformationApp = getInformationApp;

        public bool ShowUserInterface(UserInfo userInfo) // Method to display the user interface
        {
            int choice;
            Console.WriteLine("What do you want to do ? | 1 - Withdrawal | 2 - Deposit | 3 - See infos | 4 - Quit");
            Console.WriteLine();
            Console.Write("Choice number : ");

            try // We try to convert the user's choice into an integer
            {
                choice = int.Parse(Console.ReadKey().KeyChar.ToString());

                if (choice == 1) // If the user chooses 1, he makes a withdrawal
                {
                    _getWithdrawalApp.GetWithdrawal(userInfo);
                    return true;
                }
                else if (choice == 2) // If the user chooses 2, he makes a deposit
                {
                    _getDepositApp.GetDeposit(userInfo);
                    return true;
                }
                else if (choice == 3) // If the user chooses 3, he sees his account information
                {
                    _getInformationApp.GetInformation(userInfo);
                    return true;
                }
                else if (choice == 4) // If the user chooses 4, we display a message and close the program
                {
                    Console.WriteLine();
                    Console.WriteLine("Don't forget your card, see you soon !");
                    return false;
                }
                else // If the user chooses another number, we display an error message (1, 2, 3 or 4)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input error: please enter a number between 1 and 4.");
                    Console.WriteLine();
                    ShowUserInterface(userInfo);
                    return false;
                }
            }
            catch (FormatException) // If the user enters a letter, we display an error message and ask him to enter a number (1, 2 or 3)
            {
                Console.WriteLine();
                Console.WriteLine("An error has occurred, please try again.");
                Console.WriteLine();
                ShowUserInterface(userInfo);
                return false;
            }
        }
    }
}
