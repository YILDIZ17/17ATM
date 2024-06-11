using ATM.Model;

namespace ATM.Bll
{
    public interface ILoadAllUsersBll
    {
        List<UserInfo> LoadAllUsers();
    }
}
