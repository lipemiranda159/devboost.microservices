using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.facade.Interfaces
{
    public interface IPagamentoFacade
    {
        Task<IEnumerable<PagamentoStatusDto>> VerificarStatusPagamentos();

        Task<Pagamento> CriarPagamento(PagamentoCreateDto pagamento);

    }
}
