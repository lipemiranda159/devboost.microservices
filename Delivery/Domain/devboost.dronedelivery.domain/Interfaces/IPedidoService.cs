using devboost.dronedelivery.felipe.domain.core;
using devboost.dronedelivery.felipe.domain.core.Models;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IPedidoService
    {
        Task<DroneDto> DroneAtendePedido(Pedido pedido);
    }
}
