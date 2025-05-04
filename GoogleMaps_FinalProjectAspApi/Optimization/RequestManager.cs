using GoogleMaps_FinalProjectAspApi.SearchRequestCreation;
using System.Text.Json;
using System.Text;

namespace GoogleMaps_FinalProjectAspApi.Optimization
{
    public class RequestManager
    {
        public static HttpRequestMessage CreateRequest<T>(string requestUri, MapsHeaders headers, GoogleMapsAuthorization authorization, T requestBody)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUri);

            var headersDict = headers.RequestHeaders;
            foreach (var header in headersDict)
            {
                request.Headers.Add(header.Key, header.Value);
            }
            request.Headers.Add(authorization.ApiKeyName, authorization.ApiKeyValue);


            request.Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            return request;
        }

        public static async Task<string> SendRequest(HttpRequestMessage request, HttpClient httpClient)
        {
            var response = await httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var responseResult = await response.Content.ReadAsStringAsync();

            return responseResult;
        }

    }
}
