namespace BirthDayAPICore.Settings
{
    // conține setările pentru conexiunea cu MongoDB și este configurată în fișierul appsettings.json
    public class MongoDBSettings : IMongoDBSettings
    {
        public string UsersCollectionName { get; set; }
        public string BirthDaysCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
