using ATM.Model;

namespace ATM.Dal
{
    public interface ILoadAllUsersDal
    {
        List<UserInfo> LoadAllUsers();
    }
}
