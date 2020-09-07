using devboost.dronedelivery.domain.core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.EF.Repositories.Interfaces
{
    public interface IPagamentoRepository
    {
        Task<List<Pagamento>> GetPagamentosEmAnaliseAsync();
        Task AddPagamentoAsync(Pagamento pagamento);
        void SetState(Pagamento pagamento, EntityState entityState);
        Task SavePagamentoAsync();

    }
}
