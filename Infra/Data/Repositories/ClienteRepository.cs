using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public IEnumerable<Cliente> GetClientes()
        {
            var cliente = new Cliente
            {
                Id = 0,
                Nome = "Usuario Acesso",
                UserId = "admin_drone",
                Password = "AdminAPIDrone01!"
            };

            var busca = Context.Cliente.AsNoTracking<Cliente>().ToList();

            busca.Add(cliente);

            return busca;
        }
    }
}
