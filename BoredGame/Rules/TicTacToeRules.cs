using BoredGame.Boards;

namespace BoredGame.Rules;

public class TicTacToeRules : IRules
{
    public void ApplyRules(IBoard board) => Console.WriteLine("Placeholder CheckRules");
    public bool IsGameOver() => false;
}