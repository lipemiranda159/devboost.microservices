using devboost.dronedelivery.felipe.DTO.Enums;

namespace devboost.dronedelivery.felipe.DTO
{
    public class PagamentoStatusDto
    {
        public int IdPagamento { get; set; }
        public EStatusPagamento Status { get; set; }
        public string Descricao { get; set; }
    }
}
