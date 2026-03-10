namespace BoredGame.UI;

public static class Renderer
{
    public static void DrawBoard(char[,] cells, byte boardColumnSize, byte boardRowSize)
    {
        for (var row = -1; row < cells.GetLength(0); row++)
        {
            if (row == -1)
            {
                Console.Write("   ");
                for (var col = 0; col < cells.GetLength(1); col++)
                {
                    Console.Write($" {col} ");
                }
                Console.WriteLine();
                row++;
            }
            Console.Write($" {row} ");
            for (var col = 0; col < cells.GetLength(1); col++)
            {
                Console.Write($" {cells[row, col]} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}