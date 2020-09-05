using devboost.dronedelivery.felipe.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace devboost.dronedelivery.felipe.DTO.Models
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

        public bool ContemFormaDePagamento()
        {
            return DadosPagamentos.Count > 0 && TipoPagamento != ETipoPagamento.INDEFINIDO;
        }
    }

}
