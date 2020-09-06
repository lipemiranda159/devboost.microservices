using devboost.dronedelivery.felipe.domain.core.Enums;
using devboost.dronedelivery.felipe.domain.core.Models;
using System.Collections.Generic;

namespace devboost.dronedelivery.felipe.domain.core
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
