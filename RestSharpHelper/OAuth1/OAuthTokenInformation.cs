namespace RestSharpHelper.OAuth1
{
    public class OAuthTokenInformation 
    {
        public string Token { get; }
        public string TokenSecret { get; }

        public bool PartialOrValid => Token != null;
        public bool Valid => ((Token != null) && (TokenSecret != null));

        public OAuthTokenInformation(string token, string tokenSecret) 
        {
            Token = token;
            TokenSecret = tokenSecret;
        }
    }
}
