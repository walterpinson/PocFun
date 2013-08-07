namespace Infrastructure.PocFunApi.Utilities
{
    using System.Net;

    using Newtonsoft.Json;

    using Messages;

    public class TokenServiceProxy
    {
        private string apiBaseUrl = "http://security.pocfun.wp.dev/api/";

        public bool TokenIsValid(TokenValidationRequest tokenValidationRequest)
        {
            var apiResource = "TokenValidation";
            var address = apiBaseUrl + apiResource;
            var jsonRequest = JsonConvert.SerializeObject(tokenValidationRequest);

            var client = new WebClient();
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
            client.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

            var token = JsonConvert.DeserializeObject<bool>(client.UploadString(address, jsonRequest));

            return token;
        }
    }
}