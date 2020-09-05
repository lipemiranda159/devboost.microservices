using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Services.Interfaces;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using devboost.dronedelivery.felipe.DTO.Extensions;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Constants;
using System;

namespace devboost.dronedelivery.felipe.Services
{
    public class PagamentoCartaoServico : IPagamentoServico
    {
        private readonly string _urlBase;
        public PagamentoCartaoServico(PaymentSettings paymentSettings)
        {
            _urlBase = paymentSettings.GetUrlBase(ETipoPagamento.CARTAO);
        }

        public async Task RequisitaPagamento(Pagamento pagamento)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_urlBase);
                var request = JsonSerializer.Serialize(pagamento);
                var httpContent = new StringContent(request, Encoding.UTF8);
                await client.PostAsync(ProjectConsts.PAGAMENTO_URI, httpContent);
            }
        }
    }
}
