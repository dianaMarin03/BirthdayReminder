using BirthDayAPICore.Models;
using BirthDayAPICore.Settings;
using MongoDB.Driver;

namespace BirthDayAPICore.Services
{
    public class UsersCollectionService : IUsersCollectionService
    {
        //ia collection din baza de date (fiecare tabel)
        private readonly IMongoCollection<User> _users;

        public UsersCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UsersCollectionName);
        }
        public bool AddUser(User user)
        {
            if(user == null)
                return false;
          _users.InsertOne(user);
           return true;
        }

        public List<User> GetUsers()
        {
            return _users.AsQueryable().ToList();
        }

        public User GetUser(int id)
        {
            return _users.Find(user=>user.Id== id).ToList().First();
        }

        public User GetUser(string email, string password)
        {
            return _users.Find(user => user.Email == email && user.Password == password).ToList().First();
        }
    }
}
