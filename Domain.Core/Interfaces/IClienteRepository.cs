using devboost.dronedelivery.felipe.domain.core.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.domain.core.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        IEnumerable<Cliente> GetClientes();
    }
}
