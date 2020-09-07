using devboost.dronedelivery.domain.core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IPagamentoFacade
    {
        Task ProcessaPagamentosAsync(List<PagamentoStatusDto> pagamentoStatus);

    }
}
