using devboost.dronedelivery.domain.core.Entities;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IPedidoFacade
    {
        Task AssignDroneAsync();
        Task<Pedido> CreatePedidoAsync(Pedido pedido);
    }
}
