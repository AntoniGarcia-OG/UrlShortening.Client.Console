namespace UrlShortening.Client.Console.DTOs.Requests
{
    public sealed class CreateCodeDto
    {
        public string OriginalUrl { get; init; } = string.Empty;
    }
}
