using Newtonsoft.Json;
using System;

namespace devboost.dronedelivery.Services
{
    public static class JSONHelper
    {
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
