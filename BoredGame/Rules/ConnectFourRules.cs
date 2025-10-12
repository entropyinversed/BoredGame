using BoredGame.Boards;

namespace BoredGame.Rules;

public class ConnectFourRules : IRules
{
    private bool _gameOver;
    private char? _winner;
    
    public void ApplyRules(IBoard board)
    {
        Console.WriteLine("---Applying Rules ConnectFour---");

        if (board is not ConnectFourBoard connectFourBoard)
        {
            return;
        }

        var boardCells = connectFourBoard.Cells;
        const int boardSize = 4;
        const char empty = '_';

        for (int i = 0; i < boardSize; i++)
        {
            // Row
            if (boardCells[i, 0] != empty &&
                boardCells[i, 0] == boardCells[i, 1] &&
                boardCells[i, 1] == boardCells[i, 2] &&
                boardCells[i, 2] == boardCells[i, 3])
            {
                _winner = boardCells[i, 0];
                _gameOver = true;
                return;
            }
            
            // Col
            if (boardCells[0, i] != empty &&
               boardCells[0, i] == boardCells[1, i] &&
               boardCells[1, i] == boardCells[2, i] &&
               boardCells[2, i] == boardCells[3, i])
            {
                _winner = boardCells[0, i];
                _gameOver = true;
                return;
            }
        }
        _gameOver = connectFourBoard.IsFull();
    }

    public bool IsGameOver()
    {
        Console.WriteLine("---Checking IsGameOver ConnectFour---");

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
