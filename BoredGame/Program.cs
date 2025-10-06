namespace BoredGame;

internal static class Program
{
    // Quick GIT user check.
    private static void Main()
    {
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
