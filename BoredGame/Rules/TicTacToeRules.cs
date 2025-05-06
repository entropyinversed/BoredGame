using BoredGame.Boards;

namespace BoredGame.Rules;

public class TicTacToeRules : IRules
{
    private bool _gameOver;
    private char _winner = ' ';

    public void ApplyRules(IBoard board)
    {
        if (board is not TicTacToeBoard ticTacToeBoard) return;
        var boardCells = ticTacToeBoard.Cells;

        for (var i = 0; i < 3; i++)
        {
            if (boardCells[i, 0] != '_' && boardCells[i, 0] == boardCells[i, 1] && boardCells[i, 1] == boardCells[i, 2])
            {
                _winner = boardCells[i, 0];
                _gameOver = true;
                return;
            }

            if (boardCells[0, i] != '_' && boardCells[0, i] == boardCells[i, 1] && boardCells[i, 1] == boardCells[i, 2])
            {
                _winner = boardCells[0, i];
                _gameOver = true;
                return;
            }
        }

        if (boardCells[1, 1] != '_' &&
            ((boardCells[0, 0] == boardCells[1, 1] && boardCells[1, 1] == boardCells[2, 2]) ||
             (boardCells[0, 2] == boardCells[1, 1] && boardCells[1, 1] == boardCells[2, 0])))
        {
            _winner = boardCells[1, 1];
            _gameOver = true;
            return;
        }
        
        _gameOver = ticTacToeBoard.IsFull();
    }

    public bool IsGameOver()
    {
        if (!_gameOver) return false;
        
        Console.WriteLine(_winner == '_'
            ? "It's a tie"
            : $"Player {_winner} won!");
        return true;
    }
}