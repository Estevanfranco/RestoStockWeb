using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }                           // Identificador único del proveedor
        public string  FechaPedido { get; set; }                    // Nombre de la empresa del proveedor
        public float Total { get; set; }                         // Nombre del contacto principal del proveedor
                             
        public int ProveedorId { get; set; }                       //llave foranea
        public Proveedor Proveedor { get; set; }
    }
}
