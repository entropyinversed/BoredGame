namespace BoredGame.UI;

public static class BoardRenderer
{
    public static void DrawBoard(char[,] cells, byte boardColumnSize, byte boardRowSize)
    {
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();

        for (var row = 0; row < boardRowSize; row++)
        {
            for (var col = 0; col < boardColumnSize; col++)
            {
                Console.Write($" {cells[row, col]} ");
            }
            Console.WriteLine();
        }
        
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();
    }
}