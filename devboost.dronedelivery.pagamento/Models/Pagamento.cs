using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static devboost.dronedelivery.pagamento.Models.StatusPagamento;

namespace devboost.dronedelivery.pagamento.Models
{
    public class Pagamento
    {
        [Key]
        public int Id { get; set; }

        public List<DadosPagamento> DadosPagamentos { get; set; }
        public ETipoPagamento TipoPagamento { get; set; }

        public EStatusPagamento StatusPagamento { get; set; }

        public string Descricao { get; set; }

        public DateTime DataCriacao { get; set; }

        public Pagamento()
        {
            DadosPagamentos = new List<DadosPagamento>();
        }
    }
}
