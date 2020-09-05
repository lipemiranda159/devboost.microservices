using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
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

        public async Task<int> SavePedidoAsync(felipe.DTO.Models.Pedido pedido)
        {
            _pedidos.Add(pedido);
            return 1;
        }
    }
}
