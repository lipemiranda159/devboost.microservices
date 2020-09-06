using devboost.dronedelivery.felipe.domain.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.core.Interfaces
{
    public interface IPedidoRepository : IRepositoryBase<Pedido>
    {
        List<Pedido> ObterPedidos(int situacao);
        Task<Pedido> PegaPedidoPendenteAsync(string GatewayId);
        void SetState(Pedido pedido, EntityState entityState);
    }
}
