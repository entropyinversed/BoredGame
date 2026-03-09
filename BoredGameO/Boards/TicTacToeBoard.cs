using BoredGame.UI;

namespace BoredGame.Boards;

public class TicTacToeBoard : IBoard
{
    private const byte SquareBoardLength = 3;
    private const char Empty = '_';
    
    public char[,] Cells { get; } = new char[SquareBoardLength, SquareBoardLength];

    public void Setup()
    {
        for (var row = 0; row < SquareBoardLength; row++)
        {
            for (var col = 0; col < SquareBoardLength; col++)
            {
                Cells[row, col] = Empty;
            } 
        }
    }

    public void Display()
    {
        BoardRenderer.DrawBoard(Cells, SquareBoardLength, SquareBoardLength);
    }

    public bool TryPlaceMark(int row, int col, char mark)
    {
        if (row is < 0 or > 2 || col is < 0 or > 2)
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
    
    public bool IsFull()
    {
        var allCells = Cells.Cast<char>();
        
        var noEmpty = allCells.All(c => c is not Empty);

        return noEmpty;
    }
}