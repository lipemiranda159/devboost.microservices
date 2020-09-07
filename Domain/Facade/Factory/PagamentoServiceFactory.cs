using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace devboost.dronedelivery.felipe.Facade.Factory
{
    public class PagamentoServiceFactory : IPagamentoServiceFactory
    {
        private readonly PaymentSettings _paymentSettings;
        private readonly IHttpHandler _httpHandler;
        public PagamentoServiceFactory(PaymentSettings payment, IHttpHandler httpHandler)
        {
            _paymentSettings = payment;
            _httpHandler = httpHandler;
        }
        public IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento)
        {
            switch (tipoPagamento)
            {
                case ETipoPagamento.CARTAO:
                    return new PagamentoCartaoServico(_paymentSettings, _httpHandler);
                default: throw new NotImplementedException("Servico não implementado!");
            }
        }
    }
}