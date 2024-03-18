using BirthDayAPICore.Models;

namespace BirthDayAPICore.Services
{
    public interface IBirthDayCollectionService
    {

        public List<BirthDay> GetBirthDaysFriends(int userId);

        public bool AddBirthDay(BirthDay birthDay);

        public bool EditBirthDay(BirthDay birthDay);
    }
}
