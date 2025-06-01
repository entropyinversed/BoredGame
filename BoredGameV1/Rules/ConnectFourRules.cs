using BoredGame.Boards;

namespace BoredGame.Rules;

public class ConnectFourRules : IRules
{
    private bool _gameOver;
    private char? _winner;
    
    public void ApplyRules(IBoard board)
    {
        if (board is not ConnectFourBoard connectFourBoard)
        {
            return;
        }

        var boardCells = connectFourBoard.Cells;
        
        // TODO: Something
        
        _gameOver = true;
        return;
    }

    public bool IsGameOver()
    {
        if (!_gameOver)
        {
            return false;
        }
        
        var resultMessage = _winner == null ? 
            "It's a tie" : $"Player {_winner} won!";

        Console.WriteLine(resultMessage);
        
        return true;
    }
}