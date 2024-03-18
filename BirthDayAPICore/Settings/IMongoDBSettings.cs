namespace BirthDayAPICore.Settings
{
    public interface IMongoDBSettings
    {
        string UsersCollectionName { get; set; }

        string BirthDaysCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
