namespace BoredGame.Games;

public interface IGame
{
    void Start();
    void PlayTurn();
    void DisplayBoard();
    bool IsGameOver();
}