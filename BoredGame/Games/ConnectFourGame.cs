using BoredGame.Boards;
using BoredGame.Rules;

namespace BoredGame.Games;

public class ConnectFourGame(IBoard board, IRules rules) : IGame
{
    private bool _isGameOver;
    private char _currentMark = '0';

    public void Start()
    {
        board.Setup();
        _isGameOver = false;
    }

    public void PlayTurn()
    {
        while (true)
        {
            Console.Write($"Player {_currentMark}, enter row and column (0-3, 0-3): ");
            var parts = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts?.Length == 2 &&
                int.TryParse(parts[0], out var row) &&
                int.TryParse(parts[1], out var col) &&
                (board as ConnectFourBoard)?.TryPlaceMark(row, col, _currentMark) == true)
            {
                break;
            }
            
            Console.WriteLine("Invalid move, please try again.");
        }
        
        rules.ApplyRules(board);
        _isGameOver = rules.IsGameOver();
        _currentMark = _currentMark == 'X' ? '0' : 'X';
    }

    public bool IsGameOver() => _isGameOver;
    
    public void DisplayBoard() => board.Display();
}