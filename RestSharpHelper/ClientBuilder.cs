using System;
using RestSharp;

namespace RestSharpHelper
{
    public class ClientBuilder
    {
        public static Func<string, IRestClient> Build { get; set; }

        static ClientBuilder()
        {
            Build = (url) => new RestClient(url);
        }
    }
}
