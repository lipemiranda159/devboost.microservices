using devboost.dronedelivery.felipe.DTO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
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
