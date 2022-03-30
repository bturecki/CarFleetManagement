using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarFleetManagement.Models
{
    public class CarOfUser
    {
        public CarOfUser(int id, int userId, int carId, string userFullName, string carFullName, int carMilage, string userEmail)
        {
            Id = id;
            UserId = userId;
            CarId = carId;
            UserFullName = userFullName;
            CarFullName = carFullName;
            CarMilage = carMilage;
            UserEmail = userEmail;
        }

        public int Id { get; set; }
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [DisplayName("Car Id")]
        public int CarId { get; set; }
        [DisplayName("User full name")]
        public string UserFullName { get; set; }

        [DisplayName("User e-mail")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
        [DisplayName("Car full name")]
        public string CarFullName { get; set; }
        [DisplayName("Car milage")]
        public int CarMilage { get; set; }
    }
}
