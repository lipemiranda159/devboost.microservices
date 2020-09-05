using devboost.dronedelivery.felipe.DTO.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories.Interfaces
{
    public interface IPedidoRepository
    {
        Task<int> SavePedidoAsync(Pedido pedido);
        Pedido GetPedido(int id);
        List<Pedido> ObterPedidos(int situacao);
        Task<Pedido> PegaPedidoPendenteAsync(string GatewayId);

        void SetState(Pedido pedido, EntityState entityState);

        Task<int> OnlySalveContext();

    }
}
