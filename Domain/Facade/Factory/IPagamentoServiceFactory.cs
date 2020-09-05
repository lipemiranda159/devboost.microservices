using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.Facade.Factory
{
    public interface IPagamentoServiceFactory
    {
        IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento);
    }
}
