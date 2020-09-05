using devboost.dronedelivery.felipe.DTO.Models;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Services.Interfaces
{
    public interface IPagamentoServico
    {
        Task<string> RequisitaPagamento(Pagamento pagamento);
    }
}
