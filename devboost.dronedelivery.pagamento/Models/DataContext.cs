using devboost.dronedelivery.felipe.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace devboost.dronedelivery.pagamento.Models
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

        public DbSet<Pagamento> Pagamento { get; set; }

    }
}
