using devboost.dronedelivery.core.domain;
using devboost.dronedelivery.domain.Constants;
using devboost.dronedelivery.pagamento.EF.Integration.Interfaces;
using devboost.dronedelivery.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace devboost.dronedelivery.pagamento.EF.Integration
{
    public class PagamentoIntegration : IPagamentoIntegration
    {
        private readonly string _urlBase;

        public PagamentoIntegration(DeliverySettingsData deliverySettings)
        {
            _urlBase = deliverySettings.UrlBase;
        }

        public async Task<bool> ReportarResultadoAnalise(List<PagamentoStatusDto> listaPagamentos)
        {
            var httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
            };

            using var httpClient = new HttpClient(httpClientHandler, false);

            string finalUri = string.Concat(_urlBase, ProjectConsts.DELIVERY_URI);

            var apiDeliveryResponse = await httpClient.PostAsync(finalUri, JSONHelper.ConvertObjectToByteArrayContent<List<PagamentoStatusDto>>(listaPagamentos));

            if (apiDeliveryResponse.IsSuccessStatusCode)
                return true;
            else
                return false;

        }
    }
}
