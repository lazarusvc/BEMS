namespace DataAccessLibrary.Models
{
    public class ProcessingYearModel
    {
        public int year { get; set; }
        public bool ready_for_data_entry { get; set; }
        public bool year_closed { get; set; }

        public string displayYear { get { return (year + " - " + (year + 1)); } }
    }
}
