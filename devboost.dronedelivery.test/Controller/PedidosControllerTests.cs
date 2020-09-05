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
        private readonly IClienteRepository _clienteRepository;

        public PedidosControllerTests()
        {
            _pedidoFacade = Substitute.For<IPedidoFacade>();
            _clienteRepository = Substitute.For<IClienteRepository>();
        }
        [Fact]
        public async Task TestAssignDrone()
        {
            var pedidosController = new PedidosController(_pedidoFacade);
            await pedidosController.AssignDrone();
            await _pedidoFacade.Received().AssignDroneAsync();

        }
        [Fact]
        public async Task TestPostPedido()
        {
            _clienteRepository.GetCliente(Arg.Any<int>()).
                Returns(SetupTests.GetCliente());

            var pedidosController = new PedidosController(_pedidoFacade);
            var pedido = await pedidosController.PostPedido(SetupTests.GetPedido());
            await _pedidoFacade.Received().CreatePedidoAsync(Arg.Any<felipe.DTO.Models.Pedido>());

        }

    }
}
