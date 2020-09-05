using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.Facade.Factory
{
    public class PagamentoServiceFactory : IPagamentoServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento)
        {
            switch (tipoPagamento)
            {
                case ETipoPagamento.CARTAO:
                    return _serviceProvider.GetService<PagamentoCartaoServico>();
                default: throw new NotImplementedException("Servico não implementado!");
            }
        }
    }
}