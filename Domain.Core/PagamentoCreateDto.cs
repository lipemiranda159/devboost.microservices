using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.core.Enums;
using System.Collections.Generic;

namespace devboost.dronedelivery.domain.core
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
