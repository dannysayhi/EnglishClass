
namespace AOISystem.Utility.Account
{
    public class AccountInfo
    {
        public AccountInfo()
        {
        }
        public string Name { get; set; }
        public string Password { get; set; }
        public AccountLevel Level { get; set; }
    }

    public enum AccountLevel
    {
        Intern,
        Operator,
        Engineer,
        Manager,
        Administrator,
        Developer
    }
}
