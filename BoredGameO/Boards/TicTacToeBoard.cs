using BoredGame.UI;

namespace BoredGame.Boards;

public class TicTacToeBoard
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
    
    public bool IsFull()
    {
        var allCells = Cells.Cast<char>();
        var noEmpty = allCells.All(c => c is not Empty);
        return noEmpty;
    }
}