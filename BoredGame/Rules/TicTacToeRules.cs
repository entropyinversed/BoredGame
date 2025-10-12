using BoredGame.Boards;

namespace BoredGame.Rules;

public class TicTacToeRules : IRules
{
    private const char Empty = '_';
    private static readonly (int row, int col)[][] AllWinLines =
    [
        [(0, 0), (0, 1), (0, 2)], // Row 0
        [(1, 0), (1, 1), (1, 2)], // Row 1
        [(2, 0), (2, 1), (2, 2)], // Row 2

        [(0, 0), (1, 0), (2, 0)], // Column 0
        [(0, 1), (1, 1), (2, 1)], // Column 1
        [(0, 2), (1, 2), (2, 2)], // Column 2

        [(0, 0), (1, 1), (2, 2)], // Diagonal ↘
        [(0, 2), (1, 1), (2, 0)], // Diagonal ↙
    ];
    
    private bool _gameOver;
    private char? _winner;

    public void ApplyRules(IBoard board)
    {
        Console.WriteLine("---Applying Rules TicTacToeRules---");
        
        if (board is not TicTacToeBoard ticTacToeBoard)
        {
            return;
        }
        
        var boardCells = ticTacToeBoard.Cells;
        
        foreach (var line in AllWinLines)
        {
            var firstCellValue = boardCells[line[0].row, line[0].col];
            if (firstCellValue == Empty)
            {
                continue;
            }

            if (boardCells[line[1].row, line[1].col] != firstCellValue ||
                boardCells[line[2].row, line[2].col] != firstCellValue)
            {
                continue;
            }

            _winner = firstCellValue;
            _gameOver = true;
            return;
        }
        _gameOver = ticTacToeBoard.IsFull();
    }

    public bool IsGameOver()
    {
        Console.WriteLine("Checking IsGameOver TicTacToe");

        if (!_gameOver)
        {
            return false;
        }
        
        var resultMessage = _winner == null ? 
            "It's a tie" : $"Player {_winner} won!";

        Console.WriteLine(resultMessage);
        
        return true;
    }
}
