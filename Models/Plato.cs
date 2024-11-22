using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }                       // Identificador único del ingrediente
        public string Nombre { get; set; }                           // Nombre del ingrediente
        public double PrecioVenta { get; set; }               // Cantidad disponible en inventario
        public string Descripción { get; set; }                     // Unidad de medida (por ejemplo, gramos, litros, etc.)
        public ICollection<DetallePlato> DetallesPlato { get; set; }
    }
}
