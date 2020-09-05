using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.felipe.DTO
{
    public class PagamentoCreateDto
    {
        public List<DadosPagamento> DadosPagamentos { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }

        public string Descricao { get; set; }

        public PagamentoCreateDto()
        {
            DadosPagamentos = new List<DadosPagamento>();
        }
    }
}
