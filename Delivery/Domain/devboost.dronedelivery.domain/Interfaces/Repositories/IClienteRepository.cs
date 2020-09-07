using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.core.Interfaces;
using System.Collections.Generic;

namespace devboost.dronedelivery.domain.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> GetClientes();
    }
}
