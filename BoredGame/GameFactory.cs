using BoredGame.Boards;
using BoredGame.Games;
using BoredGame.Rules;

namespace BoredGame;

public enum GameType
{
    TicTacToe,
    ConnectFour
}

public static class GameFactory
{
    public static IGame CreateGame(GameType gameType)
    {
        Console.WriteLine("---Creating The Game---");

        return gameType switch
        {
            GameType.TicTacToe => new TicTacToeGame(new TicTacToeBoard(), new TicTacToeRules()),
            GameType.ConnectFour => new ConnectFourGame(new ConnectFourBoard(), new ConnectFourRules()),
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), "Unsupported game type.")
        };
    }
}
