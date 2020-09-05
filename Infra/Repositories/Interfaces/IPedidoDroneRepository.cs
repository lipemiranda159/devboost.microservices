using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface IPedidoDroneRepository
    {
        Task UpdatePedidoDrone(DroneStatusDto drone, double distancia);
        List<PedidoDrone> RetornaPedidosEmAberto();
        List<PedidoDrone> RetornaPedidosParaFecharAsync();
        Task<int> UpdatePedido(PedidoDrone pedido);
    }
}
