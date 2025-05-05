using BoredGame.Boards;
using BoredGame.Rules;

namespace BoredGame.Games;

public class TicTacToeGame(IBoard board, IRules rules) : IGame
{
    private bool _isGameOver;
    
    public void Start()
    {
        board.Setup();
        _isGameOver = false;
    }

    public void PlayTurn()
    {
        Console.WriteLine("play turn");
        rules.ApplyRules(board);
    }
    
    public bool IsGameOver() => _isGameOver;

    public void DisplayBoard() => board.Display();
}