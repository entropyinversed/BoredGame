using BoredGame.Boards;

namespace BoredGame.Rules;

public interface IRules
{
    void ApplyRules(IBoard board);
    bool IsGameOver();
}