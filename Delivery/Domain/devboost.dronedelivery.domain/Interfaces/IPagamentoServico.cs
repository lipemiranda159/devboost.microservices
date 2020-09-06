using devboost.dronedelivery.felipe.domain.core.Models;
using System.Threading.Tasks;

namespace devboost.dronedelivery.domain.Interfaces
{
    public interface IPagamentoServico
    {
        Task<Pagamento> RequisitaPagamento(Pagamento pagamento);
    }
}
