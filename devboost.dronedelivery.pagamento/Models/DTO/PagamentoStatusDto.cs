using static devboost.dronedelivery.pagamento.Models.StatusPagamento;

namespace devboost.dronedelivery.pagamento.Models.DTO
{
    public class PagamentoStatusDto
    {
        public int IdPagamento { get; set; }
        public EStatusPagamento Status { get; set; }
        public string Descricao { get; set; }

    }
}
