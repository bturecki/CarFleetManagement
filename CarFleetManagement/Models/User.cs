using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CarFleetManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You need to enter the name of the person")]
        public string Name { get; set; }
        [Required(ErrorMessage = "You need to enter the surname of the person")]
        public string Surname { get; set; }
        [DisplayName("Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You need to enter the date of birth of the person")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "You need to determine if the user is an admin")]
        [DisplayName("Is admin")]
        public bool IsAdmin { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter the email of the person")]
        public string Email { get; set; }

    }
}
