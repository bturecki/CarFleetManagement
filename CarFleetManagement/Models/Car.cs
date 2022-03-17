using System.ComponentModel.DataAnnotations;

namespace CarFleetManagement.Models
{
    public class Car
    {
        [Required(ErrorMessage = "You need to enter the make of the car")]
        public string Make { get; set; }
        [Required(ErrorMessage = "You need to enter the model of the car")]
        public string Model { get; set; }
        [Range(1900, 2100)]
        [Display(Name = "Year of production")]
        [Required(ErrorMessage = "You need to enter the year of production of the car")]
        public int YearOfProduction { get; set; }
        [Required(ErrorMessage = "You need to enter the milage of the car")]
        public int Milage { get; set; }
        public int Id { get; set; }
    }
}
