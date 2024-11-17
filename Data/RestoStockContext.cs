using Microsoft.EntityFrameworkCore;
using RestoStockWeb.Models;

namespace RestoStockWeb.Data
{
    public class RestoStockContext : DbContext
    {
        public RestoStockContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<DetallePlato> DetallesPlato { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
