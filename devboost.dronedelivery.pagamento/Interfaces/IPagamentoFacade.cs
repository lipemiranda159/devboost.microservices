using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.Interfaces
{
    public interface IPagamentoFacade
    {
        Task<IEnumerable<PagamentoStatusDto>> VerificarStatusPagamentos();

        Task<Pagamento> CriarPagamento(PagamentoCreateDto pagamento);
    }
}
