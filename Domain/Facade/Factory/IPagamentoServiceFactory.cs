using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.Services.Interfaces;

namespace devboost.dronedelivery.felipe.Facade.Factory
{
    public interface IPagamentoServiceFactory
    {
        IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento);
    }
}
