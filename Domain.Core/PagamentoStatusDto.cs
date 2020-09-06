using devboost.dronedelivery.felipe.domain.core.Enums;

namespace devboost.dronedelivery.felipe.domain.core
{
    public class PagamentoStatusDto
    {
        public int IdPagamento { get; set; }
        public EStatusPagamento Status { get; set; }
        public string Descricao { get; set; }
    }
}
