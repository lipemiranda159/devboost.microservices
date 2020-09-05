using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _context;

        public ClienteRepository(DataContext context)
        {
            _context = context;
        }

        public Cliente GetCliente(int id)
        {
            return _context.Find<Cliente>(id);
        }

        public IEnumerable<Cliente> GetClientes()
        {
            Cliente cliente = new Cliente
            {
                Id = 0,
                Nome = "Usuario Acesso",
                UserId = "admin_drone",
                Password = "AdminAPIDrone01!"
            };

            var busca = _context.Cliente.AsNoTracking<Cliente>().ToList();

            busca.Add(cliente);

            return busca;
        }

        public async Task SaveCliente(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
