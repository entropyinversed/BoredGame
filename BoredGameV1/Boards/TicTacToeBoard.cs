namespace BoredGame.Boards;

public class TicTacToeBoard : IBoard
{
    private const byte SquareBoardLength = 3;
    
    private readonly char[,] _cells = new char[SquareBoardLength, SquareBoardLength];
    public char[,] Cells => _cells;

    public void Setup()
    {
        for (var row = 0; row < SquareBoardLength; row++)
        {
            for (var col = 0; col < SquareBoardLength; col++)
            {
                _cells[row, col] = '_';
            } 
        }
    }

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();

        for (var row = 0; row < SquareBoardLength; row++)
        {
            for (var col = 0; col < SquareBoardLength; col++)
            {
                Console.Write($" {_cells[row, col]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();
    }

    public bool TryPlaceMark(int row, int col, char mark)
    {
        // TODO: Make more readable
        
        if (row is < 0 or > 2 || col is < 0 or > 2) return false;
        if (_cells[row, col] != '_') return false;
        _cells[row, col] = mark;
        return true;
    }
    
    public bool IsFull() => _cells.Cast<char>().All(c => c != '_');
}