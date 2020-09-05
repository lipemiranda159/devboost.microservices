using devboost.dronedelivery.felipe.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace devboost.dronedelivery.felipe.EF.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Drone> Drone { get; set; }

        public DbSet<PedidoDrone> PedidoDrones { get; set; }

    }
}
