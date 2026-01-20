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

        public async Task<HttpResponseMessage> ResolveAndUpdateDataAsync(string code)
        {
            HttpResponseMessage result = await _httpClient.GetAsync($"/redirect/{code}", HttpCompletionOption.ResponseHeadersRead);

            if (result.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new HttpException(404, "Not Found");
            }

            return result;
        }

        private static async Task<HttpException> CreateHttpException(HttpResponseMessage responseMessage)
        {
            string message = await responseMessage.Content.ReadAsStringAsync();

            return new HttpException((int)responseMessage.StatusCode, message);
        }
    }
}
