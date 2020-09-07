using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.pagamento.EF.Repositories.Interfaces;
using NSubstitute;
using System;
using Xunit;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;
using devboost.dronedelivery.pagamento.EF.Integration.Interfaces;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.pagamento.facade;
using System.Linq;

namespace devboost.Dronedelivery.Pagamento.Test
{
    public class PagamentoControllerTest
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IPagamentoIntegration _pagamentoIntegration;

        public PagamentoControllerTest()
        {
            devboost.dronedelivery.felipe.DTO.Models.Pagamento pagamento = new devboost.dronedelivery.felipe.DTO.Models.Pagamento
            {
                Id = 0,
                DataCriacao = DateTime.Now,
                Descricao = "Pagamento Teste",
                TipoPagamento = dronedelivery.felipe.DTO.Enums.ETipoPagamento.CARTAO,
                StatusPagamento = dronedelivery.felipe.DTO.Enums.EStatusPagamento.EM_ANALISE,
                DadosPagamentos = new System.Collections.Generic.List<DadosPagamento> { new DadosPagamento { Id = 0, Dados = "4220456798763234" } }

            };

            _pagamentoRepository = Substitute.For<IPagamentoRepository>();
            _pagamentoRepository.GetPagamentosEmAnaliseAsync().Returns(new List<devboost.dronedelivery.felipe.DTO.Models.Pagamento> { pagamento });


            devboost.dronedelivery.felipe.DTO.PagamentoStatusDto pagamentoStatusDto = new devboost.dronedelivery.felipe.DTO.PagamentoStatusDto
            {
                IdPagamento = pagamento.Id,
                Status = EStatusPagamento.APROVADO,
                Descricao = pagamento.Descricao
            };

            var listPagamentoStatusDto = new List<devboost.dronedelivery.felipe.DTO.PagamentoStatusDto> { pagamentoStatusDto };

            _pagamentoIntegration = Substitute.For<IPagamentoIntegration>(); 
            _pagamentoIntegration.ReportarResultadoAnalise(Arg.Is<List<devboost.dronedelivery.felipe.DTO.PagamentoStatusDto>>(x => x.First().IdPagamento == 0)).Returns(true);

        }

        [Fact]
        public void VerificarStatusPagamento()
        {
            PagamentoFacade pagamentoFacade = new PagamentoFacade(_pagamentoRepository, _pagamentoIntegration);

            var pagamentoStatus = pagamentoFacade.VerificarStatusPagamentos().Result;

            Assert.True(pagamentoStatus.First().Status == EStatusPagamento.APROVADO);
        }
    }
}
