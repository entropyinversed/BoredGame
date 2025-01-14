namespace BoredGame;

public interface IGame
{
    void Start();
    void PlayTurn();
    void DisplayBoard();
    bool IsGameOver();
}