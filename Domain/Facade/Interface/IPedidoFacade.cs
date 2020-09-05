using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IPedidoFacade
    {
        Task AssignDrone(IPedidoRepository pedidoRepository);
    }
}
