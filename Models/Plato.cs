using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class Plato
    {
        [Key]
        public int IdIngrediente { get; set; }                       // Identificador único del ingrediente
        public string Nombre { get; set; }                           // Nombre del ingrediente
        public double CantidadDisponible { get; set; }               // Cantidad disponible en inventario
        public string UnidadMedida { get; set; }                     // Unidad de medida (por ejemplo, gramos, litros, etc.)
        public decimal PrecioUnitario { get; set; }                  // Precio por unidad de medida
        public ICollection<DetallePlato> DetallesPlato { get; set; }
    }
}
