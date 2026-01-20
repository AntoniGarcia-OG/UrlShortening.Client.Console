using System.Net.Http.Json;
using UrlShortening.Client.Console.DTOs.Requests;
using UrlShortening.Client.Console.DTOs.Responses;

namespace UrlShortening.Client.Console.Http
{
    public sealed class UrlShorteningHttpClient
    {
        private readonly HttpClient _httpClient;

        public UrlShorteningHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        private static async Task<HttpException> CreateHttpException(HttpResponseMessage responseMessage)
        {
            string message = await responseMessage.Content.ReadAsStringAsync();

            return new HttpException((int)responseMessage.StatusCode, message);
        }
    }
}
