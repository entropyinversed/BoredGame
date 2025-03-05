namespace BoredGame;

class Program
{
    static void Main(string[] args)
    {
        // TODO: ArgumentOutOfRange Exception isn't being thrown...
        Console.WriteLine("Choose game: [TicTacToe]");
        string input = Console.ReadLine();
        GameType gameType = Enum.Parse<GameType>(input);
        
        IGame game = GameFactory.CreateGame(gameType);
        game.Start();
        game.DisplayBoard();

        while (!game.IsGameOver())
        {
            Console.WriteLine("playing game");
            Thread.Sleep(5000);
        }
        
        Console.WriteLine("game over test");
	Console.WriteLine("for git push");
    }
}
