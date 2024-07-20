namespace TripLog.Models
{
    public class TripViewModel
    {
        public TripViewModel()
        {
            // Initialize properties here
            Destination = "";
            Accommodation = "";
            StartDate = DateTime.MinValue;
            EndDate = DateTime.MinValue;
        }

        public string Destination { get; set; }
        public string Accommodation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
