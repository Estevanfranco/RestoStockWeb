﻿using System.ComponentModel.DataAnnotations;

namespace RestoStockWeb.Models
{
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }                         // Identificador único del proveedor
        public string NombreEmpresa { get; set; }                    // Nombre de la empresa del proveedor
        public string Contacto { get; set; }                         // Nombre del contacto principal del proveedor
        public string Telefono { get; set; }                         // Teléfono de contacto del proveedor
        public string Email { get; set; }                            // Email de contacto del proveedor
        public string Direccion { get; set; }                        // Dirección del proveedor
        public ICollection<Pedido> Pedidos { get; set; }            //nos permite navegar para sacar inf de foranea en pedido
    }
}
