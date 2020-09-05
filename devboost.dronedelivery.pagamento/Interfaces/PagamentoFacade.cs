using devboost.dronedelivery.pagamento.Models;
using devboost.dronedelivery.pagamento.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static devboost.dronedelivery.pagamento.Models.StatusPagamento;

namespace devboost.dronedelivery.pagamento.Interfaces
{
    public class PagamentoFacade : IPagamentoFacade
    {
        private readonly DataContext _context;

        public PagamentoFacade(DataContext context)
        {
            _context = context;
        }

        public async Task<Pagamento> CriarPagamento(PagamentoCreateDto pagamento)
        {
            Pagamento newPagamento = new Pagamento
            {
                DadosPagamentos = pagamento.DadosPagamentos,
                TipoPagamento = pagamento.TipoPagamento,
                StatusPagamento = StatusPagamento.EStatusPagamento.EM_ANALISE,
                DataCriacao = DateTime.Now
            };

            _context.Pagamento.Add(newPagamento);
            await _context.SaveChangesAsync();

            return newPagamento;
        }

        private int RandomPagamento()
        {
            return new Random().Next(1, 2);
        }


        public async Task<IEnumerable<PagamentoStatusDto>> VerificarStatusPagamentos()
        {
            var pagamentosResult = await _context.Pagamento.Where(w => w.StatusPagamento == StatusPagamento.EStatusPagamento.EM_ANALISE).ToListAsync();

            List<PagamentoStatusDto> pagamentos = new List<PagamentoStatusDto>();

            foreach (var pagamento in pagamentosResult)
            {
                var status = (EStatusPagamento) RandomPagamento();

                PagamentoStatusDto pagamentoStatusDto = new PagamentoStatusDto
                {
                    IdPagamento = pagamento.Id,
                    Status = status,
                    Descricao = pagamento.Descricao
                };

                pagamentos.Add(pagamentoStatusDto);

                AtualizarStatusPagamento(status, pagamento);
            }

            await _context.SaveChangesAsync();

            return pagamentos;
        }

        private void AtualizarStatusPagamento(EStatusPagamento eStatusPagamento, Pagamento pagamento)
        {
            pagamento.StatusPagamento = eStatusPagamento;
            _context.Entry(pagamento).State = EntityState.Modified;
        }
    }
}
