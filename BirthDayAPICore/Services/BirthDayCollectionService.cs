using BirthDayAPICore.Models;
using BirthDayAPICore.Settings;
using MongoDB.Driver;

namespace BirthDayAPICore.Services
{
    public class BirthDayCollectionService : IBirthDayCollectionService
    {

        //ia collection din baza de date (fiecare tabel)
        private readonly IMongoCollection<BirthDay> _birthdays;

        //metodele care cont implementarea catre care se face request(din ui faci request si il trimiti aici)
        public BirthDayCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _birthdays = database.GetCollection<BirthDay>(settings.BirthDaysCollectionName);
        }
        public bool AddBirthDay(BirthDay birthDay)
        {
            _birthdays.InsertOne(birthDay);
            return true;
        }

        public bool EditBirthDay(BirthDay birthDay)
        {
            _birthdays.ReplaceOne(b=>b.Id==birthDay.Id, birthDay);
            return true;
        }

        public List<BirthDay> GetBirthDaysFriends(int userId)
        {
            return _birthdays.Find(b => b.UserId == userId)?.ToList();
        }
    }
}
