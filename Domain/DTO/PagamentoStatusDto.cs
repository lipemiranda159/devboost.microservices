using devboost.dronedelivery.felipe.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.DTO
{
    public class PagamentoStatusDto
    {
        public int IdPagamento { get; set; }
        public EStatusPagamento Status { get; set; }
        public string Descricao { get; set; }
    }
}
