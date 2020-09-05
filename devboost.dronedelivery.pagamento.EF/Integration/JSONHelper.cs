using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace devboost.dronedelivery.pagamento.EF.Integration
{
    public static class JSONHelper
    {
        public static dynamic DeserializeJsonToObject<T>(string json)
        {
            object objectConversion = JsonConvert.DeserializeObject<T>(json);
            return (T)Convert.ChangeType(objectConversion, typeof(T));
        }

        public static ByteArrayContent ConvertObjectToByteArrayContent<T>(T valor)
        {
            ByteArrayContent byteContent = new ByteArrayContent((Encoding.UTF8.GetBytes((JsonConvert.SerializeObject(valor)))));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json-patch+json");

            return byteContent;
        }
    }
}
