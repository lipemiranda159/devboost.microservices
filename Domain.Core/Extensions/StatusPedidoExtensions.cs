using devboost.dronedelivery.felipe.domain.core.Enums;

namespace devboost.dronedelivery.felipe.domain.core.Extensions
{
    public static class StatusPedidoExtensions
    {
        public static bool IsSuccess(this EStatusPagamento statusPagamento)
        {
            return statusPagamento == EStatusPagamento.APROVADO;
        }

        public static bool EmAnalise(this EStatusPagamento statusPagamento)
        {
            return statusPagamento == EStatusPagamento.EM_ANALISE;
        }
    }
}
