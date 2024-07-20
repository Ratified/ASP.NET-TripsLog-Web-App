namespace TripLog.Models
{
    public class ThingToDo
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; }
    }
}
