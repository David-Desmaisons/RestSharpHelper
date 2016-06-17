using System;

namespace RestSharpHelper
{
    [Serializable]
    public class WebClientException : Exception
    {
        public WebClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}