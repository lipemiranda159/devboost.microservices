using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.DTO.Extensions
{
    public static class PagamentoExtensions
    {
        public static PagamentoCreateDto ToPagamentoCreate(this Pagamento pagamento)
        {
            return new PagamentoCreateDto()
            {
                DadosPagamentos = pagamento.DadosPagamentos,
                Descricao = pagamento.Descricao,
                TipoPagamento = pagamento.TipoPagamento
            };
        }
    }
}
