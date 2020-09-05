using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.pagamento.EF;
using devboost.dronedelivery.pagamento.EF.Repositories.Interfaces;
using devboost.dronedelivery.pagamento.facade.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.facade
{
    public class PagamentoFacade : IPagamentoFacade
    {
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoFacade(IPagamentoRepository pagamentoRepository)
        {
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<Pagamento> CriarPagamento(PagamentoCreateDto pagamento)
        {
            Pagamento newPagamento = new Pagamento
            {
                DadosPagamentos = pagamento.DadosPagamentos,
                TipoPagamento = pagamento.TipoPagamento,
                StatusPagamento = EStatusPagamento.EM_ANALISE,
                DataCriacao = DateTime.Now,
                Descricao = pagamento.Descricao
            };

            await _pagamentoRepository.AddPagamentoAsync(newPagamento);

            return newPagamento;
        }

        private int RandomPagamento()
        {
            return new Random().Next(1, 2);
        }


        public async Task<IEnumerable<PagamentoStatusDto>> VerificarStatusPagamentos()
        {
            var pagamentosResult = await _pagamentoRepository.GetPagamentosEmAnaliseAsync();

            List<PagamentoStatusDto> pagamentos = new List<PagamentoStatusDto>();

            foreach (var pagamento in pagamentosResult)
            {
                var status = (EStatusPagamento)RandomPagamento();

                PagamentoStatusDto pagamentoStatusDto = new PagamentoStatusDto
                {
                    IdPagamento = pagamento.Id,
                    Status = status,
                    Descricao = pagamento.Descricao
                };

                pagamentos.Add(pagamentoStatusDto);

                AtualizarStatusPagamento(status, pagamento);
            }

            await _pagamentoRepository.SavePagamentoAsync();

            return pagamentos;
        }

        private void AtualizarStatusPagamento(EStatusPagamento eStatusPagamento, Pagamento pagamento)
        {
            pagamento.StatusPagamento = eStatusPagamento;
            _pagamentoRepository.SetState(pagamento, EntityState.Modified);
        }
    }
}
