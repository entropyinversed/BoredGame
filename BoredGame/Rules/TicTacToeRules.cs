using BoredGame.Boards;

namespace BoredGame.Rules;

public class TicTacToeRules : IRules
{
    private static readonly (int row, int col)[][] AllWinLines =
    {
        new[] { (0, 0), (0, 1), (0, 2) }, // Row 0
        new[] { (1, 0), (1, 1), (1, 2) }, // Row 1
        new[] { (2, 0), (2, 1), (2, 2) }, // Row 2
        
        new[] { (0, 0), (1, 0), (2, 0) }, // Col 1
        new[] { (0, 1), (1, 1), (2, 1) }, // Col 2
        new[] { (0, 2), (1, 2), (2, 2) }, // Col 3
        
        new[] { (0, 0), (1, 1), (2, 2) }, // Diag Left-Right
        new[] { (0, 2), (1, 1), (2, 0) }, // Diag Right-Left
    };
    
    private bool _gameOver;
    private char _winner = ' ';

    public void ApplyRules(IBoard board)
    {
        if (board is not TicTacToeBoard ticTacToeBoard) return;
        var boardCells = ticTacToeBoard.Cells;
        
        foreach (var line in AllWinLines)
        {
            var first = boardCells[line[0].row, line[0].col];
            if (first == '_') continue;

            if (boardCells[line[1].row, line[1].col] == first && boardCells[line[2].row, line[2].col] == first)
            {
                _winner = first;
                _gameOver = true;
                return;
            }
        }

        _gameOver = ticTacToeBoard.IsFull();
    }

    public bool IsGameOver()
    {
        if (!_gameOver) return false;
        
        Console.WriteLine(_winner == ' '
            ? "It's a tie"
            : $"Player {_winner} won!");
        return true;
    }
}