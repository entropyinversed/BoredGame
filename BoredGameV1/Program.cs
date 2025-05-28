namespace BoredGame;

internal static class Program
{
    private static void Main()
    {
        var gameType = PromptForGameType();
        var game = GameFactory.CreateGame(gameType);
        game.Start();
        game.DisplayBoard();

        while (!game.IsGameOver())
        {
            game.PlayTurn();
            game.DisplayBoard();
        }
    }

    private static GameType PromptForGameType()
    {
        while (true)
        {
            Console.WriteLine(
                "Choose a Game: [" + string.Join(", ", Enum.GetNames<GameType>()) + "]"
            );
            
            var input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input)
                && Enum.TryParse<GameType>(input.Trim(), ignoreCase: true, out var gameType)
                && Enum.IsDefined(typeof(GameType), gameType))
            {
                return gameType;
            }
            
            Console.WriteLine($"Sorry, \"{input}\" is not a valid game type.");
            
            // Just a test Apple commit!
        }
    }
}