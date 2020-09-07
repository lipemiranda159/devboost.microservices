using devboost.dronedelivery.domain.core.Enums;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IPagamentoServiceFactory
    {
        IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento);
    }
}
