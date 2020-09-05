using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace devboost.dronedelivery.felipe.Services
{
    public static class JSONHelper
    {
        public static ByteArrayContent ConvertObjectToByteArrayContent<T>(T valor)
        {
            ByteArrayContent byteContent = new ByteArrayContent((Encoding.UTF8.GetBytes((JsonConvert.SerializeObject(valor)))));
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        public static dynamic DeserializeJsonToObject<T>(string json)
        {
            object objectConversion = JsonConvert.DeserializeObject<T>(json);
            return (T)Convert.ChangeType(objectConversion, typeof(T));
        }

        public static dynamic DeserializeJObject<T>(Object jObject)
        {
            return ((Newtonsoft.Json.Linq.JObject)jObject).ToObject<T>();
        }
    }

}
