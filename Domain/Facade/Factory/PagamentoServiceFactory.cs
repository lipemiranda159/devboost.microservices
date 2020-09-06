using devboost.dronedelivery.felipe.Services;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System;

namespace devboost.dronedelivery.felipe.Facade.Factory
{
    public class PagamentoServiceFactory : IPagamentoServiceFactory
    {
        private readonly PaymentSettings _paymentSettings;
        public PagamentoServiceFactory(PaymentSettings payment)
        {
            _paymentSettings = payment;
        }
        public IPagamentoServico GetPagamentoServico(ETipoPagamento tipoPagamento)
        {
            switch (tipoPagamento)
            {
                case ETipoPagamento.CARTAO:
                    return new PagamentoCartaoServico(_paymentSettings);
                default: throw new NotImplementedException("Servico não implementado!");
            }
        }
    }
}