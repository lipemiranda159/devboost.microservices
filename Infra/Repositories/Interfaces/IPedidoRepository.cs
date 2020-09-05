using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<int> SavePedidoAsync(Pedido pedido);
        Pedido GetPedido(int id);
        List<Pedido> ObterPedidos(int situacao);
    }
}
