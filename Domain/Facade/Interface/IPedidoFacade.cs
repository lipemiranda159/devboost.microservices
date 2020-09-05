using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IPedidoFacade
    {
        Task AssignDroneAsync();
        Task<Pedido> CreatePedidoAsync(Pedido pedido);
    }
}
