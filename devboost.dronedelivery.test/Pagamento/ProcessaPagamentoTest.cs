using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Pagamento
{
    public class ProcessaPagamentoTest
    {
        private readonly IPedidoRepository _pedidoRepository;

        public ProcessaPagamentoTest()
        {
            _pedidoRepository = Substitute.For<IPedidoRepository>();
        }

        [Fact]
        public async Task ProcessaPagamentoTeste()
        {

            var pagamentoFacade = new PagamentoFacade(_pedidoRepository);

            var listaPagamentos = new List<PagamentoStatusDto>();
            listaPagamentos.Add(new PagamentoStatusDto()
            {
                Descricao = "Pagamento Teste",
                IdPagamento = 1,
                Status = felipe.DTO.Enums.EStatusPagamento.APROVADO
            });

            _pedidoRepository.PegaPedidoPendenteAsync(Arg.Any<string>()).Returns(SetupTests.GetPedido());

            await pagamentoFacade.ProcessaPagamentosAsync(listaPagamentos);

            await _pedidoRepository.Received().OnlySalveContext();

        }



    }
}
