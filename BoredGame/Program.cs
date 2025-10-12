using Microsoft.Extensions.Logging;

namespace BoredGame;

internal static class Program
{
    private static void Main()
    {
        using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
        ILogger logger = factory.CreateLogger("Program");
        logger.LogInformation("Just a logging test!");

        Console.WriteLine("Quick Test");
        Console.WriteLine("---Starting Board Game---");
	
        //TestClass(logger).LogAgain();

        TestClass testClass = new TestClass(logger);
        testClass.LogAgain();
/*
	    var gameType = InputManager.PromptForGameType();
        var game = GameFactory.CreateGame(gameType);
        game.Start();
        game.DisplayBoard();

        while (!game.IsGameOver())
        {
            Console.WriteLine("Inside Game Loop");
	        game.PlayTurn();
            game.DisplayBoard();
        }
*/
    }
}

public class TestClass(ILogger logger)
{
    public void LogAgain()
    {
        Console.WriteLine("here we are bro");
        logger.LogInformation("Im in here now");
    }
}
