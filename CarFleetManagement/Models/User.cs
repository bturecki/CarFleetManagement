using System.ComponentModel.DataAnnotations;

namespace CarFleetManagement.Models
{
    public class User
    {
        internal int Id { get; set; }
        [Required(ErrorMessage = "You need to enter the name of the person")]
        internal string Name { get; set; }
        [Required(ErrorMessage = "You need to enter the surname of the person")]
        internal string Surname { get; set; }
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You need to enter the date of birth of the person")]
        internal DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "You need to determine if the user is an admin")]
        internal bool IsAdmin { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "You need to enter the email of the person")]
        internal string Email { get; set; }

    }
}
