using BirthDayAPICore.Models;
//interfata pentru User
namespace BirthDayAPICore.Services
{
    public interface IUsersCollectionService
    {
        public User GetUser(int id);
        public List<User> GetUsers();
        public User GetUser(string email, string password);
        public bool AddUser(User user);

    }
}
