using System.ComponentModel.DataAnnotations;

namespace APBD_04.Models
{
    public class Animal
    {
        [Required(ErrorMessage = "Id zwierzecia jest wymagane!")] 
        public int IdAnimal { get; set; }

        [Required(ErrorMessage = "Imie jest wymagane!")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Kategoria jest wymagana!")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Obszar jest wymagane!")]
        public string Area { get; set; }
    }
}
