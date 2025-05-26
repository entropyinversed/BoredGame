namespace BoredGameV2.Model;

public interface IBoard : IReadOnlyBoard
{
    void PlaceMark(Position pos, Mark mark);
    void clear();
}