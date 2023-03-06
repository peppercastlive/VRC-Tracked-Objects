using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRC_OSC_ExternallyTrackedObject.Peppercast.Extensions
{
    public static class JObjectExt
    {
        public static T GetValueOrDefault<T>(this JObject instance, string value, T defaultValue)
        {
            JToken token;
            var hasToken = instance.TryGetValue(value, out token);

            return hasToken ? token.Value<T>() : defaultValue;
        }
    }
}
