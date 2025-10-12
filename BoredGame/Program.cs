namespace BoredGame;

internal static class Program
{
    private static void Main()
    {
        Console.WriteLine("---Starting Board Game---");
	
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
    }
}
