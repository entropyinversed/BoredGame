using BoredGame.UI;

namespace BoredGame;

internal static class Program
{
    private static void Main()
    {
	    var gameType = UserInput.PromptForGameType();
        var game = GameFactory.CreateGame(gameType);
        game.Initialize();
        game.DisplayBoard();

        while (!game.IsGameOver())
        {
	        game.PlayTurn();
            Renderer.DrawBoard(game.TicTacToeBoard());
        }
    }
}