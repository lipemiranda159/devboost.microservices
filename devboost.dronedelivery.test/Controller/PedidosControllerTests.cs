using devboost.dronedelivery.felipe.Controllers;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Controller
{
    public class PedidosControllerTests
    {
        private readonly IPedidoFacade _pedidoFacade;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidosControllerTests()
        {
            _pedidoFacade = Substitute.For<IPedidoFacade>();
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _clienteRepository = Substitute.For<IClienteRepository>();
        }
        [Fact]
        public async Task TestAssignDrone()
        {
            var pedidosController = new PedidosController(_pedidoRepository, _pedidoFacade, _clienteRepository);
            await pedidosController.AssignDrone();
            await _pedidoFacade.Received().AssignDrone(_pedidoRepository);

        }
        [Fact]
        public async Task TestPostPedido()
        {
            _clienteRepository.GetCliente(Arg.Any<int>()).
                Returns(SetupTests.GetCliente());

            var pedidosController = new PedidosController(_pedidoRepository, _pedidoFacade, _clienteRepository);
            var pedido = await pedidosController.PostPedido(SetupTests.GetPedido());
            await _pedidoRepository.Received().SavePedidoAsync(Arg.Any<felipe.DTO.Models.Pedido>());
            Assert.True(pedido.Value.Situacao == (int)StatusPedido.AGUARDANDO);

        }

    }
}
