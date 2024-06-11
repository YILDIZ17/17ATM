namespace ATM.View
{
    public class UserInputHandlerApp : IUserInputHandlerApp
    {
        public string GetMaskedInput()
        {
            string input = "";
            ConsoleKeyInfo key;
            int inputLength = 0; // Track the length of the input

            do
            {
                key = Console.ReadKey(true);

                // If the key is not Enter and the input length is less than 4, add a star and display '*'
                if (char.IsDigit(key.KeyChar) && inputLength < 4)
                {
                    input += key.KeyChar;
                    Console.Write("*");
                    inputLength++;
                }
            } while (key.Key != ConsoleKey.Enter || inputLength < 4); // Exit the loop if Enter is pressed or the input length is 4

            Console.WriteLine();

            return input;
        }
    }
}
