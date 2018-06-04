using System;

namespace RestSharpHelper
{
    public class WebClientException : Exception
    {
        public WebClientException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}