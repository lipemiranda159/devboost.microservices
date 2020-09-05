using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.test.Pedido
{
    public class MockPedidoRepository : IPedidoRepository
    {
        private readonly List<felipe.DTO.Models.Pedido> _pedidos;

        public MockPedidoRepository()
        {
            _pedidos = new List<felipe.DTO.Models.Pedido>();
        }

        public felipe.DTO.Models.Pedido GetPedido(int id)
        {
            return _pedidos.Where(w => w.Id == id).FirstOrDefault();
        }

        public List<felipe.DTO.Models.Pedido> ObterPedidos(int situacao)
        {
            return _pedidos;
        }

        public Task<int> OnlySalveContext()
        {
            throw new System.NotImplementedException();
        }

        public Task<felipe.DTO.Models.Pedido> PegaPedidoPendenteAsync(string GatewayId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<int> SavePedidoAsync(felipe.DTO.Models.Pedido pedido)
        {
            _pedidos.Add(pedido);
            return 1;
        }

        public void SetState(felipe.DTO.Models.Pedido pedido, EntityState entityState)
        {
            throw new System.NotImplementedException();
        }
    }
}
