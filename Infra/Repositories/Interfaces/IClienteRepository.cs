using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetClientes();
        Task SaveCliente(Cliente cliente);
        Cliente GetCliente(int id);
    }
}
