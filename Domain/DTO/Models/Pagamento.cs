using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.DTO.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        public List<DadosPagamento> DadosPagamentos { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }

        public Pagamento()
        {
            DadosPagamentos = new List<DadosPagamento>();
        }
    }

}
