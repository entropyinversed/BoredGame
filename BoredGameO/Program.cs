using Microsoft.Extensions.Logging;
using BoredGame.UI;

namespace BoredGame;

internal static class Program
{
    private static void Main()
    {
        using var factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        logger.LogInformation("Logger has been created");

	    var gameType = InputManager.PromptForGameType();
        var game = GameFactory.CreateGame(gameType);
        game.Start();
        game.DisplayBoard();

        while (!game.IsGameOver())
        {
	        game.PlayTurn();
            game.DisplayBoard();
        }
    }
}