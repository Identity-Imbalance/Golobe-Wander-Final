namespace Globe_Wander_Final.Models
{
    public class UPDATEBOOKINGTRIP
    {
        public int ID { get; set; }
        public int IdForUpdate  { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
