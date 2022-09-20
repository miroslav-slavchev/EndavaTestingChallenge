using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Reqres.Library.Utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reqres.Tests.APICLient
{
    public class ReqresRestResponse<T> where T : class
    {
        public ReqresRestResponse(RestResponse restResponse)
        {
            RestResponse = restResponse;
            if (JToken.Parse(restResponse.Content).IsNullOrEmpty())
            {
                DeserializedContent = new();
            }
            else
            {
                DeserializedContent = new(JsonConvert.DeserializeObject<T>(restResponse.Content));
            }

        }

        public RestResponse RestResponse { get; }

        public Maybe<T> DeserializedContent { get; }
    }
}
