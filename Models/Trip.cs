namespace TripLog.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public string Accommodation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public List<ThingToDo> ThingsToDo { get; set; }
    }
}
