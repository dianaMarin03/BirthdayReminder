namespace BirthDayAPICore.Models
{
    public class BirthDay
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FriendName { get; set; }    

        public DateTime BirthDayDate { get; set; }

        public int Age { get; set; }    
        public string PhoneNumber { get; set; }
        public List<string> Wishes { get; set; }
    }
}
