namespace CarFleetManagement.Models
{
    public class CarOfUser
    {
        int Id { get; set; }
        int UserId { get; set; }
        int CarId { get; set; }
        string UserFullName { get; set; }
        string CarFullName { get; set; }
        int CarMilage { get; set; }
    }
}
