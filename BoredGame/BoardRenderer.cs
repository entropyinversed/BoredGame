namespace BoredGame;

public class BoardRenderer
{
    public static void Draw(char[,] cells, int squareBoardLength)
    {
        Console.WriteLine();
        Console.WriteLine("=========");
        Console.WriteLine();

        for (var row = 0; row < squareBoardLength; row++)
        {
            for (var col = 0; col < squareBoardLength; col++)
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