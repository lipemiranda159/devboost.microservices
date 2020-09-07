using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.core.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test
{
    public class CriarPedidoUnitTest
    {
        [Fact]
        public async Task CriarPedido()
        {
            IPedidoRepository _pedidoRepository = new MockPedidoRepository();

            const string clientePassword = "12543GTFrd@65";
            const int pedidoId = 1;

            var cliente = new Cliente
            {
                Id = pedidoId,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Nome = "João Silva Antunes",
                UserId = "joaoantunes",
                Password = clientePassword
            };

            var pedido = new Pedido
            {
                Id = 1,
                Peso = 100,
                Situacao = (int)StatusPedido.AGUARDANDO,
                DataHoraInclusao = DateTime.Now,
                DataHoraFinalizacao = DateTime.Now,
                Cliente = cliente
            };

            await _pedidoRepository.UpdateAsync(pedido);

            Assert.Single(_pedidoRepository.ObterPedidos(pedidoId));
            var pedidoResponse = await _pedidoRepository.GetByIdAsync(pedidoId);
            Assert.Equal(pedidoResponse.Cliente.Password, clientePassword);
        }
    }
}
