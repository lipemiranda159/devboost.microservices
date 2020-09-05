using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using System;
using Xunit;

namespace devboost.dronedelivery.test.Pedido
{
    public class CriarPedidoUnitTest
    {
        [Fact]
        public void CriarPedido()
        {
            IPedidoRepository _pedidoRepository = new MockPedidoRepository();

            string clientePassword = "12543GTFrd@65";
            int pedidoId = 1;

            felipe.DTO.Models.Cliente cliente = new felipe.DTO.Models.Cliente
            {
                Id = pedidoId,
                Latitude = -23.5880684,
                Longitude = -46.6564195,
                Nome = "João Silva Antunes",
                UserId = "joaoantunes",
                Password = clientePassword
            };

            felipe.DTO.Models.Pedido pedido = new felipe.DTO.Models.Pedido
            {
                Id = 1,
                Peso = 100,
                Situacao = (int)StatusPedido.AGUARDANDO,
                DataHoraInclusao = DateTime.Now,
                DataHoraFinalizacao = DateTime.Now,
                Cliente = cliente
            };

            _pedidoRepository.SavePedidoAsync(pedido);

            Assert.Single(_pedidoRepository.ObterPedidos(pedidoId));
            Assert.Equal(_pedidoRepository.GetPedido(pedidoId).Cliente.Password, clientePassword);
        }
    }
}
