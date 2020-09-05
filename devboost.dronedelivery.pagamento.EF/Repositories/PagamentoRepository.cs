using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.pagamento.EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.EF.Repositories
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly DataContext _context;
        public PagamentoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddPagamentoAsync(Pagamento pagamento)
        {
            _context.Pagamento.Add(pagamento);
            await SavePagamentoAsync();
        }

        public async Task<List<Pagamento>> GetPagamentosEmAnaliseAsync()
        {
            return await _context.Pagamento.Where(w => w.StatusPagamento.EmAnalise()).ToListAsync();
        }

        public async Task SavePagamentoAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SetState(Pagamento pagamento,EntityState entityState)
        {
            _context.Entry(pagamento).State = EntityState.Modified;
        }
    }
}
