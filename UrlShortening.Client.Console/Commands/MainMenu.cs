namespace UrlShortening.Client.Console.Commands
{
    public static class MainMenu
    {
        private const string options = """
            === UrlShortening Client ===

            1) Redirection by code
            2) Create
            3) Get code analytics

            0) Exit

            Select an option:
            """;

        public static void Show()
        {
            System.Console.WriteLine(options);
        }
    }
}
