using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; } // Será la llave primaria
        [Required] // verificar que se importó using System.ComponentModel.DataAnnotations;
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]

        public string Password { get; set; }
    }
}
