using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Facade.Interface
{
    public interface IPagamentoFacade
    {
        Task ProcessaPagamentosAsync(List<PagamentoStatusDto> pagamentoStatus);

    }
}
