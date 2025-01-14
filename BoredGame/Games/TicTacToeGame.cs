using BoredGame.Boards;
using BoredGame.Rules;

namespace BoredGame;

public class TicTacToeGame : IGame
{
    private readonly IBoard _board;
    private readonly IRules _rules;
    private bool _isGameOver;

    public TicTacToeGame(IBoard board, IRules rules)
    {
        _board = board;
        _rules = rules;
    }

    public void Start()
    {
        _board.Setup();
        _isGameOver = false;
    }

    public void PlayTurn()
    {
        Console.WriteLine("play turn");
        _rules.ApplyRules(_board);
    }
    
    public bool IsGameOver() => _isGameOver;

    public void DisplayBoard() => _board.Display();
}