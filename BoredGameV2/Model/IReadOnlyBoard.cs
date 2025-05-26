namespace BoredGameV2.Model;

public interface IReadOnlyBoard
{
    int Size { get; }
    Mark at(Position pos);
    IEnumerable<Position> EmptySquares();
}