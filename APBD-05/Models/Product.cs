using System;
using System.ComponentModel.DataAnnotations;

namespace APBD_05.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Id produktu jest wymagany!")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "Id magazynu jest wymagany!")]
        public int IdWarehouse { get; set; }

        [Required(ErrorMessage = "Ilosc jest wymagana!")]
        public int Ammount { get; set; }

        [Required(ErrorMessage = "Data jest wymagana!")]
        public DateTime CreatedAt { get; set; }
    }
}
