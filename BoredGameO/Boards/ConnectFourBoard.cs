using BoredGame.UI;

namespace BoredGame.Boards;

public class ConnectFourBoard : IBoard
{
    private const byte BoardColumnSize = 5;
    private const byte BoardRowSize = 4;
    private const char Empty = '_';
    
    public char[,] Cells { get; } = new char[BoardRowSize, BoardColumnSize];
    
    public void Setup()
    {
        for (var row = 0; row < BoardRowSize; row++)
        {
            for (var col = 0; col < BoardColumnSize; col++)
            {
                Cells[row, col] = Empty;
            }
        }
    }

    public void Display()
    {
        BoardRenderer.DrawBoard(Cells, BoardColumnSize, BoardRowSize);
    }

    public bool TryPlaceMark(int row, int col, char mark)
    {
        if (row is < 0 or > (BoardRowSize - 1) || col is < 0 or > (BoardColumnSize - 1))
        {
            return false;
        }

        if (row != 0)
        {
            return false;
        }

        if (Cells[row, col] is not Empty)
        {
            return false;
        }
        
        // Gravity
        for (var rowPosition = BoardRowSize - 1; rowPosition >= 0; rowPosition--)
        {
            if (Cells[rowPosition, col] == Empty)
            {
                Cells[rowPosition, col] = mark;
                break;
            }
        }

        return true;
    }

    public bool IsFull()
    {
        var allCells = Cells.Cast<char>();
        
        var noEmpty = allCells.All(c => c is not Empty);

        return noEmpty;
    }
}