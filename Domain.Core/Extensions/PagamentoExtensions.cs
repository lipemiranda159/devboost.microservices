using devboost.dronedelivery.felipe.domain.core.Models;

namespace devboost.dronedelivery.felipe.domain.core.Extensions
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
