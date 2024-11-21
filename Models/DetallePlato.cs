using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class DetallePlato
    {
        [Key]
        public int IdDetalle { get; set; }                           // Identificador único del detalle
        public int IdPlato { get; set; }                             // Clave foránea que referencia al plato
        public Plato Plato { get; set; }                             // Objeto plato correspondiente

        public Ingrediente Ingrediente { get; set; }                 // Objeto ingrediente correspondiente
        public double Cantidad { get; set; }

    }
}
