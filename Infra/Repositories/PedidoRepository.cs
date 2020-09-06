using devboost.dronedelivery.domain.core.Interfaces;
using devboost.dronedelivery.felipe.domain.core.Models;
using devboost.dronedelivery.felipe.EF.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public List<Pedido> ObterPedidos(int situacao)
        {
            var pedidos = from p in Context.Pedido.ToList()
                          where p.Situacao == situacao
                          select p;

            return pedidos.ToList();
        }

        public async Task<Pedido> PegaPedidoPendenteAsync(string GatewayId)
        {
            return await Context.Pedido.Where(p => p.GatewayPagamentoId == GatewayId).FirstOrDefaultAsync();
        }

        public void SetState(Pedido pedido, EntityState entityState)
        {
            Context.Entry(pedido).State = entityState;
        }

    }
}
