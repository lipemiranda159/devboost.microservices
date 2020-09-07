﻿using devboost.dronedelivery.domain.core.Entities;

namespace devboost.dronedelivery.domain.core.Extensions
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
