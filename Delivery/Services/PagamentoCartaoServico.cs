using devboost.dronedelivery.domain.core;
using devboost.dronedelivery.domain.core.Entities;
using devboost.dronedelivery.domain.core.Enums;
using devboost.dronedelivery.domain.core.Extensions;
using devboost.dronedelivery.domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Services
{
    public class PagamentoCartaoServico : IPagamentoServico
    {
        private const string MEDIA_TYPE = "application/json";
        private readonly string _urlBase;
        public PagamentoCartaoServico(PaymentSettings paymentSettings)
        {
            _urlBase = paymentSettings.GetUrlBase(ETipoPagamento.CARTAO);
        }

        public async Task<Pagamento> RequisitaPagamento(Pagamento pagamento)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(_urlBase)
            };

            var request = JsonConvert.SerializeObject(pagamento.ToPagamentoCreate());
            var httpContent = new StringContent(request, Encoding.UTF8, MEDIA_TYPE);
            var gatewayResponse = await client.PostAsync(ProjectConsts.PAGAMENTO_URI, httpContent);
            if (gatewayResponse.IsSuccessStatusCode)
            {
                var response = await gatewayResponse.Content.ReadAsStringAsync();
                return JSONHelper.DeserializeJsonToObject<Pagamento>(response);
            }
            else throw new Exception("Falha no pagamento");
        }
    }
}
