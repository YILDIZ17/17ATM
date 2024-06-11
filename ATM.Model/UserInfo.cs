namespace ATM.Model
{
    public class UserInfo
    {
        public string? SecretCode { get; set; }
        public string? AccountNumber { get; set; }
        public string? Name { get; set; }
        public double InitialBalance { get; set; }
        public string? Currency { get; set; }
    }
}
