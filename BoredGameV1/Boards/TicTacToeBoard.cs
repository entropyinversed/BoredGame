namespace BoredGame.Boards;

public class TicTacToeBoard : IBoard
{
    private readonly char[,] _cells = new char[3, 3];
    
    public char[,] Cells => _cells;

    public void Setup()
    {
        for (var row = 0; row < 3; row++)
            for (var col = 0; col < 3; col++)
                _cells[row, col] = '_';
    }

    public void Display()
    {
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();

        for (var row = 0; row < 3; row++)
        {
            for (var col = 0; col < 3; col++)
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
        if (row is < 0 or > 2 || col is < 0 or > 2) return false;
        if (_cells[row, col] != '_') return false;
        _cells[row, col] = mark;
        return true;
    }
    
    public bool IsFull() => _cells.Cast<char>().All(c => c != '_');
}