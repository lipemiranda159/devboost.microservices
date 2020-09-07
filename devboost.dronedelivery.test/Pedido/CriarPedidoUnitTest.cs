using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using devboost.dronedelivery.felipe.Facade.Factory;
using devboost.dronedelivery.felipe.Services.Interfaces;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Pedido
{
    public class CriarPedidoUnitTest
    {

        private readonly DataContext _dataContext;
        private readonly IPedidoService _pedidoService;
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IDroneRepository _droneRepository;
        private readonly IPagamentoServiceFactory _pagamentoServiceFactory;
        private readonly IPagamentoServico _pagamentoServico;

        public CriarPedidoUnitTest()
        {
            _dataContext = Substitute.For<DataContext>();
            _pedidoService = Substitute.For<IPedidoService>();
            _clienteRepository = Substitute.For<IClienteRepository>();
            _pedidoRepository = Substitute.For<IPedidoRepository>();
            _droneRepository = Substitute.For<IDroneRepository>();
            _pagamentoServiceFactory = Substitute.For<IPagamentoServiceFactory>();
            _pagamentoServico = Substitute.For<IPagamentoServico>(); 
        }

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

        [Fact]
        public async Task CriarPedidoAsync()
        {
            
            var pedido = new PedidoFacade(_dataContext, _pedidoService, _clienteRepository, _pedidoRepository, _droneRepository, _pagamentoServiceFactory);

            _clienteRepository.GetCliente(Arg.Any<int>()).Returns(SetupTests.GetCliente());
            _pagamentoServiceFactory.GetPagamentoServico(ETipoPagamento.CARTAO).Returns(_pagamentoServico);
            _pagamentoServico.RequisitaPagamento(Arg.Any<felipe.DTO.Models.Pagamento>()).Returns(SetupTests.GetPagamento());

            var result = await pedido.CreatePedidoAsync(SetupTests.GetPedido());

            Assert.NotNull(result);
        }
    }
}
