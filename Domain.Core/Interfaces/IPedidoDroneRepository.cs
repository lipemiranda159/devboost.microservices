using devboost.dronedelivery.felipe.domain.core;
using devboost.dronedelivery.felipe.domain.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.core.Interfaces
{
    public interface IPedidoDroneRepository : IRepositoryBase<PedidoDrone>
    {
        Task UpdatePedidoDroneAsync(DroneStatusDto drone, double distancia);
        Task<List<PedidoDrone>> RetornaPedidosEmAbertoAsync();
        Task<List<PedidoDrone>> RetornaPedidosParaFecharAsync();
    }
}
