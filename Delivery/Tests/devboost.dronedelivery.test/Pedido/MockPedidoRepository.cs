using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.Interfaces.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.test
{
    public class MockPedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        private readonly List<Pedido> _pedidos;

        public MockPedidoRepository(DataContext context) : base(context)
        {
            _pedidos = new List<Pedido>();

        }

        public List<Pedido> ObterPedidos(int situacao)
        {
            return _pedidos;
        }

        public Task<Pedido> PegaPedidoPendenteAsync(string GatewayId)
        {
            throw new System.NotImplementedException();
        }

        public void SetState(Pedido pedido, EntityState entityState)
        {
            throw new System.NotImplementedException();
        }
    }
}
