using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Drone
{
    public class AssignDroneTests
    {
        private readonly DataContext _dataContext;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IDroneService _droneService;
        private readonly ICoordinateService _coordinateService;
        private readonly IPedidoDroneRepository _pedidoDroneRepository;
        public AssignDroneTests()
        {
            _dataContext = Substitute.For<DataContext>();
            _dataContext.Pedido = Substitute.For<DbSet<felipe.DTO.Models.Pedido>>();
            _dataContext.PedidoDrones = Substitute.For<DbSet<PedidoDrone>>();
            _clienteRepository = Substitute.For<IClienteRepository>();
            _pedidoService = Substitute.For<IPedidoService>();
            _droneRepository = Substitute.For<IDroneRepository>();
            _droneService = Substitute.For<IDroneService>();
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _coordinateService = Substitute.For<ICoordinateService>();
            _pedidoDroneRepository = Substitute.For<IPedidoDroneRepository>();
        }

        [Fact]
        public async Task TestMethodsCalled()
        {

            var pedidoFacade = new PedidoFacade(_dataContext,
                _pedidoService,
                _clienteRepository,
                _pedidoRepository,
                _droneRepository);

            var pedidos = SetupTests.GetPedidosList();
            _pedidoRepository.ObterPedidos(Arg.Any<int>())
                .Returns(pedidos);
            _clienteRepository.GetCliente(Arg.Any<int>())
                .Returns(SetupTests.GetCliente());
            _pedidoService.DroneAtendePedido(pedidos[0])
                .Returns(SetupTests.GetDroneDto());
            _droneRepository.GetDrone(Arg.Any<int>())
                .Returns(SetupTests.GetDrone());
            _pedidoRepository.GetPedido(Arg.Any<int>())
                .Returns(pedidos[0]);

            await pedidoFacade.AssignDrone(_pedidoRepository);


            await _pedidoService.Received().DroneAtendePedido(Arg.Any<felipe.DTO.Models.Pedido>());
            _dataContext.Pedido.Received().Update(Arg.Any<felipe.DTO.Models.Pedido>());
            _dataContext.PedidoDrones.Received().Add(Arg.Any<PedidoDrone>());
        }
        [Fact]
        public async Task TestDroneNotFound()
        {

            var pedidoFacade = new PedidoFacade(_dataContext,
                _pedidoService,
                _clienteRepository,
                _pedidoRepository,
                _droneRepository);

            var pedidos = SetupTests.GetPedidosList();
            _pedidoRepository.ObterPedidos(Arg.Any<int>())
                .Returns(pedidos);
            _clienteRepository.GetCliente(Arg.Any<int>())
                .Returns(SetupTests.GetCliente());

            _droneRepository.GetDrone(Arg.Any<int>())
                .Returns(SetupTests.GetDrone());
            _pedidoRepository.GetPedido(Arg.Any<int>())
                .Returns(pedidos[0]);

            await pedidoFacade.AssignDrone(_pedidoRepository);


            _dataContext.Pedido.DidNotReceive().Update(Arg.Any<felipe.DTO.Models.Pedido>());
        }
        [Fact]
        public async Task TestPedidoNotFound()
        {

            var pedidoFacade = new PedidoFacade(_dataContext,
                _pedidoService,
                _clienteRepository,
                _pedidoRepository,
                _droneRepository);

            _clienteRepository.GetCliente(Arg.Any<int>())
                .Returns(SetupTests.GetCliente());

            _droneRepository.GetDrone(Arg.Any<int>())
                .Returns(SetupTests.GetDrone());

            await pedidoFacade.AssignDrone(_pedidoRepository);


            _dataContext.Pedido.DidNotReceive().Update(Arg.Any<felipe.DTO.Models.Pedido>());
        }

        [Fact]
        public async Task TestDroneAtendePedidoQuandoDroneExiste()
        {
            var droneService = new DroneService(_coordinateService,
                _pedidoDroneRepository,
                _droneRepository,
                _pedidoRepository);
            var pedidoService = new PedidoService(droneService, _coordinateService);
            _coordinateService.GetKmDistance(Arg.Any<Point>(), Arg.Any<Point>())
                .Returns(10);
            _pedidoDroneRepository.RetornaPedidosEmAberto().Returns(SetupTests.GetPedidoDrones(StatusEnvio.AGUARDANDO));
            _droneRepository.RetornaDroneStatus(Arg.Any<int>())
                .Returns(SetupTests.GetDroneStatusDto());
            var drone = await pedidoService.DroneAtendePedido(SetupTests.GetPedido());
            Assert.True(drone != null);
        }

    }
}
