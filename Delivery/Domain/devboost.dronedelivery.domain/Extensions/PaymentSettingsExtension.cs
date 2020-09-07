using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Enums;
using System.Linq;

namespace devboost.dronedelivery.domain.Extensions
{
    public static class PaymentSettingsExtension
    {
        public static string GetUrlBase(this PaymentSettings paymentSettings, ETipoPagamento tipoPagamento)
        {
            return paymentSettings.PaymentsSettings.Where(FiltraTipoPagamento(tipoPagamento)).FirstOrDefault().UrlBase;
        }

        private static System.Func<PaymentSetting, bool> FiltraTipoPagamento(ETipoPagamento tipoPagamento)
        {
            return p => p.TipoPagamento == (int)tipoPagamento;
        }

    }
}
