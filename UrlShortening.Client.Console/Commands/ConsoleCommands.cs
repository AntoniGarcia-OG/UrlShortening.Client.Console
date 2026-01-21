using UrlShortening.Client.Console.DTOs.Responses;
using UrlShortening.Client.Console.Http;

namespace UrlShortening.Client.Console.Commands
{
    public sealed class ConsoleCommands
    {
        private readonly UrlShorteningHttpClient _client;

        public ConsoleCommands(UrlShorteningHttpClient client)
        {
            _client = client;
        }

        public async Task RedirectionByCode()
        {
            System.Console.Write("Enter code: ");

            string code = System.Console.ReadLine()!;

            HttpResponseMessage result = await _client.ResolveAndUpdateDataAsync(code);

            System.Console.WriteLine();
            
            System.Console.WriteLine($"Resolution status: {result.StatusCode}");
            System.Console.WriteLine($"Resolved URL: {result.Headers.Location}");
        }

        public async Task Create()
        {
            System.Console.Write("Enter URL: ");

            string url = System.Console.ReadLine()!;

            CodeResponseDto result = await _client.CreateAsync(url);

            System.Console.WriteLine();
            
            System.Console.WriteLine($"Generated code: {result.Code}");
            System.Console.WriteLine($"Created at: {result.CreatedAt}");
        }

        public async Task GetCodeAnalytics()
        {
            System.Console.Write("Enter code: ");

            string code = System.Console.ReadLine()!;

            CodeAnalyticsDto result = await _client.GetCodeAnalyticsAsync(code);

            System.Console.WriteLine();
            
            System.Console.WriteLine($"Code: {result.Code}");

            System.Console.WriteLine();
            
            System.Console.WriteLine($"Total accesses: {result.HitCount}");
            System.Console.WriteLine($"Last access: {result.LastAccessAt}");
        }
    }
}
