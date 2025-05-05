using BoredGame.Boards;
using BoredGame.Games;
using BoredGame.Rules;

namespace BoredGame;

public enum GameType
{
    TicTacToe
}

public static class GameFactory
{
    public static IGame CreateGame(GameType gameType)
    {
        return gameType switch
        {
            GameType.TicTacToe => new TicTacToeGame(new TicTacToeBoard(), new TicTacToeRules()),
            _ => throw new ArgumentOutOfRangeException(nameof(gameType), "Unsupported game type.")
        };
    }
}