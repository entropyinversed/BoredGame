namespace BoredGame.UI;

public static class InputManager
{
    public record PieceMove(int Row, int Col);
    
    public static PieceMove GetMove()
    {
        while (true)
        {
            var parts = Console.ReadLine()?.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts?.Length == 2 &&
                int.TryParse(parts[0], out var row) &&
                int.TryParse(parts[1], out var col))
            {
                return new PieceMove(row, col);
            }
        }
    }
    
    public static GameType PromptForGameType()
    {
        while (true)
        {
            Console.WriteLine(
                "Choose a Game: [" + string.Join(", ", Enum.GetNames<GameType>()) + "]"
            );
            
            var input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input)
                && Enum.TryParse<GameType>(input.Trim(), ignoreCase: true, out var gameType)
                && Enum.IsDefined(typeof(GameType), gameType))
            {
                return gameType;
            }
        }
    }
}