using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.Interfaces.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.Infra.Data;
using devboost.dronedelivery.test.Repositories;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class CriarPedidoUnitTest
    {
        [Fact]
        public async Task CriarPedido()
        {
            var context = ContextProvider<Pedido>.GetContext(null);
            IPedidoRepository _pedidoRepository = new PedidoRepository(context);

            const string clientePassword = "12543GTFrd@65";

            var cliente = new Cliente
            {
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Nome = "João Silva Antunes",
                UserId = "joaoantunes",
                Password = clientePassword
            };

            var pedido = new Pedido
            {
                Peso = 100,
                Situacao = (int)StatusPedido.AGUARDANDO,
                DataHoraInclusao = DateTime.Now,
                DataHoraFinalizacao = DateTime.Now,
                Cliente = cliente
            };

            await _pedidoRepository.AddAsync(pedido);
            var pedidos = await _pedidoRepository.GetAllAsync();
            Assert.True(pedidos.Count() > 0);
        }
    }
}
