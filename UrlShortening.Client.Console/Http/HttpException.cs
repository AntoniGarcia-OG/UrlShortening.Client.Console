namespace UrlShortening.Client.Console.Http
{
    public sealed class HttpException : Exception
    {
        public int StatusCode { get; }

        public HttpException(int statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
