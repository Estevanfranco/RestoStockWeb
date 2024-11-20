using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }                           // Identificador único del proveedor
        public string NombreEmpresa { get; set; }                    // Nombre de la empresa del proveedor
        public string Contacto { get; set; }                         // Nombre del contacto principal del proveedor
        public string Telefono { get; set; }                         // Teléfono de contacto del proveedor
        public string Email { get; set; }                            // Email de contacto del proveedor
        public string Direccion { get; set; }                        // Dirección del proveedor
        public int IdProveedor { get; set; }                       //llave foranea
        public Proveedor proveedor { get; set; }
    }
}
