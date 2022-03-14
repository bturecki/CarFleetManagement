using System.ComponentModel.DataAnnotations;

namespace CarFleetManagement.Models
{
    public class User
    {
        int Id { get; }
        [Required(ErrorMessage = "You need to enter the name of the person")]
        public string Name { get; }
        [Required(ErrorMessage = "You need to enter the surname of the person")]
        public string Surname { get; }
        [Display(Name = "Date of birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "You need to enter the date of birth of the person")]
        public DateTime DateOfBirth { get; }
        [Required(ErrorMessage = "You need to determine if the user is an admin")]
        bool IsAdmin { get; }
    }
}
