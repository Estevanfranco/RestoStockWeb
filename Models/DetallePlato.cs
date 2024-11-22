using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoStockWeb.Models
{
    public class DetallePlato
    {
        [Key]
        public int IdDetalle { get; set; }

        [ForeignKey("Plato")]
        public int IdPlato { get; set; }

        [ForeignKey("Ingrediente")]
        public int IngredienteId { get; set; }

        public double Cantidad { get; set; }

        // Propiedades de navegación
        public Plato Plato { get; set; } = default!;
        public Ingrediente Ingrediente { get; set; } = default!;
    }
}

