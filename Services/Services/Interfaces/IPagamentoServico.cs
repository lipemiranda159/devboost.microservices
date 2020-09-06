using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Services.Interfaces
{
    public interface IPagamentoServico
    {
        Task<Pagamento> RequisitaPagamento(Pagamento pagamento);
    }
}
