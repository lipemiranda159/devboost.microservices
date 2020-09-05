using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class PedidoDroneRepositoryTests
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly PedidoDroneRepository _pedidoDroneRepository;
        private readonly DataContext _dataContext;
        private readonly IConfiguration _configuration;

        public PedidoDroneRepositoryTests()
        {
            var data = SetupTests.GetPedidoDrones(felipe.DTO.Enums.StatusEnvio.AGUARDANDO);
            _dataContext = ContextProvider<PedidoDrone>.GetContext(data);
            _configuration = Substitute.For<IConfiguration>();
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _droneRepository = Substitute.For<IDroneRepository>();
            _clienteRepository = Substitute.For<IClienteRepository>();
            _pedidoDroneRepository = new PedidoDroneRepository(_dataContext, _pedidoRepository,
                _droneRepository, _clienteRepository, _configuration);
        }

        [Fact]
        public void RetornaPedidosEmAbertoTest()
        {
            _pedidoRepository.GetPedido(Arg.Any<int>()).Returns(SetupTests.GetPedido());
            _clienteRepository.GetCliente(Arg.Any<int>()).Returns(SetupTests.GetCliente());

            var pedidos = _pedidoDroneRepository.RetornaPedidosEmAberto();
            Assert.True(pedidos.Count > 0);
        }

        [Fact]
        public void RetornaPedidosParaFecharAsync()
        {
            _pedidoRepository.GetPedido(Arg.Any<int>()).Returns(SetupTests.GetPedido());
            _clienteRepository.GetCliente(Arg.Any<int>()).Returns(SetupTests.GetCliente());

            var pedidos = _pedidoDroneRepository.RetornaPedidosParaFecharAsync();
            Assert.True(pedidos.Count == 0);
        }


    }
}
