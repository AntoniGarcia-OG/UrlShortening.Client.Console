using Microsoft.Extensions.Configuration;
using UrlShortening.Client.Console.Commands;
using UrlShortening.Client.Console.Configuration;
using UrlShortening.Client.Console.Http;

IConfigurationRoot configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

ApiOptions apiOptions = configuration.GetSection("ApiOptions").Get<ApiOptions>()!;

HttpClient httpClient = new()
{
    BaseAddress = new Uri(apiOptions.BaseUrl)
};
UrlShorteningHttpClient client = new(httpClient);

ConsoleCommands commands = new(client);

while (true)
{
    MainMenu.Show();

    string choice = Console.ReadLine()!;

	Console.WriteLine();
	try
	{
	}
	catch (HttpException exception)
	{
        Console.WriteLine($"Error: API returned {exception.StatusCode} — {exception.Message}");
	}
}