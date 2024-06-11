using ATM.Dal;
using ATM.Model;

namespace ATM.Bll
{
    public class LoadAllUsersBll(
        ILoadAllUsersDal loadAllUsersDal
        ) : ILoadAllUsersBll
    { 
        private readonly ILoadAllUsersDal _loadAllUsersDal = loadAllUsersDal;      

        public List<UserInfo> LoadAllUsers()
        {
            return _loadAllUsersDal.LoadAllUsers();
        }
    }
}
