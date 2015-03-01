using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SimpleSupport.Classes
{
    /// <summary>
    /// Converts a JSON string(json) to the class(t)
    /// http://stackoverflow.com/questions/13839865/how-to-parse-my-json-string-in-c4-0using-newtonsoft-json-package
    /// </summary>
    public static class JsonToObject
    {
        public static T ParseJsonObject<T>(string json) where T : class, new()
        {
            JObject jobject = JObject.Parse(json);
            return JsonConvert.DeserializeObject<T>(jobject.ToString());
        }
    }
}