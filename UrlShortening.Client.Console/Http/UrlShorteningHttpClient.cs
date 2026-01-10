namespace UrlShortening.Client.Console.Http
{
    public sealed class UrlShorteningHttpClient
    {
        private readonly HttpClient _httpClient;

        public UrlShorteningHttpClient(HttpClient httpClient) => _httpClient = httpClient;


    }
}
