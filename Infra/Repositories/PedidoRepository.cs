using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.EF.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DataContext _context;

        public PedidoRepository(DataContext context)
        {
            _context = context;
        }

        public Pedido GetPedido(int id)
        {
            return _context.Find<Pedido>(id);
        }

        public List<Pedido> ObterPedidos(int situacao)
        {
            var pedidos = from p in _context.Pedido.ToList()
                          where p.Situacao == situacao
                          select p;

            return pedidos.ToList();
        }

        public async Task<int> SavePedidoAsync(Pedido pedido)
        {
            _context.Pedido.Add(pedido);
            return await _context.SaveChangesAsync();
        }
    }
}
