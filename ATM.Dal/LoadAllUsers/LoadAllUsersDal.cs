using ATM.Model;

namespace ATM.Dal
{
    public class LoadAllUsersDal : ILoadAllUsersDal // Class to load all
    {
        public List<UserInfo> LoadAllUsers() // Method to load all the users
        {
            List<UserInfo> userInfos =
            [
                new UserInfo { SecretCode = "1234", AccountNumber = "77977837709", Name = "Tumay", InitialBalance = 512.1, Currency = "₺" },
                new UserInfo { SecretCode = "6940", AccountNumber = "31108427981", Name = "Nicolas", InitialBalance = 4253.6, Currency = "$" },
                new UserInfo { SecretCode = "7739", AccountNumber = "90032461211", Name = "Robert", InitialBalance = 6894.4, Currency = "kr" },
                new UserInfo { SecretCode = "8277", AccountNumber = "16074449908", Name = "Luca", InitialBalance = 2536.7, Currency = "£" },
                new UserInfo { SecretCode = "2567", AccountNumber = "43597210245", Name = "Dominique", InitialBalance = 12542.8, Currency = "€" },
            ]; // List of all the users

            return userInfos;
        }
    }
}
