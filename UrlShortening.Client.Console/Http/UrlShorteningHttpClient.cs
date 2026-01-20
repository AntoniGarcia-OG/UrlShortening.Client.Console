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

        public async Task<CodeResponseDto> CreateAsync(string originalUrl)
        {
            CreateCodeDto dto = new() { OriginalUrl = originalUrl };

            HttpResponseMessage result = await _httpClient.PostAsJsonAsync("/api/UrlMapping", dto);

            if (!result.IsSuccessStatusCode)
            {
                throw await CreateHttpException(result);
            }

            return (await result.Content.ReadFromJsonAsync<CodeResponseDto>())!;
        }

        public async Task<CodeAnalyticsDto> GetCodeAnalyticsAsync(string code)
        {
            HttpResponseMessage result = await _httpClient.GetAsync($"/api/UrlMapping/{code}/analytics");

            if (!result.IsSuccessStatusCode)
            {
                throw await CreateHttpException(result);
            }

            return (await result.Content.ReadFromJsonAsync<CodeAnalyticsDto>())!;
        }

        private static async Task<HttpException> CreateHttpException(HttpResponseMessage responseMessage)
        {
            string message = await responseMessage.Content.ReadAsStringAsync();

            return new HttpException((int)responseMessage.StatusCode, message);
        }
    }
}
