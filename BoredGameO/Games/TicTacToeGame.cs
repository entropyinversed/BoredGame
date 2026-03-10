using BoredGame.Boards;
using BoredGame.Rules;
using BoredGame.UI;

namespace BoredGame.Games;

public class TicTacToeGame(TicTacToeBoard board, TicTacToeRules rules)
{
    private bool _isGameOver;
    private char _currentMark = '0';
    
    public bool IsGameOver() => _isGameOver;
    
    public void Initialize()
    {
        board.Setup();
        _isGameOver = false;
    }

    public void PlayTurn()
    {
        var pieceRecord = UserInput.GetMove();

        board.TryPlaceMark(pieceRecord.Row, pieceRecord.Col, _currentMark);
        rules.ApplyRules(board);
        
        _isGameOver = rules.IsGameOver();
        _currentMark = _currentMark == 'X' ? '0' : 'X';
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