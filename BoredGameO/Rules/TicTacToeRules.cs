using BoredGame.Boards;

namespace BoredGame.Rules;

public class TicTacToeRules
{
    private const char Empty = '_';
    private static readonly (int row, int col)[][] AllWinLines =
    [
        // Row
        [(0, 0), (0, 1), (0, 2)],
        [(1, 0), (1, 1), (1, 2)],
        [(2, 0), (2, 1), (2, 2)],

        // Col
        [(0, 0), (1, 0), (2, 0)],
        [(0, 1), (1, 1), (2, 1)],
        [(0, 2), (1, 2), (2, 2)],

        // Dia
        [(0, 0), (1, 1), (2, 2)],
        [(0, 2), (1, 1), (2, 0)]
    ];
    
    private bool _gameOver;
    private char? _winner;
    
    public bool TryPlaceMark(int row, int col, char mark)
    {
        if (row is < 0 or > (SquareBoardLength - 1) || col is < 0 or > (SquareBoardLength - 1))
        {
            return false;
        }

        if (Cells[row, col] is not Empty)
        {
            return false;
        }
        
        Cells[row, col] = mark;
        return true;
    }

    public void ApplyRules(TicTacToeBoard board)
    {
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
}