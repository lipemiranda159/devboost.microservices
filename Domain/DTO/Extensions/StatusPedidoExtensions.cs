using devboost.dronedelivery.felipe.DTO.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.DTO.Extensions
{
    public static class StatusPedidoExtensions
    {
        public static bool IsSuccess(this EStatusPagamento statusPagamento)
        {
            return statusPagamento == (int)EStatusPagamento.SUCESSO;
        }
    }
}
