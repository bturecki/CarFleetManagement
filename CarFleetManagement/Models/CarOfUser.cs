namespace CarFleetManagement.Models
{
    public class CarOfUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
        public string UserFullName { get; set; }
        public string CarFullName { get; set; }
        public int CarMilage { get; set; }
    }
}
