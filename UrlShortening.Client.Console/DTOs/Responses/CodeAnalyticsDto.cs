namespace UrlShortening.Client.Console.DTOs.Responses
{
    public sealed class CodeAnalyticsDto
    {
        public string Code { get; init; } = string.Empty;

        public int HitCount { get; init; }
        public DateTime? LastAccessAt { get; init; }
    }
}
