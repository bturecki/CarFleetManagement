using System.ComponentModel;

namespace CarFleetManagement.Models
{
    public class CarOfUser
    {
        public int Id { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [DisplayName("Car Id")]
        public int CarId { get; set; }
        [DisplayName("User full name")]
        public string UserFullName { get; set; }
        [DisplayName("Car full name")]
        public string CarFullName { get; set; }
        [DisplayName("Car milage")]
        public int CarMilage { get; set; }
    }
}
