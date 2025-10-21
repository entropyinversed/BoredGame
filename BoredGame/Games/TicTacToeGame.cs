using BoredGame.Boards;
using BoredGame.Rules;

namespace BoredGame.Games;

public class TicTacToeGame(TicTacToeBoard board, TicTacToeRules rules) : IGame
{
    private bool _isGameOver;
    private char _currentMark = '0';
    
    public void Start()
    {
        board.Setup();
        _isGameOver = false;
    }

    public void PlayTurn()
    {
        var pieceRecord = InputManager.PlayTurn();

        board.TryPlaceMark(pieceRecord.Row, pieceRecord.Col, _currentMark);
        rules.ApplyRules(board);
        _isGameOver = rules.IsGameOver();
        _currentMark = _currentMark == 'X' ? '0' : 'X';
    }
    
    public bool IsGameOver() => _isGameOver;

    public void DisplayBoard() => board.Display();
}